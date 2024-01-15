using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<UpdateThongTinGiamTruGiaCanhCommand, bool>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        public UpdateThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICurrentUserService currentUserService,
            ICanCuocCongDanRepository canCuocCongDanRepository)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _currentUserService = currentUserService;
            _canCuocCongDanRepository = canCuocCongDanRepository;
        }
        public async Task<bool> Handle(UpdateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var giamtru = await _thongTinGiamTruRepository.FindById(request.MaGiamTruID, cancellationToken);
            if (giamtru == null)
            {
                throw new NotFoundException("Giamtru does not exists");
            }
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository.FindById(request.Id, cancellationToken);
            if (thongtingiamtru == null)
            {
                throw new NotFoundException("ThongTinGiamTruGiaCanh does not exists");
            }
            else
            {
                var cccd = await _canCuocCongDanRepository.FindById(request.CanCuocCongDan, cancellationToken);
                if(cccd == null)
                {
                    throw new NotFoundException($"Can Cuoc Cong Dan {request.CanCuocCongDan} does not exists");
                }
                thongtingiamtru.NguoiCapNhatID = _currentUserService.UserId ?? "0571cc1357c64e75a9907c37a366bfd3"; //Not authorize
                thongtingiamtru.NgayCapNhatCuoi = DateTime.Now;
                thongtingiamtru.MaGiamTruID = giamtru.ID;
                thongtingiamtru.ThongTinGiamTru = giamtru;
                thongtingiamtru.DiaChiLienLac = request.DiaChiLienLac ?? thongtingiamtru.DiaChiLienLac;
                thongtingiamtru.QuanHeVoiNhanVien = request.QuanHeVoiNhanVien ?? thongtingiamtru.DiaChiLienLac;
                thongtingiamtru.CanCuocCongDan = cccd.CanCuocCongDan;
                thongtingiamtru.NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc;
                _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
                var result = await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
