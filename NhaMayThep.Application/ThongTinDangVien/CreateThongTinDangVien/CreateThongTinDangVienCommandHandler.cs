using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMayThep.Infrastructure.Repositories.ConfigTableRepositories;
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
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, IDonViCongTacRepository donViCongTacRepository, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _donViCongTacRepository = donViCongTacRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhân Viên " + request.NhanVienID + " đã tồn tại Thông Tin Đảng Viên");

            var nhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!nhanVien)
                throw new NotFoundException("Không tìm thấy Nhân Viên");

            var donViCongTac = await _donViCongTacRepository.AnyAsync(x => x.ID == request.DonViCongTacID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (!donViCongTac)
                throw new NotFoundException("Không tìm thấy Đơn Vị Công Tác");

            var thongTinDangVien = new ThongTinDangVienEntity()
            {
                NhanVienID =request.NhanVienID,
                DonViCongTacID = request.DonViCongTacID,
                ChucVuDang = request.ChucVuDang,
                TrinhDoChinhTri = request.TrinhDoChinhTri,
                NgayVaoDang = request.NgayVaoDang,
                CapDangVien = request.CapDangVien,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _thongTinDangVienRepository.Add(thongTinDangVien);
            if (await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
