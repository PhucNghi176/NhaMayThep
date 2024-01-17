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
            var thongtincongdoan = await _thongtinCongDoanRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException("ThongTinCongDoan does not exists");
            }
            else
            {
                thongtincongdoan.NguoiXoaID = request.NguoiXoaid;
                thongtincongdoan.NgayXoa = DateTime.Now;
                _thongtinCongDoanRepository.Update(thongtincongdoan);
                var result = await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return "Delete Successfully!";
                }
                else
                {
                    return "Delete Failed!";
                }
            }
        }
    }
}
