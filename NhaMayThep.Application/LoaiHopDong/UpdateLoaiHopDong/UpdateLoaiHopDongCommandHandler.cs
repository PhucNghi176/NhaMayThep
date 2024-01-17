﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommandHandler : IRequestHandler<UpdateLoaiHopDongCommand, LoaiHopDongDto>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        private readonly IMapper _mapper;
        public UpdateLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository, IMapper mapper)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
            _mapper = mapper;
        }
        public async Task<LoaiHopDongDto> Handle(UpdateLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var result = await _loaiHopDongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Not found loai hop dong {command.Id}");
            result.Name = command.TenHopDong;
            _loaiHopDongRepository.Update(result);
            await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToLoaiHopDongDto(_mapper);
        }
    }
}