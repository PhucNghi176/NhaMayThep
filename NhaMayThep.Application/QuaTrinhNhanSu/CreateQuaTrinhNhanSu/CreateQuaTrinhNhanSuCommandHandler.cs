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
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IChucVuRepository _chucVuRepository;
        IChucDanhRepository _chucDanhRepository;
        IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;
        ICurrentUserService _currentUserService;
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
            if (existPhongBan == false)
            {
                throw new NotFoundException("ID phòng ban: " + command.PhongBanID + " không tồn tại");
            }

            var existChucVu = await _chucVuRepository.AnyAsync(x => x.ID == command.ChucVuID && x.NguoiXoaID == null);
            if (existChucVu == false)
            {
                throw new NotFoundException("ID chức vụ: " + command.ChucVuID + " không tồn tại");
            }

            var existChucDanh = await _chucDanhRepository.AnyAsync(x => x.ID == command.ChucDanhID && x.NguoiXoaID == null);
            if (existChucDanh == false)
            {
                throw new NotFoundException("ID chức danh: " + command.ChucDanhID + " không tồn tại");
            }

            var existLoaiQuaTrinh = await _thongTinQuaTrinhNhanSu.AnyAsync(x => x.ID == command.LoaiQuaTrinhID && x.NguoiXoaID == null);
            if (existLoaiQuaTrinh == false)
            {
                throw new NotFoundException("ID loại quá trình: " + command.LoaiQuaTrinhID + " không tồn tại");
            }

            var existNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == command.MaSoNhanVien && x.NguoiXoaID == null);
            if (existNhanVien == false)
            {
                throw new NotFoundException("Mã số nhân viên: " + command.MaSoNhanVien + " không tồn tại");
            }

            var duplicateEntity = await _quaTrinhNhanSuRepository.AnyAsync(x => x.PhongBanID == command.PhongBanID
                                                                            && x.ChucVuID == command.ChucVuID
                                                                            && x.ChucDanhID == command.ChucDanhID
                                                                            && x.LoaiQuaTrinhID == command.LoaiQuaTrinhID
                                                                            && x.NguoiXoaID == null);
            if (duplicateEntity)
            {
                throw new DuplicateNameException("Đã tồn tại quá trình làm việc được nhập của nhân viên này");
            }

            QuaTrinhNhanSuEntity entity = new QuaTrinhNhanSuEntity()
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
