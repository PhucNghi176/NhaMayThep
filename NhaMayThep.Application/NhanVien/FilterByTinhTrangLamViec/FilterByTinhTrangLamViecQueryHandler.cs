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

namespace NhaMayThep.Application.NhanVien.FilterByTinhTrangLamViec
{
    public class FilterByTinhTrangLamViecQueryHandler : IRequestHandler<FilterByTinhTrangLamViecQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterByTinhTrangLamViecQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public FilterByTinhTrangLamViecQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterByTinhTrangLamViecQuery request, CancellationToken cancellationToken)
        {
            var nhanvien = await this._repository.FindAllAsync(x => x.TinhTrangLamViecID.Equals(request.tinhtranglamviecID) && x.NgayXoa == null
                                                               , request.pageNumber
                                                               , request.pageSize
                                                               , cancellationToken);
            if (nhanvien.Count() == 0)
                throw new NotFoundException($"Không tìm thấy nhân viên với tình trạng làm việc ID : {request.tinhtranglamviecID}");
            var list = nhanvien.MapToNhanVienDtoList(_mapper);
            return PagedResult<NhanVienDto>.Create(totalCount: nhanvien.TotalCount,
                                    pageCount: nhanvien.PageCount,
                                            pageSize: nhanvien.PageSize,
                                                    pageNumber: nhanvien.PageNo,
                                                            data: list);
        }
    }
}
