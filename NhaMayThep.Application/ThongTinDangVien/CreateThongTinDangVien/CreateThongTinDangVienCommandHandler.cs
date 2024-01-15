using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinDangVien.CreateThongTinDangVien
{
    public class CreateThongTinDangVienCommandHandler : IRequestHandler<CreateThongTinDangVienCommand, string>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private INhanVienRepository _nhanVienRepository;
        public CreateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<string> Handle(CreateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.NhanVienID, cancellationToken: cancellationToken);

            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            var thongTinDangVien = new ThongTinDangVienEntity()
            {
                ID = request.ID,
                NhanVienID =nhanVien.ID,
                NhanVien = nhanVien,
                NgayVaoDang = request.NgayVaoDang,
                CapDangVien = request.CapDangVien,
                NguoiTaoID = request.NguoiTaoID,
                NgayTao = DateTime.Today
            };

            _thongTinDangVienRepository.Add(thongTinDangVien);
            await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return thongTinDangVien.ID;
        }
    }
}
