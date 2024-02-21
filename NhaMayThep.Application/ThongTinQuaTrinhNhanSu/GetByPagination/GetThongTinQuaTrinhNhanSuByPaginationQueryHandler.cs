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

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetByPagination
{
    public class GetThongTinQuaTrinhNhanSuByPaginationQueryHandler : IRequestHandler<GetThongTinQuaTrinhNhanSuByPaginationQuery, PagedResult<ThongTinQuaTrinhNhanSuDto>>
    {
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        public GetThongTinQuaTrinhNhanSuByPaginationQueryHandler(IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository, IMapper mapper)
        {
            _thongTinQuaTrinhNhanSuRepository = thongTinQuaTrinhNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinQuaTrinhNhanSuDto>> Handle(GetThongTinQuaTrinhNhanSuByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinQuaTrinhNhanSuRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinQuaTrinhNhanSuDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinQuaTrinhNhanSuDtoList(_mapper)
                );
        }
    }
}
