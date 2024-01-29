using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Delete
{
    public class DeleteLichSuCongTacNhanVienCommandHandler : IRequestHandler<DeleteLichSuCongTacNhanVienCommand, string>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository,
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSuCongTacNhanVien = await _lichSuCongTacNhanVienRepository.FindAnyAsync(x => x.ID == request.Id.ToString(), cancellationToken);
            if (lichSuCongTacNhanVien == null || lichSuCongTacNhanVien.NgayXoa.HasValue)
            {
                return "Xóa Thất Bại";
            }
            lichSuCongTacNhanVien.NguoiXoaID = _currentUserService.UserId;
            lichSuCongTacNhanVien.NgayXoa = DateTime.Now;
            _lichSuCongTacNhanVienRepository.Update(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Xóa Thành Công";
        }
    }
}
