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
    public class DeleteThongTinCongDoanCommandHandler : IRequestHandler<DeleteThongTinCongDoanCommand, int>
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
        public async Task<int> Handle(DeleteThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository.FindAsync(x=> x.ID.Equals(request.Id), cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException("ThongTinCongDoan does not exists");
            }
            else
            {
                thongtincongdoan.NguoiXoaID = request.NguoiXoaid;
                thongtincongdoan.NgayXoa = DateTime.Now;
                _thongtinCongDoanRepository.Update(thongtincongdoan);
                return await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
