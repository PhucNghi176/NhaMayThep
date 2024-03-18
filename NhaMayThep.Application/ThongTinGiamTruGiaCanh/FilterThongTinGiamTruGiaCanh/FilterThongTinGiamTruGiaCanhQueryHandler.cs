using MediatR;
using Microsoft.IdentityModel.Tokens;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;
using NhaMayThep.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NinjaNye.SearchExtensions;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Application.Common.Models;
using NhaMayThep.Application.ThongTinCongDoan;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.FilterThongTinGiamTruGiaCanh
{
    public class FilterThongTinGiamTruGiaCanhQueryHandler : IRequestHandler<FilterThongTinGiamTruGiaCanhQuery, PagedResult<ThongTinGiamTruGiaCanhDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IThongTinGiamTruGiaCanhRepository _thongtingiamtrugiacanhRepository;
        private readonly IThongTinGiamTruRepository _thongtingiamtruRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FilterThongTinGiamTruGiaCanhQueryHandler(
            INhanVienRepository nhanVienRepository,
            IThongTinGiamTruRepository thongTinGiamTru,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanh,
            ApplicationDbContext context, 
            IMapper mapper)
        {
            _thongtingiamtruRepository = thongTinGiamTru;
            _thongtingiamtrugiacanhRepository = thongTinGiamTruGiaCanh;
            _nhanvienRepository = nhanVienRepository;
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedResult<ThongTinGiamTruGiaCanhDto>> Handle(FilterThongTinGiamTruGiaCanhQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ThongTinGiamTruGiaCanhEntity>, IQueryable<ThongTinGiamTruGiaCanhEntity>> options = query =>
            {
                query = query.Where(x => !x.NgayXoa.HasValue);
                if (!string.IsNullOrEmpty(request.NhanVienID))
                {
                    query = query.Where(x => x.NhanVienID == request.NhanVienID);
                }
                if (!string.IsNullOrEmpty(request.TenNhanVien))
                {
                    query = query.Join(_context.NhanVien,
                                    thongtingiamtru => thongtingiamtru.NhanVienID,
                                    nhanvien => nhanvien.ID,
                                    (thongtingiamtru, nhanvien) => new { ThongTinGiamTru = thongtingiamtru, NhanVien = nhanvien })
                            .Search(x => x.NhanVien.HoVaTen).Containing(request.TenNhanVien)
                            .Select(x => x.ThongTinGiamTru);
                }
                if (request.MaGiamTruID != 0)
                {
                    query = query.Where(x => x.MaGiamTruID == request.MaGiamTruID);
                }
                if(!string.IsNullOrEmpty(request.TenGiamTru))
                {
                    query = query.Join(_context.ThongTinGiamTru,
                            thongtingiamtru => thongtingiamtru.MaGiamTruID,
                            giamtru => giamtru.ID,
                            (thongtingiamtru, giamtru) => new { ThongTinGiamTru = thongtingiamtru, GiamTru = giamtru })
                    .Search(x => x.GiamTru.Name).Containing(request.TenGiamTru)
                    .Select(x => x.ThongTinGiamTru);
                }
                if (!string.IsNullOrEmpty(request.CanCuocCongDan))
                {
                    query = query.Join(_context.CanCuocCongDan,
                        thongtingiamtru => thongtingiamtru.CanCuocCongDan,
                        cancuoc => cancuoc.CanCuocCongDan,
                        (thongtingiamtru, cancuoc) => new { ThongTinGiamTru = thongtingiamtru, CanCuoc = cancuoc })
                    .Where(x => x.CanCuoc.CanCuocCongDan == request.CanCuocCongDan)
                    .Select(x => x.ThongTinGiamTru);
                }
                if(request.NgayTao.HasValue)
                {
                    query = query.Where(x=> x.NgayTao == request.NgayTao);
                }
                if (request.NgayXacNhanPhuThuoc.HasValue)
                {
                    query = query.Where(x => x.NgayXacNhanPhuThuoc == request.NgayXacNhanPhuThuoc);
                }
                return query;
            };

            var giamtrugiacanh = await _thongtingiamtrugiacanhRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!giamtrugiacanh.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");
            }
            //need to confirm
            //Expression<Func<ThongTinGiamTruEntity, bool>> optionsGiamTru = 
            //    query => giamtrugiacanh.Select(x => x.MaGiamTruID)
            //    .Any(x => query.ID == x) && !query.NgayXoa.HasValue;
            //Expression<Func<NhanVienEntity, bool>> optionsNhanVien = 
            //    query => giamtrugiacanh.Select(x => x.NhanVienID)
            //    .Any(x => query.ID == x) && !query.NgayXoa.HasValue;

            Expression<Func<ThongTinGiamTruEntity, bool>> optionsGiamTru =
                query => giamtrugiacanh.Select(x => x.MaGiamTruID)
                .Any(x => query.ID == x);
            Expression<Func<NhanVienEntity, bool>> optionsNhanVien =
                query => giamtrugiacanh.Select(x => x.NhanVienID)
                .Any(x => query.ID == x);

            var thongtingiamtrus = await _thongtingiamtruRepository
              .FindAllToDictionaryAsync(optionsGiamTru, x => x.ID, x => x.Name, cancellationToken);
            var nhanviens = await _nhanvienRepository
                .FindAllToDictionaryAsync(optionsNhanVien, x => x.ID, x => x.HoVaTen, cancellationToken);

            var results = giamtrugiacanh.MapToThongTinGiamTruGiaCanhDtoList(_mapper, nhanviens, thongtingiamtrus);

            //return giamtrugiacanh.MapToPagedResult(
            //    x => x.MapToThongTinGiamTruGiaCanhDto(_mapper,
            //    nhanviens.FirstOrDefault(y=> y.Key == x.NhanVienID).Value.ToString() ??"Trống",
            //    thongtingiamtrus.FirstOrDefault(y=> y.Key == x.MaGiamTruID).Value.ToString() ??"Trống"));
            return PagedResult<ThongTinGiamTruGiaCanhDto>.Create(
                totalCount: giamtrugiacanh.TotalCount,
                pageCount: giamtrugiacanh.PageCount,
                pageSize: giamtrugiacanh.PageSize,
                pageNumber: giamtrugiacanh.PageNo,
                data: results);
        }
    }
}
