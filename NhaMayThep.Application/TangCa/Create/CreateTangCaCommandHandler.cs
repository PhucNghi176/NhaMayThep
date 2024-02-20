using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TangCa.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Create
{
    public class CreateTangCaCommandHandler : IRequestHandler<CreateTangCaCommand, string>
    {
        private ITangCaRepository _TangCaRepository;
        private INhanVienRepository _nhanVienRepository;
        private ILoaiTangCaRepository _loaiTangCaRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateTangCaCommandHandler(ITangCaRepository TangCaRepository, INhanVienRepository nhanVienRepository, IMucSanPhamRepository mucSanPhamRepository, ICurrentUserService currentUserService, ILoaiTangCaRepository loaiTangCaRepository)
        {
            _TangCaRepository = TangCaRepository;
            _nhanVienRepository = nhanVienRepository;
            _loaiTangCaRepository = loaiTangCaRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateTangCaCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            //var checkDuplicatoion = await _TangCaRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            //if (checkDuplicatoion != null)
            //    throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai bảng Tăng Ca");

            var loaiTangCa = await _loaiTangCaRepository.FindAsync(x => x.ID == request.LoaiTangCaID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (loaiTangCa == null)
                throw new NotFoundException("Loại Tăng Ca Id: " + request.LoaiTangCaID + " không tìm thấy");

            var TangCa = new TangCaEntity()
            {
                MaSoNhanVien = nhanVien.ID,
                LoaiTangCaID = request.LoaiTangCaID,
                SoGioLamThem = request.SoGioLamThem,
                SoSanPhamLamThem = request.SoSanPhamLamThem,
                LuongCongNhat = request.LuongCongNhat,
                LuongSanPham = request.LuongSanPham,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _TangCaRepository.Add(TangCa);
            return await _TangCaRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo bảng Tăng Ca thành công" : "Tạo bảng Tăng Ca thất bại";
        }
    }
}
