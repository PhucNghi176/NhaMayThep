using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommandHandler : IRequestHandler<DeleteThongTinCongDoanCommand, bool>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        public DeleteThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
        }
        public async Task<bool> Handle(DeleteThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository.FindById(request.Id, cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException("ThongTinCongDoan does not exists");
            }
            _thongtinCongDoanRepository.Remove(thongtincongdoan);
            var result = await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
