using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDaoTao.GetByPagination
{
    public class GetThongTinDaoTaoByPaginationQueryHandler : IRequestHandler<GetThongTinDaoTaoByPaginationQuery, PagedResult<ThongTinDaoTaoDto>>
    {
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly IMapper _mapper;
        public GetThongTinDaoTaoByPaginationQueryHandler(IThongTinDaoTaoRepository thongTinDaoTaoRepository, IMapper mapper)
        {
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinDaoTaoDto>> Handle(GetThongTinDaoTaoByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinDaoTaoRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinDaoTaoDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinDaoTaoDtoList(_mapper)
                );
        }
    }
}
