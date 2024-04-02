using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMayThep.Infrastructure.Persistence;
using NinjaNye.SearchExtensions;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NhaMayThep.Application.ChiTietBaoHiem.FilterByHoVaTenNhanVien
{
    public class FilterChiTietBaoHiemQueryHandler : IRequestHandler<FilterChiTietBaoHiemQuery, PagedResult<ChiTietBaoHiemDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public FilterChiTietBaoHiemQueryHandler(INhanVienRepository nhanVienRepository,IChiTietBaoHiemRepository chitietbaohiemRepository,
            IBaoHiemRepository baoHiemRepository, IMapper mapper,ApplicationDbContext context)
        {
            _baohiemRepository = baoHiemRepository;
            _mapper = mapper;
            _nhanvienRepository = nhanVienRepository;
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _context = context;
        }
        public async Task<PagedResult<ChiTietBaoHiemDto>> Handle(FilterChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ChiTietBaoHiemEntity>, IQueryable<ChiTietBaoHiemEntity>> options = query =>
            {
                query = query.Where(x => !x.NgayXoa.HasValue && string.IsNullOrEmpty(x.NguoiXoaID));
                if (!string.IsNullOrEmpty(request.Id))
                {
                    query = query.Where(x => x.ID.Equals(request.Id));
                }
                if(request.MaBaoHiem != 0)
                {
                    query = query.Where(x => x.LoaiBaoHiem == request.MaBaoHiem);
                }
                if (!string.IsNullOrEmpty(request.TenBaohiem))
                {
                    query = query.Join(_context.BaoHiem,
                        chitietbaohiem => chitietbaohiem.LoaiBaoHiem,
                        baohiem => baohiem.ID,
                        (chitietbaohiem, baohiem) => new { ChiTietBaoHiem = chitietbaohiem, Baohiem = baohiem })
                    .Search(x=> x.Baohiem.Name).Containing(request.TenBaohiem)
                    .Select(x => x.ChiTietBaoHiem);
                }
                if (request.NgayHieuLuc.HasValue || request.NgayHieuLuc != null)
                {
                    query = query.Where(x => x.NgayHieuLuc == request.NgayHieuLuc);
                }
                if (request.NgayKetThuc.HasValue || request.NgayKetThuc != null)
                {
                    query = query.Where(x=> x.NgayKetThuc == request.NgayKetThuc);
                }
                return query;       
            };

            var listResult = await _chitietbaohiemRepository.FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if (!listResult.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin phù hợp yêu cầu");
            }
            Expression<Func<BaoHiemEntity, bool>> optionsBaohiem =
                query => listResult.Select(x => x.LoaiBaoHiem)
                .Any(x => query.ID == x);
            var baohiem = await _baohiemRepository
                .FindAllToDictionaryAsync(optionsBaohiem, x => x.ID, x => x.Name, cancellationToken);
            var results = listResult.MapToChiTietBaoHiemDtoList(_mapper, baohiem);

            return PagedResult<ChiTietBaoHiemDto>.Create(
                totalCount: listResult.TotalCount,
                pageCount: listResult.PageCount,
                pageSize: listResult.PageSize,
                pageNumber: listResult.PageNo,
                data: results);
        }
    }
}
