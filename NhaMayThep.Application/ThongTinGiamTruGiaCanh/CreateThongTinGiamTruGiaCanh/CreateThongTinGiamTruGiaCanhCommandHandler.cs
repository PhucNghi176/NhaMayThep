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

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.CreateThongTinGiamTruGiaCanh
{
    public class CreateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<CreateThongTinGiamTruGiaCanhCommand, bool>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinGiamTruGiaCanhCommandHandler(
            INhanVienRepository nhanVienRepository, 
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICanCuocCongDanRepository canCuocCongDanRepository,
            ICurrentUserService currentUserService)
        {
            _nhanvienRepository = nhanVienRepository;
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<bool> Handle(CreateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanvienRepository.FindById(request.NhanVienID, cancellationToken);
            if(nhanvien == null)
            {
                throw new NotFoundException("NhanVien does not exists");
            }
            var giamtru = await _thongTinGiamTruRepository.FindById(request.MaGiamTruID, cancellationToken);
            if (giamtru == null)
            {
                throw new NotFoundException("Giamtru does not exists");
            }
            var cccd = await _canCuocCongDanRepository.FindById(request.CanCuocCongDan, cancellationToken);
            if(cccd == null)
            {
                throw new NotFoundException("Can Cuoc Cong Dan does not exists");
            }
            else
            {
                if(await _thongTinGiamTruGiaCanhRepository.FindByCanCuocCongDan(cccd.CanCuocCongDan, cancellationToken) != null)
                {
                    throw new NotFoundException("ThongTinMienTruGiaCanh with this Can Cuoc Cong Dan has exists");
                }
                var giamtrugiacanh = new ThongTinGiamTruGiaCanhEntity
                {
                    NguoiTaoID = _currentUserService.UserId ?? "0571cc1357c64e75a9907c37a366bfd3",
                    NhanVienID = nhanvien.ID,
                    MaGiamTruID = giamtru.ID,
                    NhanVien = nhanvien,
                    ThongTinGiamTru = giamtru!,
                    DiaChiLienLac = request.DiaChiLienLac,
                    QuanHeVoiNhanVien = request.QuanHeVoiNhanVien,
                    CanCuocCongDan = cccd.CanCuocCongDan,
                    NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc
                };
                _thongTinGiamTruGiaCanhRepository.Add(giamtrugiacanh);
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
