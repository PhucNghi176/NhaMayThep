using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetByPagination
{
    public class GetKyLuatByPaginationQueryHandler : IRequestHandler<GetKyLuatByPaginationQuery, PagedResult<KyLuatDTO>>
    {
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;
        public GetKyLuatByPaginationQueryHandler(IKyLuatRepository kyLuatRepository, IMapper mapper)
        {
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<KyLuatDTO>> Handle(GetKyLuatByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _kyLuatRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<KyLuatDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToTinhKyLuatDTOList(_mapper)
                );
        }
    }
}
