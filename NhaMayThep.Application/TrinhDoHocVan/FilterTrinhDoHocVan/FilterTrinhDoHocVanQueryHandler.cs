using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.TrinhDoHocVan.FilterTrinhDoHocVan
{
    public class FilterTrinhDoHocVanQueryHandler : IRequestHandler<FilterTrinhDoHocVanQuery, PagedResult<TrinhDoHocVanDto>>
    {
        private readonly ITrinhDoHocVanRepository _repository;
        private readonly IMapper _mapper;

        public FilterTrinhDoHocVanQueryHandler(ITrinhDoHocVanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TrinhDoHocVanDto>> Handle(FilterTrinhDoHocVanQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<TrinhDoHocVanEntity>, IQueryable<TrinhDoHocVanEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (!string.IsNullOrEmpty(request.TenTrinhDo))
                {
                    query = query.Where(x => x.Name.Contains(request.TenTrinhDo));
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin trình độ học vấn.");
            }

            var mappedResult = result.Select(x => _mapper.Map<TrinhDoHocVanDto>(x));

            return PagedResult<TrinhDoHocVanDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: mappedResult.ToList());
        }
    }
}
