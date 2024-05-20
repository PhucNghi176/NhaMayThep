using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;
using NhaMayThep.Infrastructure.Persistence;

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
                    query = query.Where(x => x.ChinhSachNhanSuID.Equals(request.ChinhSachNhanSuID));
                }
                if (!string.IsNullOrEmpty(request.TenDotKhenThuong))
                {
                    query = query.Where(x => x.TenDotKhenThuong.Contains(request.TenDotKhenThuong));
                }
                if (request.NgayKhenThuong != null)
                {
                    string format = "dd, MM, yyyy";
                    DateTime parsed;
                    if (DateTime.TryParseExact(request.NgayKhenThuong, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out parsed))
                    {
                        query = query.Where(x => x.NgayKhenThuong.Date.Equals(parsed));
                    }
                    else
                    {
                        throw new FormatException("Sai format ngày, tháng, năm");
                    }

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
            var tenNhanVien = await _nhanVienRepository.FindAllToDictionaryAsync(
               x => x.NgayXoa == null && result.Select(r => r.MaSoNhanVien).Contains(x.ID),
               x => x.ID,
               x => x.HoVaTen,
               cancellationToken);
            var chinhSachNhanSu = await _chinhSachNhanSuRepository.FindAllToDictionaryAsync(x => x.NgayXoa == null, x => x.ID, x => x.Name, cancellationToken);

            return PagedResult<KhenThuongDTO>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToKhenThuongDTOList(_mapper, chinhSachNhanSu, tenNhanVien));
        }

    }
}
