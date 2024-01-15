using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandHandler : IRequestHandler<UpdateThongTinCongDoanCommand, bool>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        public UpdateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
        }
        public async Task<bool> Handle(UpdateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var thongtincongdoan= await _thongtinCongDoanRepository.FindById(request.Id, cancellationToken);
            if (thongtincongdoan == null) 
            {
                throw new NotFoundException("ThongTinCongDoan does not exists");
            }
            thongtincongdoan.ThuKiCongDoan = request.ThuKyCongDoan;
            thongtincongdoan.NgayGiaNhap = request.NgayGiaNhap ?? thongtincongdoan.NgayGiaNhap;
            _thongtinCongDoanRepository.Update(thongtincongdoan);
            var result=await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result> 0)
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
