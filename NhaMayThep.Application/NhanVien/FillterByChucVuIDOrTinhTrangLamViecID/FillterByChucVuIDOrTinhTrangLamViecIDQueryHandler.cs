using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID
{
    public class FillterByChucVuIDOrTinhTrangLamViecIDQueryHandler : IRequestHandler<FillterByChucVuIDOrTinhTrangLamViecIDQuery, PagedResult<NhanVienDto>>
    {
        private readonly INhanVienRepository _repository;
        private readonly IMapper _mapper;
        public FillterByChucVuIDOrTinhTrangLamViecIDQueryHandler(INhanVienRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public FillterByChucVuIDOrTinhTrangLamViecIDQueryHandler() { }
        public async Task<PagedResult<NhanVienDto>> Handle(FillterByChucVuIDOrTinhTrangLamViecIDQuery request, CancellationToken cancellationToken)
        {
            if(request.chucvuID != 0 && request.tinhtranglamviecID != 0)
            {
                var result1 = await this._repository.FindAllAsync(x => (x.ChucVuID.Equals(request.chucvuID) && x.TinhTrangLamViecID.Equals(request.tinhtranglamviecID)) && x.NgayXoa == null
                                                                , request.no
                                                                , request.pageSize
                                                                , cancellationToken);
                if (result1.Count() == 0)
                    throw new NotFoundException("Không tìm thấy nhân viên.");
                var list1 = result1.MapToNhanVienDtoList(_mapper);
                return PagedResult<NhanVienDto>.Create(totalCount: result1.TotalCount,
                                   pageCount: result1.PageCount,
                                           pageSize: result1.PageSize,
                                                   pageNumber: result1.PageNo,
                                                           data: list1);
            }
            //List<NhanVienEntity> result = new List<NhanVienEntity>();
            var result = await this._repository.FindAllAsync(x => (x.ChucVuID.Equals(request.chucvuID) || x.TinhTrangLamViecID.Equals(request.tinhtranglamviecID)) && x.NgayXoa == null 
                                                                , request.no
                                                                , request.pageSize
                                                                , cancellationToken);
            if (result.Count() == 0)
                throw new NotFoundException("Không tìm thấy nhân viên.");
            var list = result.MapToNhanVienDtoList(_mapper);
            return PagedResult<NhanVienDto>.Create(totalCount: result.TotalCount,
                               pageCount: result.PageCount,
                                       pageSize: result.PageSize,
                                               pageNumber: result.PageNo,
                                                       data: list);
        }
    }
}
