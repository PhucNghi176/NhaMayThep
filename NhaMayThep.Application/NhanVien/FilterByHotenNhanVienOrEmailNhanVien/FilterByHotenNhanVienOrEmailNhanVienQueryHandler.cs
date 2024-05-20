using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Pagination;

namespace NhaMayThep.Application.NhanVien.FilterByHotenNhanVienOrEmailNhanVien
{
    public class FilterByHotenNhanVienOrEmailNhanVienQueryHandler : IRequestHandler<FilterByHotenNhanVienOrEmailNhanVienQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterByHotenNhanVienOrEmailNhanVienQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public FilterByHotenNhanVienOrEmailNhanVienQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterByHotenNhanVienOrEmailNhanVienQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.FindAllAsync(x => x.Email.Contains(request.HoTenHoacEmail) && x.NgayXoa == null || x.HoVaTen.Contains(request.HoTenHoacEmail) && x.NgayXoa == null, request.PageNumber, request.PageSize, cancellationToken);
            if (result == null)
                throw new NotFoundException("Không tìm thấy nhân viên");
            var list = result.MapToNhanVienDtoList(_mapper);
            return PagedResult<NhanVienDto>.Create(totalCount: result.TotalCount,
                               pageCount: result.PageCount,
                                       pageSize: result.PageSize,
                                               pageNumber: result.PageNo,
                                                       data: list);
        }
    }
}
