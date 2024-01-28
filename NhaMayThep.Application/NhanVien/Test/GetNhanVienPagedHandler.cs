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

namespace NhaMayThep.Application.NhanVien.Test
{
    public class GetNhanVienPagedHandler : IRequestHandler<GetNhanVienPaged, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly IChucDanhRepository chucDanhRepository;
        private readonly IChucVuRepository chucVuRepository;

        public GetNhanVienPagedHandler(INhanVienRepository nhanVienRepository, IMapper mapper, IChucDanhRepository chucDanhRepository, IChucVuRepository chucVuRepository)
        {
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            this.chucDanhRepository = chucDanhRepository;
            this.chucVuRepository = chucVuRepository;
        }
        public async Task<PagedResult<NhanVienDto>> Handle(GetNhanVienPaged request, CancellationToken cancellationToken)
        {
            var nv = await _nhanVienRepository.FindAllAsync(x => x.NgayXoa == null, request.PageNumber, request.PageSize, cancellationToken);
            return PagedResult<NhanVienDto>.Create(totalCount: nv.TotalCount,
                                                                  pageCount: nv.PageCount,
                                                                                                                    pageSize: nv.PageSize,
                                                                                                                                                                      pageNumber: nv.PageNo,
                                                                                                                                                                                                                        data: nv.Select(x => x.MapToNhanVienDto(_mapper)).ToList());
        }
    }
}
