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

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.GetByPagination
{
    public class GetThongTinGiamTruGiaCanhByPaginationQueryHandler : IRequestHandler<GetThongTinGiamTruGiaCanhByPaginationQuery, PagedResult<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruGiaCanhByPaginationQueryHandler(IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository, IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinGiamTruGiaCanhDto>> Handle(GetThongTinGiamTruGiaCanhByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _thongTinGiamTruGiaCanhRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ThongTinGiamTruGiaCanhDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToThongTinGiamTruGiaCanhDtoList(_mapper)
                );
        }
    }
}
