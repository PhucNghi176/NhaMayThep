﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.CheckOut
{
    public class CheckOutCommandHandler : IRequestHandler<CheckOutCommand, DangKiCaLamDto>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CheckOutCommandHandler(IDangKiCaLamRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DangKiCaLamDto> Handle(CheckOutCommand request, CancellationToken cancellationToken)
        {
            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null || dangKiCaLam.NgayXoa.HasValue)
            {
                throw new NotFoundException($"Record not found for MaCaLamViec {request.Id}.");
            }

            var now = DateTime.UtcNow; // Consider using a specific timezone if needed
            var scheduledEndTimePassed = now > dangKiCaLam.ThoiGianCaLamKetThuc.AddHours(2); // Example threshold of 2 hours after scheduled end time

            if (scheduledEndTimePassed)
            {
                // Missed check-out scenario
                dangKiCaLam.GhiChu += " Không Check Out.";
            }
            else if (now < dangKiCaLam.ThoiGianCaLamKetThuc)
            {
                // Early check-out
                dangKiCaLam.GhiChu += " Check-out sớm.";
                dangKiCaLam.ThoiGianChamCongKetThuc = now;
            }
            else
            {
                // On-time or late check-out
                dangKiCaLam.GhiChu += now > dangKiCaLam.ThoiGianCaLamKetThuc ? " Check-out muộn." : "";
                dangKiCaLam.ThoiGianChamCongKetThuc = now;
            }

            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Return updated DangKiCaLamDto
            return _mapper.Map<DangKiCaLamDto>(dangKiCaLam);
        }
    }
}
