using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommandHandler : IRequestHandler<CreateThongTinLuongNhanVienCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;

        public CreateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }


        public async Task<string> Handle(CreateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);

            if (nhanvien == null)
            {
                return "Mã Nhân Viên không tồn tại";
            }

            var hopdong = await _hopDongRepository.FindAsync(x => x.ID == request.MaSoHopDong, cancellationToken);

            if (hopdong == null)
            {
                return "Mã Hợp Đồng không tồn tại";
            }

            var thongtins = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);
            foreach (var t in thongtins)
            {
                if (t.MaSoNhanVien == request.MaSoNhanVien && t.MaSoHopDong == request.MaSoHopDong)
                {
                    return "Mã Nhân Viên và Mã Hợp Đồng bị trùng lặp";
                }
            }

            var k = new ThongTinLuongNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                MaSoHopDong = request.MaSoHopDong,
                Loai = request.Loai,
                LuongCu = request.LuongCu,
                LuongMoi = request.LuongMoi,
                NgayHieuLuc = request.NgayHieuLuc,

                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,
            };

            _thongTinLuongNhanVienRepository.Add(k);
            return await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo mới thành công" : "Tạo mới thất bại";
        }
    }
}
