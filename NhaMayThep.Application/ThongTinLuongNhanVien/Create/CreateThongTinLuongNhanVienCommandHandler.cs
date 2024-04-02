using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommandHandler : IRequestHandler<CreateThongTinLuongNhanVienCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;

        public CreateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
        }


        public async Task<string> Handle(CreateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
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

            var thongtins = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);
            foreach (var t in thongtins)
            {
                if (t.MaSoNhanVien == request.MaSoNhanVien && t.MaSoHopDong == request.MaSoHopDong)
                {
                    return "Mã Nhân Viên và Mã Hợp Đồng bị trùng lặp";
                }
            }

            var k = new ThongTinLuongNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                MaSoHopDong = request.MaSoHopDong,
                Loai = request.Loai,
                LuongCu = request.LuongCu,
                LuongMoi = request.LuongMoi,
                NgayHieuLuc = request.NgayHieuLuc,

                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,
            };

            _thongTinLuongNhanVienRepository.Add(k);
            return await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Mới Thành Công" : "Tạo Mới Thất Bại";
        }
    }
}
