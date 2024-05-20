using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TinhTrangLamViec.GetByPagination
{
    public class GetTinhTrangLamViecByPaginationQueryHandler : IRequestHandler<GetTinhTrangLamViecByPaginationQuery, PagedResult<TinhTrangLamViecDTO>>
    {
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        private readonly IMapper _mapper;
        public GetTinhTrangLamViecByPaginationQueryHandler(ITinhTrangLamViecRepository tinhTrangLamViecRepository, IMapper mapper)
        {
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<TinhTrangLamViecDTO>> Handle(GetTinhTrangLamViecByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _tinhTrangLamViecRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<TinhTrangLamViecDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToTinhTrangLamViecDTOList(_mapper)
                );
        }
    }
}
