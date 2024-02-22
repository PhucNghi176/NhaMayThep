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

namespace NhaMayThep.Application.TinhTrangLamViec.GetByPagination
{
    public class GetTinhTrangLamViecByPaginationQueryHandler : IRequestHandler<GetTinhTrangLamViecByPaginationQuery, PagedResult<TinhTrangLamViecDTO>>
    {
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        private readonly IMapper _mapper;
        public GetTinhTrangLamViecByPaginationQueryHandler(ITinhTrangLamViecRepository tinhTrangLamViecRepository, IMapper mapper)
        {
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<TinhTrangLamViecDTO>> Handle(GetTinhTrangLamViecByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _tinhTrangLamViecRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<TinhTrangLamViecDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToTinhTrangLamViecDTOList(_mapper)
                );
        }
    }
}
