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

namespace NhaMayThep.Application.NhanVien.FilterByChucDanhChucVuTinhTrangLamViec
{
    public class FilterByChucDanhChucVuTinhTrangLamViecQueryHandler : IRequestHandler<FilterByChucDanhChucVuTinhTrangLamViecQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FilterByChucDanhChucVuTinhTrangLamViecQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public FilterByChucDanhChucVuTinhTrangLamViecQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FilterByChucDanhChucVuTinhTrangLamViecQuery request, CancellationToken cancellationToken)
        {
            var result = await this._repository.FindAllAsync(x => (x.ChucVu.Name.Contains(request.request) || x.TinhTrangLamViec.Name.Contains(request.request)) && x.NgayXoa == null
                                                            , request.PageNumber
                                                            , request.PageSize
                                                            , cancellationToken);
            //return result.MapToNhanVienDtoList(_mapper).ToList();
            var list = result.MapToNhanVienDtoList(_mapper);
            return PagedResult<NhanVienDto>.Create(totalCount: result.TotalCount,
                                pageCount: result.PageCount,
                                        pageSize: result.PageSize,
                                                pageNumber: result.PageNo,
                                                        data: list);
        }
    }
}
