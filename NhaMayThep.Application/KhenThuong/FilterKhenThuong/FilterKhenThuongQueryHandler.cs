using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.KyLuat.FilterKyLuat;
using NhaMayThep.Application.KyLuat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.KhenThuong.FilterKhenThuong
{
    public class FilterKhenThuongQueryHandler : IRequestHandler<FilterKhenThuongQuery, PagedResult<KhenThuongDTO>>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly ApplicationDbContext _context;

        public FilterKhenThuongQueryHandler(IKhenThuongRepository repository, IMapper mapper, INhanVienRepository nhanVienRepository, IChinhSachNhanSuRepository chinhSachNhanSuRepository, ApplicationDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _context = context;
        }

        public async Task<PagedResult<KhenThuongDTO>> Handle(FilterKhenThuongQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<KhenThuongEntity>, IQueryable<KhenThuongEntity>> queryOptions = query =>
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
                if (!string.IsNullOrEmpty(request.TenDotKhenThuong))
                {
                    query = query.Where(x => x.TenDotKhenThuong.Contains(request.TenDotKhenThuong));
                }
                if (request.NgayKhenThuong != null)
                {
                    query = query.Where(x => x.NgayKhenThuong.Equals(request.NgayKhenThuong));
                }
                if (request.TongThuong != 0)
                {
                    query = query.Where(x => x.TongThuong.Equals(request.TongThuong));
                }
                return query;
            };

            var result = await _repository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
                throw new NotFoundException("Không tìm thấy thông tin Khen Thưởng.");
            return PagedResult<KhenThuongDTO>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToKhenThuongDTOList(_mapper));
        }

    }
}
