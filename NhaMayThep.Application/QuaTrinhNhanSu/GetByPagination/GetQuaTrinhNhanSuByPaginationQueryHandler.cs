using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetByPagination
{
    public class GetQuaTrinhNhanSuByPaginationQueryHandler : IRequestHandler<GetQuaTrinhNhanSuByPaginationQuery, PagedResult<QuaTrinhNhanSuDto>>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        public GetQuaTrinhNhanSuByPaginationQueryHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, IMapper mapper)
        {
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<QuaTrinhNhanSuDto>> Handle(GetQuaTrinhNhanSuByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _quaTrinhNhanSuRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<QuaTrinhNhanSuDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToQuaTrinhNhanSuDtoList(_mapper)
                );
        }
    }
}
