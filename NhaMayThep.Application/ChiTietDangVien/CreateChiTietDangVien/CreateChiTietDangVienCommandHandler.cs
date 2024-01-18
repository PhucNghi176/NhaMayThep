﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietDangVien.CreateChiTietDangVien
{
    public class CreateChiTietDangVienCommandHandler : IRequestHandler<CreateChiTietDangVienCommand, string>
    {
        private IChiTietDangVienRepository _chiTietDangVienRepository;
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateChiTietDangVienCommandHandler(IChiTietDangVienRepository chiTietDangVienRepository, IThongTinDangVienRepository thongTinDangVienRepository, IDonViCongTacRepository donViCongTacRepository, ICurrentUserService currentUserService)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateChiTietDangVienCommand request, CancellationToken cancellationToken)
        {
            var chiTietDangVienCheck = await _chiTietDangVienRepository.FindAsync(x => x.ID == request.ID || x.DangVienID == request.DangVienID, cancellationToken: cancellationToken);
            if (chiTietDangVienCheck != null )
                throw new Exception("Đã tồn tại ID " + request.ID + " hoặc Chi Tiết Về Đảng Viên " + request.DangVienID);

            var dangVien = await _thongTinDangVienRepository.FindAsync(x => x.ID == request.DangVienID, cancellationToken: cancellationToken);
            if (dangVien == null)
                throw new NotFoundException("Dang Vien is not found");

            var donViCongTac = await _donViCongTacRepository.FindAsync(x => x.ID == request.DonViCongTacID, cancellationToken: cancellationToken);
            if(donViCongTac == null)
                throw new NotFoundException("Don Vi Cong Tac is not found");

            var chiTietDangVien = new ChiTietDangVienEntity()
            {
                ID = request.ID,
                ThongTinDangVien = dangVien,
                DonViCongTac = donViCongTac,

                ChucVuDang = request.ChucVuDang,
                TrinhDoChinhTri = request.TrinhDoChinhTri,
              
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now
            };

            _chiTietDangVienRepository.Add(chiTietDangVien);
            await _chiTietDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return chiTietDangVien.ID;
        }
    }
}