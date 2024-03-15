using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;
using NhaMayThep.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.ThongTinDangVien.FilterThongTinDangVien
{
    public class FilterThongTinDangVienQueryHandler : IRequestHandler<FilterThongTinDangVienQuery, PagedResult<ThongTinDangVienDto>>
    {
        private readonly IThongTinDangVienRepository _thongTinDangVienrepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly IDonViCongTacRepository _donViCongTacRepository;


        public FilterThongTinDangVienQueryHandler(IThongTinDangVienRepository thongTinDangVienrepository, INhanVienRepository nhanVienRepository, IMapper mapper, IDonViCongTacRepository donViCongTacRepository)
        {
            _thongTinDangVienrepository = thongTinDangVienrepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
        }

        public async Task<PagedResult<ThongTinDangVienDto>> Handle(FilterThongTinDangVienQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ThongTinDangVienEntity>, IQueryable<ThongTinDangVienEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);

                if (request.DonViCongTacID != 0)
                {
                    query = query.Where(x => x.DonViCongTacID.Equals(request.DonViCongTacID));
                }
                if (!string.IsNullOrEmpty(request.ChucVuDang))
                {
                    query = query.Where(x => x.ChucVuDang.Contains(request.ChucVuDang));
                }
                if (!string.IsNullOrEmpty(request.TrinhDoChinhTri))
                {
                    query = query.Where(x => x.TrinhDoChinhTri.Contains(request.TrinhDoChinhTri));
                }
                if (request.NgayVaoDang.HasValue)
                {
                    query = query.Where(x => x.NgayVaoDang.Date == request.NgayVaoDang.Value.Date);
                }
                if (!string.IsNullOrEmpty(request.CapDangVien))
                {
                    query = query.Where(x => x.CapDangVien.Contains(request.CapDangVien));
                }
                return query;
            };

            var result = await _thongTinDangVienrepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy thông tin đảng viên");

            return PagedResult<ThongTinDangVienDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToThongTinDangVienDtoList(_mapper));
        }
    }
}
