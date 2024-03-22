using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.BangLuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.Create
{
    public class CreateBangLuongCommandHandler : IRequestHandler<CreateBangLuongCommand, string>
    {
        private IBangLuongRepository _BangLuongRepository;
        private INhanVienRepository _nhanVienRepository;
        private IKhenThuongRepository _khenThuongRepository;
        private IKyLuatRepository _kyLuatRepository;
        private IPhuCapNhanVienRepository _phuCapNhanVienRepository;
        private IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private IPhuCapCongDoanRepository _phuCapCongDoanRepository;
        private IGiamTruNhanVienRepository _giamTruNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateBangLuongCommandHandler(IBangLuongRepository BangLuongRepository, INhanVienRepository nhanVienRepository, IMucSanPhamRepository mucSanPhamRepository, ICurrentUserService currentUserService, IKhenThuongRepository khenThuongRepository, IKyLuatRepository kyLuatRepository, IPhuCapCongDoanRepository phuCapCongDoanRepository, IPhuCapNhanVienRepository phuCapNhanVienRepository, IBaoHiemNhanVienRepository baoHiemNhanVienRepository, IGiamTruNhanVienRepository giamTruNhanVienRepository)
        {
            _BangLuongRepository = BangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _khenThuongRepository = khenThuongRepository;
            _kyLuatRepository = kyLuatRepository;
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
            _phuCapCongDoanRepository = phuCapCongDoanRepository;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
            _giamTruNhanVienRepository = giamTruNhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateBangLuongCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            var checkDuplicatoion = await _BangLuongRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai Bang Luong");

            var khenThuong = await _khenThuongRepository.FindAsync(x => x.ID == request.KhenThuongID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (khenThuong == null)
                throw new NotFoundException("Khen Thưởng Id: " + request.KhenThuongID + " không tìm thấy");

            var kyLuat = await _kyLuatRepository.FindAsync(x => x.ID == request.KyLuatID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (kyLuat == null)
                throw new NotFoundException("Kỷ Luật Id: " + request.KyLuatID + " không tìm thấy");

            var phuCapNhanVien = await _phuCapNhanVienRepository.FindAsync(x => x.ID == request.PhuCapNhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (phuCapNhanVien == null)
                throw new NotFoundException("Phụ Cấp Nhân Viên Id: " + request.PhuCapNhanVienID + " không tìm thấy");

            var phuCapCongDoan = await _phuCapCongDoanRepository.FindAsync(x => x.ID == request.PhuCapCongDoanID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (phuCapCongDoan == null)
                throw new NotFoundException("Phụ Cấp Công Đoàn Id: " + request.PhuCapCongDoanID + " không tìm thấy");

            var baoHiemNhanVien = await _baoHiemNhanVienRepository.FindAsync(x => x.ID == request.BaoHiemNhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (baoHiemNhanVien == null)
                throw new NotFoundException("Bảo Hiểm Nhân Viên Id: " + request.BaoHiemNhanVienID + " không tìm thấy");

            var giamTruNhanVien = await _giamTruNhanVienRepository.FindAsync(x => x.ID == request.GiamTruNhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (giamTruNhanVien == null)
                throw new NotFoundException("Giảm Trừ Nhân Viên Id: " + request.GiamTruNhanVienID + " không tìm thấy");

            var BangLuong = new BangLuongEntity()
            {

                MaSoNhanVien = nhanVien.ID,
                NgayKhaiBao = request.NgayKhaiBao,
                LuongNghiPhep = request.LuongNghiPhep,
                LuongTangCa = request.LuongTangCa,
                KhenThuongID = request.KhenThuongID,
                KyLuatID = request.KyLuatID,
                LuongCoBan = request.LuongCoBan,
                PhuCapNhanVienID = request.PhuCapNhanVienID,
                TongNhanCoDinh = request.TongNhanCoDinh,
                NgayCong = request.NgayCong,
                TongThuNhap = request.TongThuNhap,
                LuongDongBH = request.LuongDongBH,
                BaoHiemNhanVienID = request.BaoHiemNhanVienID,
                TongBaoHiem = request.TongBaoHiem,
                PhuCapCongDoanID = request.PhuCapCongDoanID,
                GiamTruNhanVienID = request.GiamTruNhanVienID,
                TamUng = request.TamUng,
                LuongThucLanh = request.LuongThucLanh,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _BangLuongRepository.Add(BangLuong);
            return await _BangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Bảng Lương thành công" : "Tạo Bảng Lương thất bại";
        }
    }
}
