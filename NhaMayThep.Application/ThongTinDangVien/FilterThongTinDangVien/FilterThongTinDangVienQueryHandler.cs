using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Pagination;

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
                if (request.ChucVuDangID != 0)
                {
                    query = query.Where(x => x.ChucVuDang.Equals(request.ChucVuDangID));
                }
                if (request.TrinhDoChinhTriID != 0)
                {
                    query = query.Where(x => x.TrinhDoChinhTri.Equals(request.TrinhDoChinhTriID));
                }
                if (request.NgayVaoDang.HasValue)
                {
                    query = query.Where(x => x.NgayVaoDang.Date == request.NgayVaoDang.Value.Date);
                }
                if (request.CapDangVienID != 0)
                {
                    query = query.Where(x => x.CapDangVien.Equals(request.CapDangVienID));
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
