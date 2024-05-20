using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongCongNhat.Update
{
    public class UpdateLuongCongNhatCommandHandler : IRequestHandler<UpdateLuongCongNhatCommand, string>
    {
        private ILuongCongNhatRepository _LuongCongNhatRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLuongCongNhatCommandHandler(ILuongCongNhatRepository LuongCongNhatRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateLuongCongNhatCommand request, CancellationToken cancellationToken)
        {
            if (request.MaSoNhanVien != null)
            {
                var nhanvien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
                if (nhanvien == null)
                    throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");
            }

            var LuongCongNhat = await _LuongCongNhatRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (LuongCongNhat == null)
                throw new NotFoundException($"Không tìm thấy Lương Công Nhật với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            LuongCongNhat.SoGioLam = request.SoGioLam;
            LuongCongNhat.Luong1Gio = request.Luong1Gio;
            LuongCongNhat.TongLuong = request.TongLuong;
            LuongCongNhat.NgayKhaiBao = request.NgayKhaiBao;
            LuongCongNhat.NguoiCapNhatID = _currentUserService.UserId;
            LuongCongNhat.NgayCapNhatCuoi = DateTime.Now;

            _LuongCongNhatRepository.Update(LuongCongNhat);
            return await _LuongCongNhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Lương Công Nhật thành công" : "Cập nhật Lương Công Nhật thất bại";
        }
    }
}