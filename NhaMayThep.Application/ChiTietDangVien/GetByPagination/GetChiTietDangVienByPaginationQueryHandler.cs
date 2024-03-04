using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietDangVien.GetByPagination
{
    public class GetChiTietDangVienByPaginationQueryHandler : IRequestHandler<GetChiTietDangVienByPaginationQuery, PagedResult<ChiTietDangVienDto>>
    {
        private readonly IChiTietDangVienRepository _chiTietDangVienRepository;
        private readonly IMapper _mapper;
        public GetChiTietDangVienByPaginationQueryHandler(IChiTietDangVienRepository chiTietDangVienRepository, IMapper mapper)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChiTietDangVienDto>> Handle(GetChiTietDangVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _chiTietDangVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<ChiTietDangVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToChiTietDangVienDtoList(_mapper)
                );
        }
    }
}
