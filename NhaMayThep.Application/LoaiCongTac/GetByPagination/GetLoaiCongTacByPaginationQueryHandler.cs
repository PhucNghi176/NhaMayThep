using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.GetByPagination
{
    public class GetLoaiCongTacByPaginationQueryHandler : IRequestHandler<GetLoaiCongTacByPaginationQuery, PagedResult<LoaiCongTacDto>>
    {
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;
        private readonly IMapper _mapper;
        public GetLoaiCongTacByPaginationQueryHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<LoaiCongTacDto>> Handle(GetLoaiCongTacByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _loaiCongTacRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LoaiCongTacDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLoaiCongTacDtoList(_mapper)
                );
        }
    }
}
