using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Update
{
    public class UpdateNghiPhepCommandHandler : IRequestHandler<UpdateNghiPhepCommand, string>
    {
        private INghiPhepRepository _NghiPhepRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _loaiNghiPhepRepository;
        public UpdateNghiPhepCommandHandler(INghiPhepRepository NghiPhepRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService, ILoaiNghiPhepRepository loaiNghiPhepRepository)
        {
            _NghiPhepRepository = NghiPhepRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _loaiNghiPhepRepository = loaiNghiPhepRepository;
        }
        public async Task<string> Handle(UpdateNghiPhepCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            }

            var NghiPhep = await _NghiPhepRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (NghiPhep == null)
                throw new NotFoundException($"Không tìm thấy Nghỉ Phép với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            var MucSanPham = await _loaiNghiPhepRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (MucSanPham == null)
                throw new NotFoundException($"Không tìm thấy Loại Nghỉ Phép với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            NghiPhep.SoGioNghiPhep = request.SoGioNghiPhep;
            NghiPhep.LoaiNghiPhepID = request.LoaiNghiPhepID;
            NghiPhep.LuongNghiPhep = request.LuongNghiPhep;
            NghiPhep.KhoanTruLuong = request.KhoanTruLuong;
            NghiPhep.NguoiCapNhatID = _currentUserService.UserId;
            NghiPhep.NgayCapNhatCuoi = DateTime.Now;

            _NghiPhepRepository.Update(NghiPhep);
            return await _NghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Nghỉ Phép thành công" : "Cập nhật Nghỉ Phép thất bại";
        }
    }
}
