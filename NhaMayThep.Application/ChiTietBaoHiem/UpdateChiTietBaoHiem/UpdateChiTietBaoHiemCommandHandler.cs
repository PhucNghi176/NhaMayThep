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

namespace NhaMayThep.Application.ChiTietBaoHiem.UpdateChiTietBaoHiem
{
    public class UpdateChiTietBaoHiemCommandHandler : IRequestHandler<UpdateChiTietBaoHiemCommand, string>
    {
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IBaoHiemRepository _baohiemRepository;
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly ICurrentUserService _currentUser;
        public UpdateChiTietBaoHiemCommandHandler(
            INhanVienRepository nhanVienRepository,
            IBaoHiemRepository baoHiemRepository,
            IChiTietBaoHiemRepository chiTietBaoHiemRepository,
            ICurrentUserService currentUser)
        {
            _nhanvienRepository = nhanVienRepository;
            _baohiemRepository = baoHiemRepository;
            _chitietbaohiemRepository = chiTietBaoHiemRepository;
            _currentUser = currentUser; 
        }
        public async Task<string> Handle(UpdateChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkEntityExists = await _chitietbaohiemRepository.FindAsync(x => x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);
            if(checkEntityExists == null)
            {
                throw new NotFoundException($"Không tồn tại chi tiết bảo hiểm với Id '{request.Id}'");
            }
            if(request.MaSoNhanVien != null)
            {
                var nhanvien = await _nhanvienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && !x.NgayXoa.HasValue, cancellationToken);
                if(nhanvien == null)
                {
                    throw new NotFoundException($"Nhân viên với Id '{request.MaSoNhanVien}' không tồn tại");
                }
                else
                {
                    checkEntityExists.MaSoNhanVien = nhanvien?.ID ?? checkEntityExists.MaSoNhanVien;
                    checkEntityExists.NhanVien = nhanvien ?? checkEntityExists.NhanVien;
                }
            }
            if(request.LoaiBaoHiem != null)
            {
                var baohiem = await _baohiemRepository.FindAsync(x => x.ID == request.LoaiBaoHiem && !x.NgayXoa.HasValue, cancellationToken);
                if(baohiem == null)
                {
                    throw new NotFoundException($"Bảo hiểm với Id '{request.LoaiBaoHiem}' không tồn tại");
                }
                else
                {
                    checkEntityExists.LoaiBaoHiem = baohiem?.ID ?? checkEntityExists.LoaiBaoHiem;
                    checkEntityExists.BaoHiem = baohiem ?? checkEntityExists.BaoHiem;
                }
            }
            checkEntityExists.NgayHieuLuc = request.NgayHieuLuc ?? checkEntityExists.NgayHieuLuc;
            checkEntityExists.NgayKetThuc = request.NgayKetThuc ?? checkEntityExists.NgayKetThuc;
            checkEntityExists.NoiCap = request.NoiCap ?? checkEntityExists.NoiCap;
            checkEntityExists.NgayCapNhatCuoi = DateTime.Now;
            checkEntityExists.NguoiCapNhatID = _currentUser.UserId;
            _chitietbaohiemRepository.Update(checkEntityExists);
            var result =await _chitietbaohiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return "Cập nhật thành công";
            }
            else
            {
                return "Cập nhật thất bại";
            }
        }
    }
}
