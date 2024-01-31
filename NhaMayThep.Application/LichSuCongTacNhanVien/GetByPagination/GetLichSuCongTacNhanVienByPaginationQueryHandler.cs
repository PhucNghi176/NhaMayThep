using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.GetByPagination
{
    public class GetLichSuCongTacNhanVienByPaginationQueryHandler : IRequestHandler<GetLichSuCongTacNhanVienByPaginationQuery, PagedResult<LichSuCongTacNhanVienDto>>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        public GetLichSuCongTacNhanVienByPaginationQueryHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<LichSuCongTacNhanVienDto>> Handle(GetLichSuCongTacNhanVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _lichSuCongTacNhanVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<LichSuCongTacNhanVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToLichSuCongTacNhanVienDtoList(_mapper)
                );
        }
    }
}
