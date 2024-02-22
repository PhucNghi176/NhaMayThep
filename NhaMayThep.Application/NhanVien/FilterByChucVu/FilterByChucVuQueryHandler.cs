using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByChucVu
{
    public class FilterByChucVuQueryHandler : IRequestHandler<FilterByChucVuQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterByChucVuQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public FilterByChucVuQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterByChucVuQuery request, CancellationToken cancellationToken)
        {
            var nhanvien = await this._repository.FindAllAsync(x => x.ChucVuID.Equals(request.chucvuID) && x.NgayXoa == null
                                                               , request.pageNumber
                                                               , request.pageSize
                                                               , cancellationToken);
            if (nhanvien.Count() == 0)
                throw new NotFoundException($"Không tìm thấy nhân viên với Chức vụ ID : {request.chucvuID}");
            var list = nhanvien.MapToNhanVienDtoList(_mapper);
            return PagedResult<NhanVienDto>.Create(totalCount: nhanvien.TotalCount,
                                    pageCount: nhanvien.PageCount,
                                            pageSize: nhanvien.PageSize,
                                                    pageNumber: nhanvien.PageNo,
                                                            data: list);
        }
    }
}
