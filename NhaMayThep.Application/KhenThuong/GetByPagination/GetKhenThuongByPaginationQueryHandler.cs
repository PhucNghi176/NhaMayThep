using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetByPagination
{
    public class GetKhenThuongByPaginationQueryHandler : IRequestHandler<GetKhenThuongByPaginationQuery, PagedResult<KhenThuongDTO>>
    {
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _kanVienRepository;
        public GetKhenThuongByPaginationQueryHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper, INhanVienRepository kanVienRepository)
        {
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
            _kanVienRepository = kanVienRepository;
        }
        public async Task<PagedResult<KhenThuongDTO>> Handle(GetKhenThuongByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _khenThuongRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            List<KhenThuongDTO> final = new List<KhenThuongDTO>();
            foreach (var item in list)
            {
                var nhanvien = await this._kanVienRepository.FindAsync(x => x.ID.Equals(item.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    break;
                KhenThuongDTO result = new KhenThuongDTO()
                {
                    MaSoNhanVien = item.MaSoNhanVien,
                    TenNhanVien = nhanvien.HoVaTen,
                    ID = item.ID,
                    ChinhSachNhanSuID = item.ChinhSachNhanSuID,
                    TenDotKhenThuong = item.TenDotKhenThuong,
                    NgayKhenThuong = item.NgayKhenThuong,
                    TongThuong = item.TongThuong,
                };
                final.Add(result);
            }
            return PagedResult<KhenThuongDTO>.Create
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
