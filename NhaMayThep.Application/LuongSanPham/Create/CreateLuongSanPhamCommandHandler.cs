using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongSanPham.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommandHandler : IRequestHandler<CreateLuongSanPhamCommand, string>
    {
        private ILuongSanPhamRepository _LuongSanPhamRepository;
        private INhanVienRepository _nhanVienRepository;
        private IMucSanPhamRepository _mucSanPhamRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateLuongSanPhamCommandHandler(ILuongSanPhamRepository LuongSanPhamRepository, INhanVienRepository nhanVienRepository, IMucSanPhamRepository mucSanPhamRepository, ICurrentUserService currentUserService)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _nhanVienRepository = nhanVienRepository;
            _mucSanPhamRepository = mucSanPhamRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateLuongSanPhamCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _LuongSanPhamRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien, cancellationToken: cancellationToken);
            if (checkDuplicatoion != null)
                throw new NotFoundException("Nhan Vien" + request.MaSoNhanVien + "da ton tai Luong San Pham");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            var mucSanPham = await _mucSanPhamRepository.FindAsync(x => x.ID == request.MucSanPhamID, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Muc San Pham is not found");

            var LuongSanPham = new LuongSanPhamEntity()
            {
                ID = request.ID,
                MaSoNhanVien = nhanVien.ID,
                NhanVien = nhanVien,
                MucSanPhamID = request.MucSanPhamID,
                TongLuong = request.TongLuong,
                SoSanPhamLam = request.SoSanPhamLam,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Today
            };

            _LuongSanPhamRepository.Add(LuongSanPham);
            await _LuongSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return LuongSanPham.ID;
        }
    }
}