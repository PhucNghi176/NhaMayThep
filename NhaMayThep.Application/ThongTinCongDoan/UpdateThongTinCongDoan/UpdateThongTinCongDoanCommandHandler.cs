using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandHandler : IRequestHandler<UpdateThongTinCongDoanCommand, string>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly INhanVienRepository _nhanvienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            INhanVienRepository nhanvienRepository,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _nhanvienRepository = nhanvienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan= await _thongtinCongDoanRepository
                .FindAnyAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongtincongdoan == null ||(thongtincongdoan.NguoiXoaID != null && thongtincongdoan.NgayXoa.HasValue)) 
            {
                throw new NotFoundException("Thông tin công đoàn không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var nhanvien = await _nhanvienRepository
                .FindAnyAsync(x => x.ID.Equals(request.NhanVienId), cancellationToken);
            if (nhanvien == null || (nhanvien.NguoiXoaID != null && nhanvien.NgayXoa.HasValue))
            {
                throw new NotFoundException($"Nhân viên không tồn tại hoặc đã bị vô hiệu hóa");
            }
            thongtincongdoan.NguoiCapNhatID = _currentUserService.UserId;
            thongtincongdoan.NgayCapNhatCuoi = DateTime.Now;
            thongtincongdoan.NhanVienID = nhanvien.ID;
            thongtincongdoan.NhanVien = nhanvien;
            thongtincongdoan.ThuKiCongDoan = request.ThuKyCongDoan;
            thongtincongdoan.NgayGiaNhap = request.NgayGiaNhap ?? thongtincongdoan.NgayGiaNhap;
            _thongtinCongDoanRepository.Update(thongtincongdoan);
            try
            {
                await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Cập nhật thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình cập nhật dữ liệu");
            }
        }
    }
}
