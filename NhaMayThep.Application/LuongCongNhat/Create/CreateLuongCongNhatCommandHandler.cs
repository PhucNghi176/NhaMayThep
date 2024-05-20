using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongCongNhat.Create
{
    public class CreateLuongCongNhatCommandHandler : IRequestHandler<CreateLuongCongNhatCommand, string>
    {
        private ILuongCongNhatRepository _LuongCongNhatRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateLuongCongNhatCommandHandler(ILuongCongNhatRepository LuongCongNhatRepository, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateLuongCongNhatCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            var checkDuplicatoion = await _LuongCongNhatRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai Luong Cong Nhat");



            var LuongCongNhat = new LuongCongNhatEntity()
            {

                MaSoNhanVien = nhanVien.ID,

                Luong1Gio = request.Luong1Gio,
                TongLuong = request.TongLuong,
                NgayKhaiBao = request.NgayKhaiBao,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _LuongCongNhatRepository.Add(LuongCongNhat);
            return await _LuongCongNhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Lương Công Nhật thành công" : "Tạo Lương Công Nhật thất bại";
        }
    }
}