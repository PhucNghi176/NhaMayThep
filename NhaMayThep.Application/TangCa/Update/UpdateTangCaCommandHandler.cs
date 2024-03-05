using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TangCa.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Update
{
    public class UpdateTangCaCommandHandler : IRequestHandler<UpdateTangCaCommand, string>
    {
        private readonly ITangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanvien;
        private readonly NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository _chinhsach;
        private readonly ICurrentUserService _currentUserService;
        public UpdateTangCaCommandHandler(ITangCaRepository repository, IMapper mapper, INhanVienRepository nhanvien, NhaMapThep.Domain.Repositories.ConfigTable.IChinhSachNhanSuRepository chinhsach, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanvien = nhanvien;
            _chinhsach = chinhsach;
            _currentUserService = currentUserService;
        }
        public UpdateTangCaCommandHandler() { }
        public async Task<string> Handle(UpdateTangCaCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanvien.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Không tìm thấy nhân viên với ID : {request.MaSoNhanVien} hoặc nhân viên này đã bị xóa.");
            }

            var TangCa = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (TangCa == null)
                throw new NotFoundException($"Không tìm thấy bảng Tăng Ca với ID : {request.ID} hoặc bảng Tăng Ca này đã bị xóa.");

            TangCa.NguoiCapNhatID = this._currentUserService.UserId;
            TangCa.MaSoNhanVien = request.MaSoNhanVien ?? TangCa.MaSoNhanVien;
            TangCa.SoGioLamThem = request.SoGioLamThem;
            TangCa.SoSanPhamLamThem = request.SoSanPhamLamThem;
            TangCa.LuongCongNhat = request.LuongCongNhat;
            TangCa.LuongSanPham = request.LuongSanPham;
            TangCa.LoaiTangCaID = request.LoaiTangCaID;
            TangCa.NgayCapNhatCuoi = DateTime.UtcNow;

            this._repository.Update(TangCa);
            return await this._repository.UnitOfWork.SaveChangesAsync() > 0 ? "Cập nhật Bảng Tăng Ca thành công" : "Cập nhật Bảng Tăng Ca thất bại";
        }
    }
}
