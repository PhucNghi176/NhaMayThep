using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommandHandler : IRequestHandler<CreateQuaTrinhNhanSuCommand, string>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IChucDanhRepository chucDanhRepository
            , IChucVuRepository chucVuRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository
            , IPhongBanRepository phongBanRepository
            , INhanVienRepository nhanVienRepository
            , ICurrentUserService currentUserService)
        {
            _chucDanhRepository = chucDanhRepository;
            _chucVuRepository = chucVuRepository;
            _nhanVienRepository = nhanVienRepository;
            _phongBanRepository = phongBanRepository;
            _thongTinQuaTrinhNhanSu = thongTinQuaTrinhNhanSuRepository;
            _currentUserService = currentUserService;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }

        public async Task<string> Handle(CreateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var existPhongBan = await _phongBanRepository.AnyAsync(x => x.ID == command.PhongBanID && x.NguoiXoaID == null, cancellationToken);
            if (!existPhongBan)
            {
                throw new NotFoundException("ID phòng ban: " + command.PhongBanID + " không tồn tại");
            }

            var existChucVu = await _chucVuRepository.AnyAsync(x => x.ID == command.ChucVuID && x.NguoiXoaID == null, cancellationToken);
            if (!existChucVu)
            {
                throw new NotFoundException("ID chức vụ: " + command.ChucVuID + " không tồn tại");
            }

            var existChucDanh = await _chucDanhRepository.AnyAsync(x => x.ID == command.ChucDanhID && x.NguoiXoaID == null, cancellationToken);
            if (!existChucDanh)
            {
                throw new NotFoundException("ID chức danh: " + command.ChucDanhID + " không tồn tại");
            }

            var existLoaiQuaTrinh = await _thongTinQuaTrinhNhanSu.AnyAsync(x => x.ID == command.LoaiQuaTrinhID && x.NguoiXoaID == null, cancellationToken);
            if (!existLoaiQuaTrinh)
            {
                throw new NotFoundException("ID loại quá trình: " + command.LoaiQuaTrinhID + " không tồn tại");
            }

            var existNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == command.MaSoNhanVien && x.NguoiXoaID == null, cancellationToken);
            if (!existNhanVien)
            {
                throw new NotFoundException("Mã số nhân viên: " + command.MaSoNhanVien + " không tồn tại");
            }

            var duplicateEntity = await _quaTrinhNhanSuRepository.AnyAsync(x => x.PhongBanID == command.PhongBanID
                                                                            && x.ChucVuID == command.ChucVuID
                                                                            && x.ChucDanhID == command.ChucDanhID
                                                                            && x.LoaiQuaTrinhID == command.LoaiQuaTrinhID
                                                                            && x.MaSoNhanVien == command.MaSoNhanVien
                                                                            
                                                                            && x.NguoiXoaID == null, cancellationToken);
            if (duplicateEntity)
            {
                throw new DuplicationException("Đã tồn tại quá trình làm việc được nhập của nhân viên này");
            }

            QuaTrinhNhanSuEntity entity = new()
            {
                LoaiQuaTrinhID = command.LoaiQuaTrinhID,
                MaSoNhanVien = command.MaSoNhanVien,
                NgayBatDau = command.NgayBatDau,
                ChucDanhID = command.ChucDanhID,
                ChucVuID = command.ChucVuID,
                PhongBanID = command.PhongBanID,
                NgayKetThuc = command.NgayKetThuc,
                GhiChu = command.GhiChu,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = _currentUserService.UserId,
            };
            _quaTrinhNhanSuRepository.Add(entity);
            return await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
