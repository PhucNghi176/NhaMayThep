using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.DeleteThongTinDangVien
{
    public class DeleteThongTinDangVienCommandHandler : IRequestHandler<DeleteThongTinDangVienCommand, string>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinDangVienCommand request, CancellationToken cancellationToken)
        {

            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.ID == request.ID && x.NgayXoa == null);
            if (thongTinDangVien == null)
                throw new NotFoundException("Không tìm thấy Đảng Viên");

            thongTinDangVien.NguoiXoaID = _currentUserService.UserId;
            thongTinDangVien.NgayXoa = DateTime.Now;

            _thongTinDangVienRepository.Update(thongTinDangVien);
            await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Xóa thành công";
        }
    }
}
