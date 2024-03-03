using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Create
{
    public class CreateNghiPhepCommandHandler : IRequestHandler<CreateNghiPhepCommand, string>
    {
        private INghiPhepRepository _NghiPhepRepository;
        private INhanVienRepository _nhanVienRepository;
        private ILoaiNghiPhepRepository _loaiNghiPhepRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateNghiPhepCommandHandler(INghiPhepRepository NghiPhepRepository, INhanVienRepository nhanVienRepository, ILoaiNghiPhepRepository loaiNghiPhepRepository, ICurrentUserService currentUserService)
        {
            _NghiPhepRepository = NghiPhepRepository;
            _nhanVienRepository = nhanVienRepository;
            _loaiNghiPhepRepository = loaiNghiPhepRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            var checkDuplicatoion = await _NghiPhepRepository.AnyAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai bang Nghi Phep");



            var mucSanPham = await _loaiNghiPhepRepository.FindAsync(x => x.ID == request.LoaiNghiPhepID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (mucSanPham == null)
                throw new NotFoundException("Loại Nghỉ Phép Id: " + request.LoaiNghiPhepID + " không tìm thấy");

            var NghiPhep = new NghiPhepEntity()
            {

                MaSoNhanVien = nhanVien.ID,
                LuongNghiPhep = request.LuongNghiPhep,
                KhoanTruLuong = request.KhoanTruLuong,
                SoGioNghiPhep = request.SoGioNghiPhep,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _NghiPhepRepository.Add(NghiPhep);
            return await _NghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Nghỉ Phép thành công" : "Tạo Nghỉ Phép thất bại";
        }
    }
}
