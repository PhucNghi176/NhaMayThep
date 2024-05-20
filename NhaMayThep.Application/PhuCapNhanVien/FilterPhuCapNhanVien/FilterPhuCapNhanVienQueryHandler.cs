using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.PhuCapNhanVien.FilterPhuCapNhanVien
{
    public class FilterPhuCapNhanVienQueryHandler : IRequestHandler<FilterPhuCapNhanVienQuery, PagedResult<PhuCapNhanVienDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPhuCapNhanVienRepository _phuCapNhanVienRepository;

        public FilterPhuCapNhanVienQueryHandler(IMapper mapper, IPhuCapNhanVienRepository phuCapNhanVienRepository)
        {
            _mapper = mapper;
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
        }
        public async Task<PagedResult<PhuCapNhanVienDto>> Handle(FilterPhuCapNhanVienQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<PhuCapNhanVienEntity>, IQueryable<PhuCapNhanVienEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);

                if (request.PhuCap != 0)
                {
                    query = query.Where(x => x.PhuCap.Equals(request.PhuCap));
                }
                return query;
            };

            var result = await _phuCapNhanVienRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy phụ cấp nhân viên.");

            return PagedResult<PhuCapNhanVienDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToPhuCapNhanVienDtoList(_mapper));
        }
    }
}
