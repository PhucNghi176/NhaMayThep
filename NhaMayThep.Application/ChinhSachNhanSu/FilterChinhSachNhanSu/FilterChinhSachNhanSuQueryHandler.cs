using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.QuaTrinhNhanSu.FilterQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMayThep.Infrastructure.Persistence;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.ChinhSachNhanSu.FilterChinhSachNhanSu
{
    public class FilterChinhSachNhanSuQueryHandler : IRequestHandler<FilterChinhSachNhanSuQuery, PagedResult<ChinhSachNhanSuDto>>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly IMapper _mapper;
        public FilterChinhSachNhanSuQueryHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<ChinhSachNhanSuDto>> Handle(FilterChinhSachNhanSuQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ChinhSachNhanSuEntity>, IQueryable<ChinhSachNhanSuEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (request.NgayHieuLuc.HasValue)
                {
                    query = query.Where(x => x.NgayTao.Equals(request.NgayHieuLuc));
                }
                if (!string.IsNullOrEmpty(request.MucDo))
                {
                    query = query.Where(x => x.MucDo.Contains(request.MucDo));
                }
                return query;
            };
            var result = await _chinhSachNhanSuRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy chính sách nhân sự nào.");
            }

            return PagedResult<ChinhSachNhanSuDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToChinhSachNhanSuDtoList(_mapper));
        }
    }
}
