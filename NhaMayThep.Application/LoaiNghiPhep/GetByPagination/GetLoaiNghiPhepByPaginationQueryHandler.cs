using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.GetByPagination
{
    public class GetLoaiNghiPhepByPaginationQueryHandler : IRequestHandler<GetLoaiNghiPhepByPaginationQuery, PagedResult<LoaiNghiPhepDto>>
    {
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepository;
        private readonly IMapper _mapper;
        public GetLoaiNghiPhepByPaginationQueryHandler(ILoaiNghiPhepRepository loaiNghiPhepRepository, IMapper mapper)
        {
            _loaiNghiPhepRepository = loaiNghiPhepRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<LoaiNghiPhepDto>> Handle(GetLoaiNghiPhepByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _loaiNghiPhepRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LoaiNghiPhepDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLoaiNghiPhepDtoList(_mapper)
                );
        }
    }
}
