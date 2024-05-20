using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.GetByIdLoaiHoaDon
{
    public class GetByIdLoaiHoaDonQueryHandler : IRequestHandler<GetByIdLoaiHoaDonQuery, List<HoaDonCongTacNhanVienDto>>
    {
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ILoaiHoaDonRepository _loaiHoaDonRepository;

        public GetByIdLoaiHoaDonQueryHandler(IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository,
            IMapper mapper, ILoaiHoaDonRepository loaiHoaDonRepository)
        {
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _mapper = mapper;
            _loaiHoaDonRepository = loaiHoaDonRepository;
        }

        public async Task<List<HoaDonCongTacNhanVienDto>> Handle(GetByIdLoaiHoaDonQuery request, CancellationToken cancellationToken)
        {
            int idLoaiHoaDon = request.idLoaiHoaDon;
            int year = request.year;
            int month = request.month;

            var list = await _hoaDonCongTacNhanVienRepository.FindAllAsync(x =>
                (idLoaiHoaDon == 0 || x.LoaiHoaDonID == idLoaiHoaDon) &&
                (year == 0 || x.DuongDanFile.Contains($"/{year}/")) &&
                (month == 0 || x.DuongDanFile.Contains($"/{month}/"))
                && !x.NgayXoa.HasValue,
                cancellationToken);

            var exist = await _loaiHoaDonRepository.FindAsync(x => x.ID == idLoaiHoaDon && !x.NgayXoa.HasValue, cancellationToken);
            if (exist == null && idLoaiHoaDon != 0)
            {
                throw new NotFoundException("Loại Hóa Đơn trên Không tồn Tại");
            }

            if (list == null || !list.Any())
            {
                throw new NotFoundException("Không Tìm Thấy Tệp tin nào");
            }
            return list.MapToHoaDonCongTacNhanVienDtoList(_mapper);
        }
    }
}