using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.GetAll
{
    public class GetAllLoaiHoaDonQueryHandler : IRequestHandler<GetAllLoaiHoaDonQuerry, List<LoaiHoaDonDto>>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public GetAllLoaiHoaDonQueryHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<List<LoaiHoaDonDto>> Handle(GetAllLoaiHoaDonQuerry request, CancellationToken cancellationToken)
        {
            var list = await _LoaiHoaDonRepository.FindAllAsync(cancellationToken);
            if (list == null)
            {
                throw new NotFoundException("LoaiCongTac list is empty");
            }
            return list.MapToLoaiHoaDonDtoList(_mapper);
        }
        
    }
}
