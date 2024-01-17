using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommandHandler : IRequestHandler<DeleteThongTinCongDoanCommand, string>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            ICurrentUserService currentUserService)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository
                .FindAsync(x=> x.ID.Equals(request.Id), cancellationToken);
            if (thongtincongdoan == null || (thongtincongdoan.NguoiXoaID != null && thongtincongdoan.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin công đoàn không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongtincongdoan.NguoiXoaID = _currentUserService.UserId;
            thongtincongdoan.NgayXoa = DateTime.Now;
            _thongtinCongDoanRepository.Update(thongtincongdoan);
            try
            {
                await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Xóa thông tin công đoàn thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình xóa thông tin công đoàn");
            }
        }
    }
}
