using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommandHandler : IRequestHandler<UpdateLichSuCongTacNhanVienCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;

        public UpdateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, ILoaiCongTacRepository loaiCongTacRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _loaiCongTacRepository = loaiCongTacRepository;
        }

        public async Task<string> Handle(UpdateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var ct = await _loaiCongTacRepository.FindAsync(x => x.ID == request.LoaiCongTacID, cancellationToken);
            if (ct is null || ct.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Công Tác không Tồn Tại");
            }
            var lichSu = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.ID, cancellationToken);
            if (lichSu is null || lichSu.NgayXoa.HasValue)
            {
                throw new NotFoundException("Lịch Sử Công Tác Nhân Viên Không Tồn Tại");
            }
            lichSu.ID = request.ID;
            lichSu.LoaiCongTacID = request.LoaiCongTacID;
            lichSu.NgayBatDau = request.NgayBatDau;
            lichSu.NgayKetThuc = request.NgayKetThuc;
            lichSu.NoiCongTac = request.NoiCongTac;
            lichSu.LyDo = request.LyDo;
            lichSu.NguoiCapNhatID = _currentUserService.UserId;
            lichSu.NgayCapNhatCuoi = DateTime.Now;

            //lichSu.NhanVien = lichSu.NhanVien;
            return "Cập Nhật Thành Công";
        }
    }
}
