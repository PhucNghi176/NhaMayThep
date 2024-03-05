using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandHandler : IRequestHandler<UpdateKhaiBaoTangLuongCommand, string>
    {
        private readonly IKhaiBaoTangLuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public UpdateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository repository, IMapper mapper, INhanVienRepository nhanvien, NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }
        public UpdateKhaiBaoTangLuongCommandHandler() { }
        public async Task<string> Handle(UpdateKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Không tìm thấy nhân viên với ID : {request.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            }

            var KhaiBaoTangLuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (KhaiBaoTangLuong == null)
                throw new NotFoundException($"Không tìm thấy Khai Báo Tăng Lương với ID : {request.ID} hoặc Khai Báo Tăng Lương này đã bị xóa.");

            KhaiBaoTangLuong.NguoiCapNhatID = this._currentUserService.UserId;
            KhaiBaoTangLuong.MaSoNhanVien = request.MaSoNhanVien ?? KhaiBaoTangLuong.MaSoNhanVien;
            KhaiBaoTangLuong.PhanTramTang = request.PhanTramTang;
            KhaiBaoTangLuong.NgayApDung = request.NgayApDung;
            KhaiBaoTangLuong.LyDo = request.LyDo;
            KhaiBaoTangLuong.NgayCapNhatCuoi = DateTime.UtcNow;

            this._repository.Update(KhaiBaoTangLuong);
            return await this._repository.UnitOfWork.SaveChangesAsync() > 0 ? "Cập nhật Khai Báo Tăng Lương thành công" : "Cập nhật Khai Báo Tăng Lương thất bại";
        }
    }
}
