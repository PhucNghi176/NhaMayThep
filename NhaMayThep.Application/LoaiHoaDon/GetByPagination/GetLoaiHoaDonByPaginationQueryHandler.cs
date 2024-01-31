using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.GetByPagination
{
    public class GetLoaiHoaDonByPaginationQueryHandler : IRequestHandler<GetLoaiHoaDonByPaginationQuery, PagedResult<LoaiHoaDonDto>>
    {
        private readonly ILoaiHoaDonRepository _loaiHoaDonRepository;
        private readonly IMapper _mapper;
        public GetLoaiHoaDonByPaginationQueryHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _loaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<LoaiHoaDonDto>> Handle(GetLoaiHoaDonByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _loaiHoaDonRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LoaiHoaDonDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLoaiHoaDonDtoList(_mapper)
                );
        }
    }
}
