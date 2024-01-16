using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Create
{
    public class CreateLoaiHoaDonCommandHandler : IRequestHandler<CreateLoaiHoaDonCommand, LoaiHoaDonDto>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public CreateLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<LoaiHoaDonDto> Handle(CreateLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = new LoaiHoaDonEntity() 
            {
                Name = request.Name,
            };
            
            _LoaiHoaDonRepository.Add(loaiHoaDon);
            await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiHoaDon.MapToLoaiHoaDonDto(_mapper);
        }
    }
}
