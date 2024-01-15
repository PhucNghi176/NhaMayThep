using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan
{
    public class CreateThongTinCongDoanCommandHandler : IRequestHandler<CreateThongTinCongDoanCommand, bool>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        public CreateThongTinCongDoanCommandHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository, 
            INhanVienRepository nhanVienRepository) 
        {
            _nhanVienRepository = nhanVienRepository;
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
        }
        public async Task<bool> Handle(CreateThongTinCongDoanCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindById(request.NhanVienID, cancellationToken);
            if(nhanvien == null)
            {
                throw new NotFoundException("NhanVien Does not exists");
            }
            if(await _thongtinCongDoanRepository.FindByNhanVienId(request.NhanVienID, cancellationToken) != null)
            {
                throw new NotFoundException("ThongTinCongDoan for this NhanVien exists");
            }
            var thongtincongdoan = new ThongTinCongDoanEntity
            {
                ThuKiCongDoan = request.ThuKyCongDoan,
                NgayGiaNhap = request.NgayGiaNhap,
                NhanVien = nhanvien,
            };
            _thongtinCongDoanRepository.Add(thongtincongdoan);
            var result= await _thongtinCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
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
