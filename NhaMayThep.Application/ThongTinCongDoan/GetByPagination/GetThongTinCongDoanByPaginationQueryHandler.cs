using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinCongDoan.GetByPagination
{
    public class GetThongTinCongDoanByPaginationQueryHandler : IRequestHandler<GetThongTinCongDoanByPaginationQuery, PagedResult<ThongTinCongDoanDto>>
    {
        private readonly IThongTinCongDoanRepository _thongTinCongDoanRepository;
        private readonly IMapper _mapper;
        public GetThongTinCongDoanByPaginationQueryHandler(IThongTinCongDoanRepository thongTinCongDoanRepository, IMapper mapper)
        {
            _thongTinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinCongDoanDto>> Handle(GetThongTinCongDoanByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinCongDoanRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinCongDoanDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinCongDoanDtoList(_mapper)
                );
        }
    }
}
