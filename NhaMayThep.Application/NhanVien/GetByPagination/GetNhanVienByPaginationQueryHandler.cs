using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.GetByPagination
{
    public class GetNhanVienByPaginationQueryHandler : IRequestHandler<GetNhanVienByPaginationQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        public GetNhanVienByPaginationQueryHandler(INhanVienRepository nhanVienRepository, IMapper mapper)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<NhanVienDto>> Handle(GetNhanVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _nhanVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<NhanVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToNhanVienDtoList(_mapper)
                );
        }
    }
}
