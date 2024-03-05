using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.CreateChiTietBaoHiem
{
    public class CreateChiTietBaoHiemCommandHandler : IRequestHandler<CreateChiTietBaoHiemCommand, string>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly ICurrentUserService _currentUser;
        public CreateChiTietBaoHiemCommandHandler(
            INhanVienRepository nhanVienRepository, 
            IBaoHiemRepository baoHiemRepository, 
            IChiTietBaoHiemRepository chitietbaohiemRepository,
            ICurrentUserService currentUser)
        {
            _nhanvienRepository = nhanVienRepository;
            _baohiemRepository = baoHiemRepository;
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _currentUser = currentUser;
        }
        public async Task<string> Handle(CreateChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var chechEntityExist = await _chitietbaohiemRepository.FindAsync(x => x.MaSoNhanVien.Equals(request.MaSoNhanVien), cancellationToken);
            if (chechEntityExist != null && chechEntityExist.NgayXoa == null)
            {
                throw new DuplicationException("Nhân viên này đã tồn tại chi tiết bảo hiểm");
            }
            else if (chechEntityExist != null && chechEntityExist.NgayXoa != null)
            {
                throw new DuplicationException("Chi tiết bảo hiểm của nhân viên này đã bị xóa trước đó");
            }
            var baohiem = await _baohiemRepository.FindAsync(x => x.ID.Equals(request.LoaiBaoHiem), cancellationToken);
            if (baohiem == null || baohiem.NgayXoa != null)
            {
                throw new NotFoundException("Không tồn tại loại bảo hiểm này");
            }
            var nhanvien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien), cancellationToken);
            if (nhanvien == null || nhanvien.NgayXoa != null)
            {
                throw new NotFoundException("Nhân viên không tồn tại");
            }
            var chitietbaohiem = new ChiTietBaoHiemEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiBaoHiem = request.LoaiBaoHiem,
                NgayHieuLuc = request.NgayHieuLuc,
                NgayKetThuc = request.NgayKetThuc,
                NhanVien = nhanvien,
                BaoHiem = baohiem,
                NguoiTaoID = _currentUser.UserId,
                NgayTao = DateTime.Now,
            };
            _chitietbaohiemRepository.Add(chitietbaohiem);
            return await _chitietbaohiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
