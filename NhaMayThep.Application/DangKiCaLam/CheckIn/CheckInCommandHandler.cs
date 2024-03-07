﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.CheckIn
{
    public class CheckInCommandHandler : IRequestHandler<CheckInCommand, DangKiCaLamDto>
    {
        private readonly IDangKiCaLamRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CheckInCommandHandler(IDangKiCaLamRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DangKiCaLamDto> Handle(CheckInCommand request, CancellationToken cancellationToken)
        {
           
            var dangKiCaLam = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKiCaLam == null || dangKiCaLam.NgayXoa.HasValue)
            {
                throw new NotFoundException($"Không tìm thấy đăng kí ca làm với Id {request.Id}.");
            }

            var now = DateTime.UtcNow; 
            dangKiCaLam.ThoiGianChamCongBatDau = now;

            if (now > dangKiCaLam.ThoiGianCaLamBatDau)
            {
                // Late check-in
                dangKiCaLam.GhiChu += " Check-in trễ.";
            }
        
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            // Return updated DangKiCaLamDto
            return _mapper.Map<DangKiCaLamDto>(dangKiCaLam);
        }
    }

}
