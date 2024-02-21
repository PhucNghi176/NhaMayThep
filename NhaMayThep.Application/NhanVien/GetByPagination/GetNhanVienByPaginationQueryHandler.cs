using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetByPagination
{
    public class GetNhanVienByPaginationQueryHandler : IRequestHandler<GetNhanVienByPaginationQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        public GetNhanVienByPaginationQueryHandler(INhanVienRepository nhanVienRepository, IMapper mapper)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<NhanVienDto>> Handle(GetNhanVienByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _nhanVienRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<NhanVienDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToNhanVienDtoList(_mapper)
                );
        }
    }
}
