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
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.LichSuNghiPhep.FilterLichSuNghiPhep
{
    public class FilterLichSuNghiPhepQueryHandler : IRequestHandler<FilterLichSuNghiPhepQuery, PagedResult<LichSuNghiPhepDto>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILichSuNghiPhepRepository _repository;

        public FilterLichSuNghiPhepQueryHandler(ApplicationDbContext context, IMapper mapper, ILichSuNghiPhepRepository repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResult<LichSuNghiPhepDto>> Handle(FilterLichSuNghiPhepQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<LichSuNghiPhepNhanVienEntity>, IQueryable<LichSuNghiPhepNhanVienEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Where(x => x.MaSoNhanVien.Contains(request.MaSoNhanVien));
                }
                if (!string.IsNullOrEmpty(request.TenNhanVien))
                {
                    query = from lichSu in query
                            join nhanVien in _context.NhanVien
                            on lichSu.MaSoNhanVien equals nhanVien.ID
                            where nhanVien.HoVaTen == request.TenNhanVien // Adjust this condition as needed
                            select lichSu;
                }
                if (request.LoaiNghiPhepID!=0)
                {
                    query = query.Where(x => x.LoaiNghiPhepID == request.LoaiNghiPhepID.Value);
                }

                if (request.NgayBatDau.HasValue)
                {
                    query = query.Where(x => x.NgayBatDau == request.NgayBatDau.Value);
                }

                if (request.NgayKetThuc.HasValue)
                {
                    query = query.Where(x => x.NgayKetThuc == request.NgayKetThuc.Value);
                }

                if (!string.IsNullOrEmpty(request.LyDo))
                {
                    query = query.Where(x => x.LyDo.Contains(request.LyDo));
                }

                if (!string.IsNullOrEmpty(request.NguoiDuyet))
                {
                    query = query.Where(x => x.NguoiDuyet.Contains(request.NguoiDuyet));
                }

                if (!string.IsNullOrEmpty(request.TenNguoiDuyet))
                {
                    query = from lichSu in query
                            join nhanVien in _context.NhanVien
                            on lichSu.NguoiDuyet equals nhanVien.ID
                            where nhanVien.HoVaTen.Contains(request.TenNguoiDuyet)
                            select lichSu;
                }

                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy nhân viên.");

            return PagedResult<LichSuNghiPhepDto>.Create(

               totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToLichSuNghiPhepDtoList(_mapper)

            );
        }
    }
}