using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<LuongSanPhamDto>>
    {
        private readonly ILuongSanPhamRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(ILuongSanPhamRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LuongSanPhamDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAllAsync(c => c.NgayXoa == null, cancellationToken);
            return lnp.MapToLuongSanPhamDtoList(_mapper);
        }
    }
}
