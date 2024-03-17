using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Infrastructure.Persistence;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterByHoVaTenNhanVienQueryHandler : IRequestHandler<FilterByHoVaTenNhanVienQuery, PagedResult<ChiTietBaoHiemDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public FilterByHoVaTenNhanVienQueryHandler(INhanVienRepository nhanVienRepository,IChiTietBaoHiemRepository chitietbaohiemRepository,
            IBaoHiemRepository baoHiemRepository, IMapper mapper,ApplicationDbContext context)
        {
            _baohiemRepository = baoHiemRepository;
            _mapper = mapper;
            _nhanvienRepository = nhanVienRepository;
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _context = context;
        }
        public async Task<PagedResult<ChiTietBaoHiemDto>> Handle(FilterByHoVaTenNhanVienQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ChiTietBaoHiemEntity>, IQueryable<ChiTietBaoHiemEntity>> options = query =>
            {
                query = query.Where(x => !x.NgayXoa.HasValue)
                .Include(x=> x.NhanVien).Search(x=> x.NhanVien.HoVaTen)
                .ContainingAll(request.HoVaTen.Replace(" ", "").ToLower().Split());
                return query;
            };
            var a = await _context.ChiTietBaoHiem
    .Where(x => !x.NgayXoa.HasValue)
    .Include(x => x.NhanVien)
    .Search(x => x.NhanVien.HoVaTen)
    .ContainingAll(request.HoVaTen.Replace(" ", "").ToLower().Split())
    .ToRanked()
    .ToListAsync();

            var result = await _chitietbaohiemRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            //var resultQuery = await _chitietbaohiemRepository.FindAllAsync(x=> x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);

            //var filter = resultQuery.Where(x => 
            //    array.All(y => x.NhanVien.HoVaTen.Replace(" ", "").ToLower().Contains(y.ToString())));
            var nhanviens = await _nhanvienRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.HoVaTen, cancellationToken);
            var baohiems = await _baohiemRepository.FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue, x => x.ID, x => x.Name, cancellationToken);
            //return filter.MapToChiTietBaoHiemDtoList(_mapper, nhanviens, baohiems);
            var data = result.MapToChiTietBaoHiemDtoList(_mapper, nhanviens, baohiems);
            return PagedResult<ChiTietBaoHiemDto>.Create(
               totalCount: result.TotalCount,
               pageCount: result.PageCount,
               pageSize: result.PageSize,
               pageNumber: result.PageNo,
               data: data.ToList());
        }
    }
}
