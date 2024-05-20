using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinDangVien.GetByPagination
{
    public class GetThongTinDangVienByPaginationQueryHandler : IRequestHandler<GetThongTinDangVienByPaginationQuery, PagedResult<ThongTinDangVienDto>>
    {
        private readonly IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;
        public GetThongTinDangVienByPaginationQueryHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinDangVienDto>> Handle(GetThongTinDangVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinDangVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinDangVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinDangVienDtoList(_mapper)
                );
        }
    }
}
