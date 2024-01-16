﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommandHandler : IRequestHandler<UpdateLichSuCongTacNhanVienCommand>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;

        public UpdateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, ILoaiCongTacRepository loaiCongTacRepository)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _loaiCongTacRepository = loaiCongTacRepository;
        }

        public async Task Handle(UpdateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var ct = await _loaiCongTacRepository.FindAsync(x => x.ID == request.LoaiCongTacID, cancellationToken);
            if(ct is null) 
            {
                throw new NotFoundException("Loại Công Tác trên không tồn tại");
            }
            var lichSu = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.ID, cancellationToken);
            if (lichSu is null) 
            {
                throw new NotFoundException("Lịch Sử Công Tác Của Nhân Viên không Tồn Tại");
            }
            lichSu.ID = request.ID;
            lichSu.LoaiCongTacID = request.LoaiCongTacID;
            lichSu.NgayBatDau = request.NgayBatDau;
            lichSu.NgayKetThuc = request.NgayKetThuc;
            lichSu.NoiCongTac = request.NoiCongTac;
            lichSu.LyDo = request.LyDo;

            //lichSu.NhanVien = lichSu.NhanVien;
        }
    }
}
