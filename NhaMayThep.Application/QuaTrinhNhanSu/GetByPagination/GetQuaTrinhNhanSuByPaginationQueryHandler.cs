using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.GetByPagination
{
    public class GetQuaTrinhNhanSuByPaginationQueryHandler : IRequestHandler<GetQuaTrinhNhanSuByPaginationQuery, PagedResult<QuaTrinhNhanSuDto>>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        private readonly IThongTinQuaTrinhNhanSuRepository _loaiQuaTrinh;
        private readonly IPhongBanRepository _phongBan;
        private readonly IChucDanhRepository _chucDanh;
        private readonly IChucVuRepository _chucVu;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetQuaTrinhNhanSuByPaginationQueryHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, IMapper mapper
            , IPhongBanRepository phongBanRepository
            , IChucDanhRepository chucDanhRepository
            , IChucVuRepository chucVuRepository
            , INhanVienRepository nhanVienRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _loaiQuaTrinh = thongTinQuaTrinhNhanSuRepository;
            _phongBan = phongBanRepository;
            _chucVu = chucVuRepository;
            _chucDanh = chucDanhRepository;
        }
        public async Task<PagedResult<QuaTrinhNhanSuDto>> Handle(GetQuaTrinhNhanSuByPaginationQuery query, CancellationToken cancellationToken)
        {           
            var list = await _quaTrinhNhanSuRepository.FindAllAsync(x => x.NgayXoa == null, query.PageNumber, query.PageSize, cancellationToken);
            var hoVaTen = await _nhanVienRepository.FindAllToDictionaryAsync(
                x => x.NgayXoa == null && list.Select(r => r.MaSoNhanVien).Equals(x.ID),
                x => x.ID,
                x => x.HoVaTen,
                cancellationToken);
            var loaiQuaTrinh = await _loaiQuaTrinh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var phongBan = await _phongBan.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucVu = await _chucVu.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucDanh = await _chucDanh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            return PagedResult<QuaTrinhNhanSuDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToQuaTrinhNhanSuDtoList(_mapper, loaiQuaTrinh, phongBan, chucVu, chucDanh, hoVaTen)
                );
        }
    }
}
