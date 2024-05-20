using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ThongTinPhuCap.GetByPagination
{
    public class GetPhuCapByPaginationQueryHandler : IRequestHandler<GetPhuCapByPaginationQuery, PagedResult<PhuCapDto>>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly IMapper _mapper;
        public GetPhuCapByPaginationQueryHandler(IPhuCapRepository phuCapRepository, IMapper mapper)
        {
            _phuCapRepository = phuCapRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<PhuCapDto>> Handle(GetPhuCapByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _phuCapRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<PhuCapDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToListDto(_mapper)
                );
        }
    }
}
