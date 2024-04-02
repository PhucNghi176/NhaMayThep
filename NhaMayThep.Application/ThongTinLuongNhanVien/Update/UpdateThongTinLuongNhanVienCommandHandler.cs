using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandHandler : IRequestHandler<UpdateThongTinLuongNhanVienCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;

        public UpdateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
        }


        public async Task<string> Handle(UpdateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var thongtin = await _thongTinLuongNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (thongtin == null || thongtin.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Thông Tin Trên Không Tồn Tại");
            }
            bool nhanvienExist = await _nhanVienRepository.AnyAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);

            if (!nhanvienExist)
            {
                return "Mã Nhân Viên không tồn tại";
            }

            bool hopdongExist = await _hopDongRepository.AnyAsync(x => x.ID == request.MaSoHopDong, cancellationToken);

            if (!hopdongExist)
            {
                return "Mã Hợp Đồng không tồn tại";
            }


            
            thongtin.MaSoNhanVien = request.MaSoNhanVien;
            thongtin.MaSoHopDong = request.MaSoHopDong;
            thongtin.Loai = request.Loai;
            thongtin.LuongCu = request.LuongCu;
            thongtin.LuongMoi = request.LuongMoi;
            thongtin.NgayHieuLuc = request.NgayHieuLuc;

            thongtin.NguoiCapNhatID = _currentUserService.UserId;
            thongtin.NgayCapNhatCuoi = DateTime.Now;

            _thongTinLuongNhanVienRepository.Update(thongtin);
            return await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập Nhật Thành Công" : "Cập Nhật Thất Bại";

        }
    }
}
