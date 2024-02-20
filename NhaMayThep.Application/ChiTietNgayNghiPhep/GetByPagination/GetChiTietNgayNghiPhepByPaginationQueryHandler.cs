using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
