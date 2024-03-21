using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Application.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Infrastructure.Persistence;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.QuaTrinhNhanSu.FilterQuaTrinhNhanSu
{
    public class FilterQuaTrinhNhanSuQueryHandler : IRequestHandler<FilterQuaTrinhNhanSuQuery, PagedResult<QuaTrinhNhanSuDto>>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IThongTinQuaTrinhNhanSuRepository _loaiQuaTrinh;
        private readonly IPhongBanRepository _phongBan;
        private readonly IChucDanhRepository _chucDanh;
        private readonly IChucVuRepository _chucVu;
        private readonly INhanVienRepository _nhanVienRepository;

        public FilterQuaTrinhNhanSuQueryHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, IMapper mapper, ApplicationDbContext context
            ,IThongTinQuaTrinhNhanSuRepository loaiQuaTrinh, IPhongBanRepository phongBan, IChucVuRepository chucVu, IChucDanhRepository chucDanh
            ,INhanVienRepository nhanVienRepository)
        {
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _context = context;
            _loaiQuaTrinh = loaiQuaTrinh;
            _phongBan = phongBan;
            _chucVu = chucVu;
            _chucDanh = chucDanh;
        }
        public async Task<PagedResult<QuaTrinhNhanSuDto>> Handle(FilterQuaTrinhNhanSuQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<QuaTrinhNhanSuEntity>, IQueryable<QuaTrinhNhanSuEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (request.NgayTao.HasValue)
                {
                    query = query.Where(x => x.NgayTao.Equals(request.NgayTao));
                }
                if (request.NgayBatDau.HasValue)
                {
                    query = query.Where(x => x.NgayBatDau.Equals(request.NgayBatDau));
                }
                if (request.NgayKetThuc.HasValue)
                {
                    query = query.Where(x => x.NgayKetThuc.Equals(request.NgayKetThuc));
                }
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Join(_context.NhanVien,
                        quaTrinhNhanSu => quaTrinhNhanSu.MaSoNhanVien,
                        nhanVien => nhanVien.ID,
                        (quaTrinhNhanSu, nhanVien) => new { QuaTrinhNhanSu = quaTrinhNhanSu, NhanVien = nhanVien })
                    .Where(x => x.NhanVien.ID.Contains(request.MaSoNhanVien) && x.NhanVien.NguoiXoaID == null)
                    .Select(x => x.QuaTrinhNhanSu);
                }
                if (request.LoaiQuaTrinhID != 0)
                {
                    query = query.Where(x => x.LoaiQuaTrinhID.Equals(request.LoaiQuaTrinhID));
                }
                if (request.ChucVuID != 0)
                {
                    query = query.Where(x => x.ChucVuID.Equals(request.ChucVuID));
                }
                if (request.ChucDanhID != 0)
                {
                    query = query.Where(x => x.ChucDanhID.Equals(request.ChucDanhID));
                }
                if (request.PhongBanID != 0)
                {
                    query = query.Where(x => x.PhongBanID.Equals(request.PhongBanID));
                }               
                return query;
            };

            var result = await _quaTrinhNhanSuRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy quá trình nhân sự nào.");
            }

            var hoVaTen = await _nhanVienRepository.FindAllToDictionaryAsync(
                x => x.NgayXoa == null && result.Select(r => r.MaSoNhanVien).Contains(x.ID),
                x => x.ID,
                x => x.HoVaTen,
                cancellationToken);
            var loaiQuaTrinh = await _loaiQuaTrinh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var phongBan = await _phongBan.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucVu = await _chucVu.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            var chucDanh = await _chucDanh.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);
            return PagedResult<QuaTrinhNhanSuDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToQuaTrinhNhanSuDtoList(_mapper, loaiQuaTrinh, phongBan, chucVu, chucDanh, hoVaTen));
        }
    }
}
