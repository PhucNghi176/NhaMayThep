using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LuongSanPham.Filter
{
    public class FilterLuongSanPhamQueryHandler : IRequestHandler<FilterLuongSanPhamQuery, PagedResult<LuongSanPhamDto>>
    {
        private readonly ILuongSanPhamRepository _luongSanPhamRepository;
        private readonly IMapper _mapper;

        public FilterLuongSanPhamQueryHandler(ILuongSanPhamRepository luongSanPhamRepository, IMapper mapper)
        {
            _luongSanPhamRepository = luongSanPhamRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<LuongSanPhamDto>> Handle(FilterLuongSanPhamQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LuongSanPhamEntity>, IQueryable<LuongSanPhamEntity>> option = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);

                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));

                if (!string.IsNullOrEmpty(request.MucSanPham))
                    query = query.Where(x => x.MucSanPhamID.Equals(request.MucSanPham));

                if (request.SoSanPhamLam != null)
                    query = query.Where(x => x.SoSanPhamLam == request.SoSanPhamLam);

                return query;
            };

            var list = await _luongSanPhamRepository.FindAllAsync(request.PageNo, request.PageSize, option, cancellationToken);

            if (!list.Any())
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");


            return PagedResult<LuongSanPhamDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLuongSanPhamDtoList(_mapper)
                );
        }
    }
}
