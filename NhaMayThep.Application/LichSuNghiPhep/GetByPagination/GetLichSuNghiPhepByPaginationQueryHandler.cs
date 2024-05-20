using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.LichSuNghiPhep.GetByPagination
{
    public class GetLichSuNghiPhepByPaginationQueryHandler : IRequestHandler<GetLichSuNghiPhepByPaginationQuery, PagedResult<LichSuNghiPhepDto>>
    {
        private readonly ILichSuNghiPhepRepository _lichSuNghiPhepRepository;
        private readonly IMapper _mapper;
        public GetLichSuNghiPhepByPaginationQueryHandler(ILichSuNghiPhepRepository lichSuNghiPhepRepository, IMapper mapper)
        {
            _lichSuNghiPhepRepository = lichSuNghiPhepRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<LichSuNghiPhepDto>> Handle(GetLichSuNghiPhepByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _lichSuNghiPhepRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LichSuNghiPhepDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLichSuNghiPhepDtoList(_mapper)
                );
        }
    }
}
