using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LuongSanPham.GetAll;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllLuongSanPhamQueryHandler : IRequestHandler<GetAllLuongSanPhamQuery, List<LuongSanPhamDto>>
    {
        private readonly ILuongSanPhamRepository _LuongSanPhamRepository;
        private readonly IMapper _mapper;

        public GetAllLuongSanPhamQueryHandler(ILuongSanPhamRepository LuongSanPhamRepository, IMapper mapper)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _mapper = mapper;
        }

        public async Task<List<LuongSanPhamDto>> Handle(GetAllLuongSanPhamQuery request, CancellationToken cancellationToken)
        {

            var LuongSanPhamList = await _LuongSanPhamRepository.FindAllAsync(cancellationToken);
            return LuongSanPhamList.MapToLuongSanPhamDtoList(_mapper);
        }
    }
}
