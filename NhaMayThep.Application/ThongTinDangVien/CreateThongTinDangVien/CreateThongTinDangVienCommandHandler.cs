using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien
{
    public class CreateThongTinDangVienCommandHandler : IRequestHandler<CreateThongTinDangVienCommand, string>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private INhanVienRepository _nhanVienRepository;
        private IDonViCongTacRepository _donViCongTacRepository;
        private IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        private IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        private IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, IDonViCongTacRepository donViCongTacRepository, IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository, IThongTinChucVuDangRepository thongTinChucVuDangRepository, IThongTinCapDangVienRepository thongTinCapDangVienRepository, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {

            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!nhanVien)
                throw new NotFoundException("Không tìm thấy Nhân Viên");

            var donViCongTac = await _donViCongTacRepository.AnyAsync(x => x.ID == request.DonViCongTacID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!donViCongTac)
                throw new NotFoundException("Không tìm thấy Đơn Vị Công Tác");

            var trinhDoChinhTri = await _thongTinTrinhDoChinhTriRepository.AnyAsync(x => x.ID == request.TrinhDoChinhTri && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!trinhDoChinhTri)
                throw new NotFoundException("Không tìm thấy Trình Độ Chính Trị");

            var chucVuDang = await _thongTinChucVuDangRepository.AnyAsync(x => x.ID == request.ChucVuDang && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!chucVuDang)
                throw new NotFoundException("Không tìm thấy Chức Vụ Đang");

            var capDangVien = await _thongTinCapDangVienRepository.AnyAsync(x => x.ID == request.CapDangVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!capDangVien)
                throw new NotFoundException("Không tìm thấy Cấp Đảng Viên");

            var thongTinDangVien = new ThongTinDangVienEntity()
            {
                NhanVienID = request.NhanVienID,
                DonViCongTacID = request.DonViCongTacID,
                ChucVuDang = request.ChucVuDang,
                TrinhDoChinhTri = request.TrinhDoChinhTri,
                NgayVaoDang = request.NgayVaoDang,
                CapDangVien = request.CapDangVien,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _thongTinDangVienRepository.Add(thongTinDangVien);
            if (await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
