using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetByPagination
{
    public class GetKyLuatByPaginationQueryHandler : IRequestHandler<GetKyLuatByPaginationQuery, PagedResult<KyLuatDTO>>
    {
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetKyLuatByPaginationQueryHandler(IKyLuatRepository kyLuatRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<PagedResult<KyLuatDTO>> Handle(GetKyLuatByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _kyLuatRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            List<KyLuatDTO> final = new List<KyLuatDTO>();
            foreach (var item in list)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    break;
                KyLuatDTO result = new KyLuatDTO()
                {
                    MaSoNhanVien = item.MaSoNhanVien,
                    tenNhanVien = nhanvien.HoVaTen,
                    Id = item.ID,
                    ChinhSachNhanSuID = item.ChinhSachNhanSuID,
                    TenDotKyLuat = item.TenDotKyLuat,
                    NgayKiLuat = item.NgayKiLuat,
                    TongPhat = item.TongPhat,
                };
                final.Add(result);
            }
            return PagedResult<KyLuatDTO>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: final
                );
        }
    }
}
