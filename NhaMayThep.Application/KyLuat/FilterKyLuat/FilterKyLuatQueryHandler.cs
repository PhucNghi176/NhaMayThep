using AutoMapper;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID;
using NhaMayThep.Application.NhanVien;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NhaMayThep.Application.KyLuat.FilterKyLuat
{
    public class FilterKyLuatQueryHandler : IRequestHandler<FilterKyLuatQuery, PagedResult<KyLuatDTO>>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly ApplicationDbContext _context;

        public FilterKyLuatQueryHandler(IKyLuatRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository, IChinhSachNhanSuRepository chinhSachNhanSuRepository, ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _context = context;
        }

        public async Task<PagedResult<KyLuatDTO>> Handle(FilterKyLuatQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<KyLuatEntity>, IQueryable<KyLuatEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.NgayXoa == null);
                if (!string.IsNullOrEmpty(request.MaSoNhanVien))
                {
                    query = query.Where(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien));
                }
                if (request.ChinhSachNhanSuID != 0)
                {
                    query = query.Where(x => x.ChinhSachNhanSu.Equals(request.ChinhSachNhanSuID));
                }
                if (!string.IsNullOrEmpty(request.TenDotKyLuat))
                {
                    query = query.Where(x => x.TenDotKyLuat.Contains(request.TenDotKyLuat));
                }
                if (request.NgayKiLuat != null)
                {
                    query = query.Where(x => x.NgayKiLuat.Equals(request.NgayKiLuat));
                }
                if (request.TongPhat != 0)
                {
                    query = query.Where(x => x.TongPhat.Equals(request.TongPhat));
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy thông tin Kỷ Luật.");
            return PagedResult<KyLuatDTO>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToTinhKyLuatDTOList(_mapper));
        }
    }
}
