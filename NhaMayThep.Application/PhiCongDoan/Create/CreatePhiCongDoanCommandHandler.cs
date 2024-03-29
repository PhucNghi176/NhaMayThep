using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;

using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhiCongDoan.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Create
{
    public class CreatePhiCongDoanCommandHandler : IRequestHandler<CreatePhiCongDoanCommand, string>
    {
        private IPhiCongDoanRepository _PhiCongDoanRepository;
        private INhanVienRepository _nhanVienRepository;
        private IMucSanPhamRepository _mucSanPhamRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePhiCongDoanCommandHandler(IPhiCongDoanRepository PhiCongDoanRepository, INhanVienRepository nhanVienRepository, IMucSanPhamRepository mucSanPhamRepository, ICurrentUserService currentUserService)
        {
            _PhiCongDoanRepository = PhiCongDoanRepository;
            _nhanVienRepository = nhanVienRepository;
            _mucSanPhamRepository = mucSanPhamRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreatePhiCongDoanCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await this._nhanVienRepository.FindAsync(x => x.ID.Equals(request.MaSoNhanVien) && x.NgayXoa == null, cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException($"Mã số nhân viên : {request.MaSoNhanVien} không tồn tại hoặc đã xóa.");

            var checkDuplicatoion = await _PhiCongDoanRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien co ID: " + request.MaSoNhanVien + "da ton tai Phi Cong Doan");

            var PhiCongDoan = new PhiCongDoanEntity()
            {

                MaSoNhanVien = nhanVien.ID,
                LuongDongBH = request.LuongDongBH,
                PhanTramLuongDongBH = request.PhanTramLuongDongBH,

                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _PhiCongDoanRepository.Add(PhiCongDoan);
            return await _PhiCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Phí Công Đoàn thành công" : "Tạo Phí Công Đoàn thất bại";
        }
    }
}
