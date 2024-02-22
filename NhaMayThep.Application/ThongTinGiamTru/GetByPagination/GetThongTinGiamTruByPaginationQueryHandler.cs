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

namespace NhaMayThep.Application.ThongTinGiamTru.GetByPagination
{
    public class GetThongTinGiamTruByPaginationQueryHandler : IRequestHandler<GetThongTinGiamTruByPaginationQuery, PagedResult<ThongTinGiamTruDTO>>
    {
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruByPaginationQueryHandler(IThongTinGiamTruRepository thongTinGiamTruRepository, IMapper mapper)
        {
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinGiamTruDTO>> Handle(GetThongTinGiamTruByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinGiamTruRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinGiamTruDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinGiamTruDTOList(_mapper)
                );
        }
    }
}
