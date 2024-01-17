﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
using NhaMayThep.Application.ThongTinDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien
{
    public class UpdateChiTietDangVienCommandHandler : IRequestHandler<UpdateChiTietDangVienCommand, ChiTietDangVienDto>
    {
        private IChiTietDangVienRepository _chiTietDangVienRepository;
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateChiTietDangVienCommandHandler(IChiTietDangVienRepository chiTietDangVienRepository, IThongTinDangVienRepository thongTinDangVienRepository, IDonViCongTacRepository donViCongTacRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _chiTietDangVienRepository = chiTietDangVienRepository;
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<ChiTietDangVienDto> Handle(UpdateChiTietDangVienCommand request, CancellationToken cancellationToken)
        {

            var chiTietDangVien = await _chiTietDangVienRepository.FindAsync( x => x.ID == request.ID, cancellationToken: cancellationToken);
            if(chiTietDangVien == null)
                throw new NotFoundException("Chi Tiet Dang Vien is not found");

            var dangVien = await _thongTinDangVienRepository.FindAsync(x => x.ID == request.DangVienID, cancellationToken: cancellationToken);
            if (dangVien == null)
                throw new NotFoundException("Dang Vien is not found");

            var donViCongTac = await _donViCongTacRepository.FindAsync(x => x.ID == request.DonViCongTacID, cancellationToken: cancellationToken);
            if (donViCongTac == null)
                throw new NotFoundException("Don Vi Cong Tac is not found");

            chiTietDangVien.ThongTinDangVien = dangVien;
            chiTietDangVien.DonViCongTac = donViCongTac;
            chiTietDangVien.ChucVuDang = request.ChucVuDang;
            chiTietDangVien.TrinhDoChinhTri = request.TrinhDoChinhTri;
            chiTietDangVien.NguoiCapNhatID = _currentUserService.UserId;
            chiTietDangVien.NgayCapNhatCuoi = DateTime.Now;

            _chiTietDangVienRepository.Update(chiTietDangVien);
            await _chiTietDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return chiTietDangVien.MapToChiTietDangVienDto(_mapper);
        }
    }
}