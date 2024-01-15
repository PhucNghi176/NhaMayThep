using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiHoaDon.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Update
{
    public class UpdateLoaiHoaDonCommandHandler : IRequestHandler<CreateLoaiHoaDonCommand, LoaiHoaDonDto>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public UpdateLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<LoaiHoaDonDto> Handle(CreateLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = await _LoaiHoaDonRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiHoaDon == null)
            {
                throw new NotFoundException("Loai Hoa Don list is empty");
            }
            _LoaiHoaDonRepository.Update(loaiHoaDon);
            await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiHoaDon.MapToLoaiHoaDonDto(_mapper);
        }
    }
}
