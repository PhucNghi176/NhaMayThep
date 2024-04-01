using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiemNhanVienChiTietBaoHiem.Filter
{
    public class FilterBaoHiemNhanVienChiTietBaoHiemQueryHandler : IRequestHandler<FilterBaoHiemNhanVienChiTietBaoHiemQuery, PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>>
    {
        private readonly IBaoHiemNhanVienBaoHiemChiTietRepository _baohiemNhanVienChiTienRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public FilterBaoHiemNhanVienChiTietBaoHiemQueryHandler(
            IBaoHiemNhanVienBaoHiemChiTietRepository baoHiemNhanVienBaoHiemChiTiet,
            IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _baohiemNhanVienChiTienRepository = baoHiemNhanVienBaoHiemChiTiet;
            _context = context;
        }
        public async Task<PagedResult<BaoHiemNhanVienChiTietBaoHiemDto>> Handle(FilterBaoHiemNhanVienChiTietBaoHiemQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<BaoHiemNhanVienBaoHiemChiTietEntity>, IQueryable<BaoHiemNhanVienBaoHiemChiTietEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);
                if(request.MaBaoHiemNhanVien != null)
                {
                    query = query.Where(x => x.BHNV == request.MaBaoHiemNhanVien);
                }
                if (!string.IsNullOrEmpty(request.MaBaoHiemChiTiet))
                {
                    query = query.Where(x => x.BHCT == request.MaBaoHiemChiTiet);
                }
                if (!string.IsNullOrEmpty(request.NhanVienId))
                {
                    query = query.Join(_context.BaoHiemNhanVien,
                        bhnvct => bhnvct.BHNV,
                        bhnv => bhnv.ID,
                        (bhnvct, bhnv) => new { BHNVCT = bhnvct, BHNV = bhnv })
                    .Where(x => x.BHNV.MaSoNhanVien == request.NhanVienId)
                    .Select(x => x.BHNVCT);
                }
                if (request.LoaiBaoHiem != null)
                {
                    query = query.Join(_context.ChiTietBaoHiem,
                        bhnvct => bhnvct.BHCT,
                        ctbh => ctbh.ID,
                        (bhnvct, ctbh) => new { BHNVCT = bhnvct, CTBH = ctbh })
                    .Where(x => x.CTBH.LoaiBaoHiem == request.LoaiBaoHiem)
                    .Select(x => x.BHNVCT);
                }
                return query;
            };

            var listExists = await _baohiemNhanVienChiTienRepository
                .FindAllAsync(request.PageNumber, request.PageSize, options, cancellationToken);
            if(listExists.Count() == 0)
            {
                throw new NotFoundException("Không tìm thấy bảo hiểm nào theo yêu cầu");
            }
            return listExists.MapToPagedResult(x => x.MapFullToBaoHiemNhanVienChiTietDto(_mapper));
        }
    }
}
