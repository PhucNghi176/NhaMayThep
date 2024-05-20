using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByPagination
{
    public class GetHoaDonCongTacNhanVienByPaginationQueryHandler : IRequestHandler<GetHoaDonCongTacNhanVienByPaginationQuery, PagedResult<HoaDonCongTacNhanVienDto>>
    {
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        public GetHoaDonCongTacNhanVienByPaginationQueryHandler(IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository, IMapper mapper)
        {
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<HoaDonCongTacNhanVienDto>> Handle(GetHoaDonCongTacNhanVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _hoaDonCongTacNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<HoaDonCongTacNhanVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToHoaDonCongTacNhanVienDtoList(_mapper)
                );
        }
    }
}
