using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
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
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.NhanVienID + "da ton tai Thong Tin Dang Vien");

            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            var thongTinDangVien = new ThongTinDangVienEntity()
            {
                NhanVienID =request.NhanVienID,
                NgayVaoDang = request.NgayVaoDang,
                CapDangVien = request.CapDangVien,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _thongTinDangVienRepository.Add(thongTinDangVien);
            await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return thongTinDangVien.ID;
        }
    }
}
