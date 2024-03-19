using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using NhaMayThep.Infrastructure.Persistence;
using NinjaNye.SearchExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.FilterThonTinCongDoan
{
    public class FilterThongTinCongDoanQueryHandler : IRequestHandler<FilterThongTinCongDoanQuery, PagedResult<ThongTinCongDoanDto>>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IThongTinCongDoanRepository _thongtincongdoanRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public FilterThongTinCongDoanQueryHandler(
            INhanVienRepository nhanVienRepository,
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            ApplicationDbContext context,
            IMapper mapper)
        {
            _nhanvienRepository = nhanVienRepository;
            _thongtincongdoanRepository = thongTinCongDoanRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<ThongTinCongDoanDto>> Handle(FilterThongTinCongDoanQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ThongTinCongDoanEntity>, IQueryable<ThongTinCongDoanEntity>> options = query =>
            {
                query = query.Where(x => string.IsNullOrEmpty(x.NguoiXoaID) && !x.NgayXoa.HasValue);
                if (!string.IsNullOrEmpty(request.Id))
                {
                    query = query.Where(x=> x.ID.Equals(request.Id));
                }
                if(!string.IsNullOrEmpty(request.NhanVienId))
                {
                    query = query.Where(x => x.NhanVienID.Equals(request.NhanVienId));
                }
                if (!string.IsNullOrEmpty(request.TenNhanVien))
                {
                    query = query.Join(_context.NhanVien,
                        thongtincongdoan => thongtincongdoan.NhanVienID,
                        nhanvien => nhanvien.ID,
                        (thongtincongdoan, nhanvien) => new { ConDoan = thongtincongdoan, NhanVien = nhanvien })
                    .Search(x=> x.NhanVien.HoVaTen).Containing(request.TenNhanVien)
                    .Select(x => x.ConDoan);
                }
                if (request.NgayGiaNhap.HasValue)
                {
                    query = query.Where(x=> x.NgayGiaNhap == request.NgayGiaNhap);
                }
                    return query;
            };

            var listResult= await _thongtincongdoanRepository.FindAllAsync(request.PageNumber,request.PageSize,options,cancellationToken);
            if (!listResult.Any())
            {
                throw new NotFoundException("Không tìm thấy thông tin công đoàn nào phù hợp với yêu cầu");
            }
            //need to confirm
            //Expression<Func<NhanVienEntity, bool>> optionsNhanVien = 
            //    query => listResult.Select(x=> x.NhanVienID)
            //    .Any(x => query.ID == x) && !query.NgayXoa.HasValue;
            Expression<Func<NhanVienEntity, bool>> optionsNhanVien =
                query => listResult.Select(x => x.NhanVienID)
                .Any(x => query.ID == x);

            var listNhanVien = await _nhanvienRepository.FindAllToDictionaryAsync(optionsNhanVien, x => x.ID, x => x.HoVaTen, cancellationToken);

            var result = listResult.MapToThongTinCongDoanDtoList(_mapper, listNhanVien);

            return PagedResult<ThongTinCongDoanDto>.Create(
                totalCount: listResult.TotalCount,
                pageCount: listResult.PageCount,
                pageSize: listResult.PageSize,
                pageNumber: listResult.PageNo,
                data: result);
            //return listResult.MapToPagedResult(x => x.MapToThongTinCongDoanDto(_mapper,
            //    listNhanVien.FirstOrDefault(y => y.Key == x.NhanVienID).Value.ToString() ?? "")); 
        }
    }
}
