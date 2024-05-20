using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetByPagination
{
    public class GetChiTietNgayNghiPhepByPaginationQueryHandler : IRequestHandler<GetChiTietNgayNghiPhepByPaginationQuery, PagedResult<ChiTietNgayNghiPhepDto>>
    {
        private readonly IChiTietNgayNghiPhepRepository _chiTietNgayNghiPhepRepository;
        private readonly IMapper _mapper;
        public GetChiTietNgayNghiPhepByPaginationQueryHandler(IChiTietNgayNghiPhepRepository chiTietNgayNghiPhepRepository, IMapper mapper)
        {
            _chiTietNgayNghiPhepRepository = chiTietNgayNghiPhepRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChiTietNgayNghiPhepDto>> Handle(GetChiTietNgayNghiPhepByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _chiTietNgayNghiPhepRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ChiTietNgayNghiPhepDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToChiTietNgayNghiPhepDtoList(_mapper)
                );
        }
    }
}
