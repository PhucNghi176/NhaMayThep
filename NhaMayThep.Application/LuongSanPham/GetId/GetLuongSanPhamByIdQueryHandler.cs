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
    public class GetLuongSanPhamByIdQueryHandler : IRequestHandler<GetLuongSanPhamByIdQuery, LuongSanPhamDto>
    {
        private readonly ILuongSanPhamRepository _repository;
        private readonly IMapper _mapper;


        public GetLuongSanPhamByIdQueryHandler(ILuongSanPhamRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<LuongSanPhamDto> Handle(GetLuongSanPhamByIdQuery request, CancellationToken cancellationToken)
        {
            var luongSanPham = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (luongSanPham == null)
                throw new NotFoundException($"không tìm thấy lương sản phẩm với ID : {request.ID} hoặc đã bị xóa.");

            return luongSanPham.MapToLuongSanPhamDto(_mapper);
        }

    }
}
