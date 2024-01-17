using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .FindAsync(x=> x.ID.Equals(request.Id) && x.NguoiXoaID == null && x.NgayXoa.HasValue, 
                cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException("Thông tin công đoàn không tồn tại");
            }
            else
            {
                thongtincongdoan.NguoiXoaID = _currentUserService.UserId;
                thongtincongdoan.NgayXoa = DateTime.Now;
                _thongtinCongDoanRepository.Update(thongtincongdoan);
                try
                {
                    await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    return "Xóa thành công";
                }
                catch (Exception)
                {
                    return "Đã xảy ra lỗi trong quá trình xóa";
                }
            }
        }
    }
}
