using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;

namespace NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu
{
    public class UpdateQuaTrinhNhanSuCommandHandler : IRequestHandler<UpdateQuaTrinhNhanSuCommand, string>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IChucVuRepository _chucVuRepository;
        IChucDanhRepository _chucDanhRepository;
        IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSu;
        IPhongBanRepository _phongBanRepository;
        INhanVienRepository _nhanVienRepository;
        ICurrentUserService _currentUserService;
        public UpdateQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IChucVuRepository chucVuRepository
            , IChucDanhRepository chucDanhRepository
            , IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository
            , IPhongBanRepository phongBanRepository
            , INhanVienRepository nhanVienRepository
            , ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
            _chucVuRepository = chucVuRepository;
            _chucDanhRepository = chucDanhRepository;
            _thongTinQuaTrinhNhanSu = thongTinQuaTrinhNhanSuRepository;
            _phongBanRepository = phongBanRepository;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }
        public async Task<string> Handle(UpdateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _quaTrinhNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Quá trình nhân viên: " + command.ID + " không tồn tại");
            }

            var existPhongBan = await _phongBanRepository.AnyAsync(x => x.ID == command.PhongBanID && x.NguoiXoaID == null);
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

            var isExistNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == entity.MaSoNhanVien, cancellationToken);
            var duplicateEntity = await _quaTrinhNhanSuRepository.AnyAsync(x => x.PhongBanID == command.PhongBanID
                                                                            && x.ChucVuID == command.ChucVuID
                                                                            && x.ChucDanhID == command.ChucDanhID
                                                                            && x.LoaiQuaTrinhID == command.LoaiQuaTrinhID
                                                                            && isExistNhanVien
                                                                            && x.NgayXoa == null);
            if (duplicateEntity)
            {
                throw new DuplicateNameException("Đã tồn tại quá trình làm việc được nhập của nhân viên này");
            }

            entity.NguoiCapNhatID = _currentUserService.UserId;
            entity.NgayCapNhatCuoi = DateTime.UtcNow;
            entity.ChucDanhID = command.ChucDanhID;
            entity.ChucVuID = command.ChucVuID;
            entity.LoaiQuaTrinhID = command.LoaiQuaTrinhID;
            entity.GhiChu = command.GhiChu;
            entity.NgayBatDau = command.NgayBatDau;
            entity.NgayKetThuc = command.NgayKetThuc;
            entity.PhongBanID = command.PhongBanID;
            _quaTrinhNhanSuRepository.Update(entity);           
            return await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
