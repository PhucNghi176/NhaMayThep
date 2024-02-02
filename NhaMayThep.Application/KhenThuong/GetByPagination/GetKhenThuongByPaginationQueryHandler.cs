using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetByPagination
{
    public class GetKhenThuongByPaginationQueryHandler : IRequestHandler<GetKhenThuongByPaginationQuery, PagedResult<KhenThuongDTO>>
    {
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;
        public GetKhenThuongByPaginationQueryHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper)
        {
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<KhenThuongDTO>> Handle(GetKhenThuongByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _khenThuongRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<KhenThuongDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToKhenThuongDTOList(_mapper)
                );
        }
    }
}
