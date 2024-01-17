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
    public class CreateQuaTrinhNhanSuCommandHandler : IRequestHandler<CreateQuaTrinhNhanSuCommand, bool>
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

        public async Task<bool> Handle(CreateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var existPhongBan = await _phongBanRepository.FindAsync(x => x.ID == command.PhongBanID && x.NguoiXoaID == null);
            if (existPhongBan == null)
            {
                throw new NotFoundException("ID phòng ban: " + command.PhongBanID + " không tồn tại");
            }

            var existChucVu = await _chucVuRepository.FindAsync(x => x.ID == command.ChucVuID && x.NguoiXoaID == null);
            if (existChucVu == null)
            {
                throw new NotFoundException("ID chức vụ: " + command.ChucVuID + " không tồn tại");
            }

            var existChucDanh = await _chucDanhRepository.FindAsync(x => x.ID == command.ChucDanhID && x.NguoiXoaID == null);
            if (existChucDanh == null)
            {
                throw new NotFoundException("ID chức danh: " + command.ChucDanhID + " không tồn tại");
            }

            var existLoaiQuaTrinh = await _thongTinQuaTrinhNhanSu.FindAsync(x => x.ID == command.LoaiQuaTrinhID && x.NguoiXoaID == null);
            if (existLoaiQuaTrinh == null)
            {
                throw new NotFoundException("ID loại quá trình: " + command.LoaiQuaTrinhID + " không tồn tại");
            }

            var existNhanVien = await _nhanVienRepository.FindAsync(x => x.ID == command.MaSoNhanVien && x.NguoiXoaID == null);
            if (existNhanVien == null)
            {
                throw new NotFoundException("Mã số nhân viên: " + command.MaSoNhanVien + " không tồn tại");
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
            return await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
