using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.BangLuong.Update
{
    public class UpdateBangLuongCommandHandler : IRequestHandler<UpdateBangLuongCommand, string>
    {
        private IBangLuongRepository _BangLuongRepository;
        private INhanVienRepository _nhanVienRepository;
        private IKhenThuongRepository _khenThuongRepository;
        private IKyLuatRepository _kyLuatRepository;
        private IPhuCapNhanVienRepository _phuCapNhanVienRepository;
        private IBaoHiemNhanVienRepository _baoHiemNhanVienRepository;
        private IPhuCapCongDoanRepository _phuCapCongDoanRepository;
        private IGiamTruNhanVienRepository _giamTruNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        public UpdateBangLuongCommandHandler(IBangLuongRepository BangLuongRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository, IKhenThuongRepository khenThuongRepository, IKyLuatRepository kyLuatRepository, IPhuCapCongDoanRepository phuCapCongDoanRepository, IPhuCapNhanVienRepository phuCapNhanVienRepository, IBaoHiemNhanVienRepository baoHiemNhanVienRepository, IGiamTruNhanVienRepository giamTruNhanVienRepository)
        {
            _BangLuongRepository = BangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _khenThuongRepository = khenThuongRepository;
            _kyLuatRepository = kyLuatRepository;
            _phuCapNhanVienRepository = phuCapNhanVienRepository;
            _phuCapCongDoanRepository = phuCapCongDoanRepository;
            _baoHiemNhanVienRepository = baoHiemNhanVienRepository;
            _giamTruNhanVienRepository = giamTruNhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<string> Handle(UpdateBangLuongCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            }

            var BangLuong = await _BangLuongRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (BangLuong == null)
                throw new NotFoundException($"Không tìm thấy Bảng Lương với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            var phuCapCongDoan = await _phuCapCongDoanRepository.FindAsync(x => x.ID == request.PhuCapCongDoanID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (phuCapCongDoan == null)
                throw new NotFoundException("Phụ Cấp Công Đoàn Id: " + request.PhuCapCongDoanID + " không tìm thấy");


            var giamTruNhanVien = await _giamTruNhanVienRepository.FindAsync(x => x.ID == request.GiamTruNhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (giamTruNhanVien == null)
                throw new NotFoundException("Giảm Trừ Nhân Viên Id: " + request.GiamTruNhanVienID + " không tìm thấy");

            BangLuong.NgayKhaiBao = request.NgayKhaiBao;
            BangLuong.LuongNghiPhep = request.LuongNghiPhep;
            BangLuong.LuongTangCa = request.LuongTangCa;

            BangLuong.LuongCoBan = request.LuongCoBan;

            BangLuong.TongNhanCoDinh = request.TongNhanCoDinh;
            BangLuong.NgayCong = request.NgayCong;
            BangLuong.TongThuNhap = request.TongThuNhap;
            BangLuong.LuongDongBH = request.LuongDongBH;

            BangLuong.TongBaoHiem = request.TongBaoHiem;
            BangLuong.PhuCapCongDoanID = request.PhuCapCongDoanID;
            BangLuong.GiamTruNhanVienID = request.GiamTruNhanVienID;
            BangLuong.TamUng = request.TamUng;
            BangLuong.LuongThucLanh = request.LuongThucLanh;

            BangLuong.NguoiCapNhatID = _currentUserService.UserId;
            BangLuong.NgayCapNhatCuoi = DateTime.Now;

            _BangLuongRepository.Update(BangLuong);
            return await _BangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Bảng Lương thành công" : "Cập nhật Bảng Lương thất bại";
        }
    }
}
