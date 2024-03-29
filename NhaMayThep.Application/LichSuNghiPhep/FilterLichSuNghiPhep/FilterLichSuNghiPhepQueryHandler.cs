using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.FilterLichSuNghiPhep
{
    public class FilterLichSuNghiPhepQueryHandler : IRequestHandler<FilterLichSuNghiPhepQuery, PagedResult<LichSuNghiPhepDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILichSuNghiPhepRepository _repository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepo;
        private readonly ILichSuNghiPhepRepository _lichSuNghiPhepRepository;
        private readonly ApplicationDbContext _context;

        public FilterLichSuNghiPhepQueryHandler(IMapper mapper,ILichSuNghiPhepRepository lichSuNghiPhepRepository, ICurrentUserService currentUserService, ILichSuNghiPhepRepository repository,ApplicationDbContext context, INhanVienRepository nhanVienRepository, ILoaiNghiPhepRepository loaiNghiPhepRepo)
        {
            _mapper = mapper;
            _repository = repository;
            _nhanVienRepository = nhanVienRepository;
            _loaiNghiPhepRepo = loaiNghiPhepRepo;
            _currentUserService = currentUserService;
            _context = context;
            _lichSuNghiPhepRepository = lichSuNghiPhepRepository;
        }

        public async Task<PagedResult<LichSuNghiPhepDto>> Handle(FilterLichSuNghiPhepQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LichSuNghiPhepNhanVienEntity>, IQueryable<LichSuNghiPhepNhanVienEntity>> options = query =>
            {
                query = query.Where(x => !x.NgayXoa.HasValue);
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Where(x => x.MaSoNhanVien == request.MaSoNhanVien);
                }
                if (!string.IsNullOrEmpty(request.TenNhanVien))
                {
                    query = query.Join(_context.NhanVien,
                                    lichsunghiphep => lichsunghiphep.MaSoNhanVien,
                                    nhanvien => nhanvien.ID,
                                    (lichsunghiphep, nhanvien) => new { LichSuNghiPhep = lichsunghiphep, NhanVien = nhanvien })
                            .Search(x => x.NhanVien.HoVaTen).Containing(request.TenNhanVien)
                            .Select(x => x.LichSuNghiPhep);
                }
                if (request.LoaiNghiPhepID != 0)
                {
                    query = query.Where(x => x.LoaiNghiPhepID == request.LoaiNghiPhepID);
                }
                if (!string.IsNullOrEmpty(request.TenLoaiNghiPhep))
                {
                    query = query.Join(_context.LoaiNghiPhep,
                            lichsunghiphep => lichsunghiphep.LoaiNghiPhepID,
                            loainghiphep => loainghiphep.ID,
                            (lichsunghiphep, loainghiphep) => new { LichSuNghiPhep = lichsunghiphep, LoaiNghiPhep = loainghiphep })
                            .Search(x => x.LoaiNghiPhep.Name).Containing(request.TenLoaiNghiPhep)
                            .Select(x => x.LichSuNghiPhep);
                }
                //if (!string.IsNullOrEmpty(request.TenNguoiDuyet))
                //{
                //    query = query.Join(_context.NhanVien,
                //                    lichsunghiphep => lichsunghiphep.MaSoNhanVien,
                //                    nhanvien => nhanvien.ID,
                //                    (lichsunghiphep, nhanvien) => new { LichSuNghiPhep = lichsunghiphep, NhanVien = nhanvien })
                //            .Search(x => x.NhanVien.HoVaTen).Containing(request.TenNhanVien)
                //            .Select(x => x.LichSuNghiPhep);
                //}
                if (request.NgayBatDau != DateTime.MinValue)
                {
                    query = query.Where(x => x.NgayTao == request.NgayBatDau);
                }
                if (request.NgayKetThuc != DateTime.MinValue)
                {
                    query = query.Where(x => x.NgayKetThuc == request.NgayKetThuc);
                }
                if (!string.IsNullOrEmpty(request.LyDo))
                {
                    query = query.Where(x => x.LyDo == request.LyDo);
                }
                return query;
            };

            var lichsunghiphep = await _lichSuNghiPhepRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!lichsunghiphep.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");
            }

            Expression<Func<LoaiNghiPhepEntity, bool>> optionsNghiPhep =
                query => lichsunghiphep.Select(x => x.LoaiNghiPhepID)
                .Any(x => query.ID == x);
            Expression<Func<NhanVienEntity, bool>> optionsNhanVien =
                query => lichsunghiphep.Select(x => x.MaSoNhanVien)
                .Any(x => query.ID == x);

            var loainghipheps = await _loaiNghiPhepRepo
                .FindAllToDictionaryAsync(optionsNghiPhep, x => x.ID, x => x.Name, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(optionsNhanVien, x => x.ID, x => x.HoVaTen, cancellationToken);

            var results = lichsunghiphep.MapToLichSuNghiPhepDtoList(_mapper, nhanviens, loainghipheps);

            return PagedResult<LichSuNghiPhepDto>.Create(
                totalCount: lichsunghiphep.TotalCount,
                pageCount: lichsunghiphep.PageCount,
                pageSize: lichsunghiphep.PageSize,
                pageNumber: lichsunghiphep.PageNo,
                data: results);
        }
    }
}
