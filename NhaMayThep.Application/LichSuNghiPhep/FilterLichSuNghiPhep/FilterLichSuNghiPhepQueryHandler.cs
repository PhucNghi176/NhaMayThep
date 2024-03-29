using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep.Filter;
using NhaMayThep.Infrastructure.Persistence;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace NhaMayThep.Application.LichSuNghiPhep.FilterLichSuNghiPhep
{
    public class FilterLichSuNghiPhepQueryHandler : IRequestHandler<FilterLichSuNghiPhepQuery, PagedResult<LichSuNghiPhepDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FilterLichSuNghiPhepQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<LichSuNghiPhepDto>> Handle(FilterLichSuNghiPhepQuery request, CancellationToken cancellationToken)
        {
            var query = _context.LichSuNghiPhepNhanVien.AsQueryable();

            if (!string.IsNullOrEmpty(request.MaSoNhanVien))
            {
                query = query.Where(x => x.MaSoNhanVien == request.MaSoNhanVien);
            }
            if (!string.IsNullOrEmpty(request.TenNhanVien))
            {
                query = from lichSu in query
                        join nhanVien in _context.NhanVien
                        on lichSu.MaSoNhanVien equals nhanVien.ID
                        where nhanVien.HoVaTen == request.TenNhanVien // Adjust this condition as needed
                        select lichSu;
            }

            if (request.LoaiNghiPhepID.HasValue)
            {
                query = query.Where(x => x.LoaiNghiPhepID == request.LoaiNghiPhepID.Value);
            }

            if (!string.IsNullOrEmpty(request.TenLoaiNghiPhep))
            {
                query = from lichSu in query
                        join loaiNghiPhep in _context.LoaiNghiPhep
                        on lichSu.LoaiNghiPhepID equals loaiNghiPhep.ID
                        where loaiNghiPhep.Name == request.TenLoaiNghiPhep // Adjust this condition as needed
                        select lichSu;
            }

            if (request.NgayBatDau.HasValue)
            {
                query = query.Where(x => x.NgayBatDau >= request.NgayBatDau.Value);
            }

            if (request.NgayKetThuc.HasValue)
            {
                query = query.Where(x => x.NgayKetThuc <= request.NgayKetThuc.Value);
            }

            if (!string.IsNullOrEmpty(request.LyDo))
            {
                query = query.Where(x => x.LyDo.Contains(request.LyDo));
            }

            if (!string.IsNullOrEmpty(request.NguoiDuyet))
            {
                query = query.Where(x => x.NguoiDuyet == request.NguoiDuyet);
            }

            if (!string.IsNullOrEmpty(request.TenNguoiDuyet))
            {
                query = from lichSu in query
                        join nhanVien in _context.NhanVien
                        on lichSu.NguoiDuyet equals nhanVien.ID
                        where nhanVien.HoVaTen == request.TenNguoiDuyet 
                        select lichSu;
            }



            // Pagination
            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query.Skip((request.PageNumber - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .ToListAsync(cancellationToken);

            var dtos = _mapper.Map<List<LichSuNghiPhepDto>>(items);

            return new PagedResult<LichSuNghiPhepDto>
            {
                Data = dtos,
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }
    }
}