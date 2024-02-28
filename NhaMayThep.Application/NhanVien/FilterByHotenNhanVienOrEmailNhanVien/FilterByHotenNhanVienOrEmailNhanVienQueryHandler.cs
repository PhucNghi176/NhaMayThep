using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.GetHoTenNhanVienByEmail
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
            var result = await this._repository.FindAllAsync(x => (x.Email.Contains(request.HoTenHoacEmail) && x.NgayXoa == null) || (x.HoVaTen.Contains(request.HoTenHoacEmail) && x.NgayXoa == null), request.PageNumber, request.PageSize, cancellationToken);
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
