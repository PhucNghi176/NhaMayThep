using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LuongSanPham.GetId;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.GetId
{
    public class GetLuongSanPhamByIdQueryHandler : IRequestHandler<GetLuongSanPhamByIDQuery, LuongSanPhamDto>
    {
        private readonly ILuongSanPhamRepository _repository;
        private readonly IMapper _mapper;


        public GetLuongSanPhamByIdQueryHandler(ILuongSanPhamRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LuongSanPhamDto> Handle(GetLuongSanPhamByIDQuery request, CancellationToken cancellationToken)
        {
            var lnp = await _repository.FindAsync(x => x.ID == request.ID, cancellationToken);
            if (lnp == null)
            {
                throw new NotFoundException("LuongSanPham Does not Exist");

            }
            if (lnp.NgayXoa != null)
            {
                throw new NotFoundException("LuongSanPham Is Deleted");
            }

            return lnp.MapToLuongSanPhamDto(_mapper);
        }

    }
}
