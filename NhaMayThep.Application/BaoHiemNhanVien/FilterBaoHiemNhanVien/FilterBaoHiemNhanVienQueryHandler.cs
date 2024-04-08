using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVien.FilterBaoHiemNhanVien
{
    public class FilterBaoHiemNhanVienQueryHandler : IRequestHandler<FilterBaoHiemNhanVienQuery, PagedResult<BaoHiemNhanVienDto>>
    {
        private readonly IBaoHiemNhanVienRepository _repository;
        private readonly IMapper _mapper;

        public FilterBaoHiemNhanVienQueryHandler(IBaoHiemNhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BaoHiemNhanVienDto>> Handle(FilterBaoHiemNhanVienQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<BaoHiemNhanVienEntity>, IQueryable<BaoHiemNhanVienEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));
                }
                return query;
            };
            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin bảo hiểm nhân viên.");
            }

            return PagedResult<BaoHiemNhanVienDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.Select(x => _mapper.Map<BaoHiemNhanVienDto>(x)).ToList());
        }
    }
}
