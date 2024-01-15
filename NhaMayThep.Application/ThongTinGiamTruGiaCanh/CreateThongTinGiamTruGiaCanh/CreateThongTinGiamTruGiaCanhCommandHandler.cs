using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
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
        public CreateThongTinGiamTruGiaCanhCommandHandler(
            INhanVienRepository nhanVienRepository, 
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository)
        {
            _nhanvienRepository = nhanVienRepository;
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
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
            var giamtrugiacanh = new ThongTinGiamTruGiaCanhEntity
            {
                NhanVienID = nhanvien.ID,
                MaGiamTruID = giamtru.ID,
                NhanVien = nhanvien,
                ThongTinGiamTru = giamtru!,
                DiaChiLienLac = request.DiaChiLienLac,
                QuanHeVoiNhanVien = request.QuanHeVoiNhanVien,
                CanCuocCongDan = request.CanCuocCongDan,
                NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc
            };
            _thongTinGiamTruGiaCanhRepository.Add(giamtrugiacanh);
            var result= await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
