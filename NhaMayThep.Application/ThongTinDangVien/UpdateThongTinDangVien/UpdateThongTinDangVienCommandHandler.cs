using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommandHandler : IRequestHandler<UpdateThongTinDangVienCommand, string>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private INhanVienRepository _nhanVienRepository;
        private IDonViCongTacRepository _donViCongTacRepository;
        private IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        private IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        private IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, IDonViCongTacRepository donViCongTacRepository, IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository, IThongTinChucVuDangRepository thongTinChucVuDangRepository, IThongTinCapDangVienRepository thongTinCapDangVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {


            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.ID == request.ID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (thongTinDangVien == null)
                throw new NotFoundException("Không tìm thấy Đảng Viên");


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

            thongTinDangVien.DonViCongTacID = request.DonViCongTacID;
            thongTinDangVien.ChucVuDang = request.ChucVuDang;
            thongTinDangVien.TrinhDoChinhTri = request.TrinhDoChinhTri;
            thongTinDangVien.NgayVaoDang = request.NgayVaoDang;
            thongTinDangVien.CapDangVien = request.CapDangVien;
            thongTinDangVien.NguoiCapNhatID = _currentUserService.UserId;
            thongTinDangVien.NgayCapNhatCuoi = DateTime.Now;

            _thongTinDangVienRepository.Update(thongTinDangVien);
            if (await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
