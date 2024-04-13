using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien
{
    public class UpdateThongTinCapDangVienCommandHandler : IRequestHandler<UpdateThongTinCapDangVienCommand, string>
    {
        private readonly IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinCapDangVienCommandHandler(IThongTinCapDangVienRepository thongTinCapDangVienRepository, ICurrentUserService currentUserService)
        {
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinCapDangVienCommand request, CancellationToken cancellationToken)
        {
            var thongTinCapDangVien = await _thongTinCapDangVienRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinCapDangVien == null || (thongTinCapDangVien.NguoiXoaID != null && thongTinCapDangVien.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin cấp đảng viên không tồn tại hoặc đã bị vô hiệu hóa");
            }

            var checkDuplicatoion = await _thongTinCapDangVienRepository.AnyAsync(x => x.Name == request.TenCapDangVien && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Tên cấp đảng viên đã tồn tại");

            thongTinCapDangVien.Name = request.TenCapDangVien;
            thongTinCapDangVien.CapDangVien = request.CapDangVien;
            thongTinCapDangVien.NguoiCapNhatID = _currentUserService.UserId;
            thongTinCapDangVien.NgayCapNhat = DateTime.Now;
            _thongTinCapDangVienRepository.Update(thongTinCapDangVien);
            if (await _thongTinCapDangVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
