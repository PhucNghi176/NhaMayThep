using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongSanPham.Update;
using NhaMayThep.Application.LuongSanPham;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Update
{
    public class UpdateLuongSanPhamCommandHandler : IRequestHandler<UpdateLuongSanPhamCommand, LuongSanPhamDto>
    {
        private ILuongSanPhamRepository _LuongSanPhamRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLuongSanPhamCommandHandler(ILuongSanPhamRepository LuongSanPhamRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<LuongSanPhamDto> Handle(UpdateLuongSanPhamCommand request, CancellationToken cancellationToken)
        {


            var LuongSanPham = await _LuongSanPhamRepository.FindAsync(x => x.ID == request.ID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (LuongSanPham == null)
                throw new NotFoundException("Luong San Pham is not found");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            LuongSanPham.SoSanPhamLam = request.SoSanPhamLam;
            LuongSanPham.MucSanPhamID = request.MucSanPhamID;
            LuongSanPham.TongLuong = request.TongLuong;
            LuongSanPham.NguoiCapNhatID = _currentUserService.UserId;
            LuongSanPham.NgayCapNhatCuoi = DateTime.Now;

            _LuongSanPhamRepository.Update(LuongSanPham);
            await _LuongSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return LuongSanPham.MapToLuongSanPhamDto(_mapper);
        }
    }
}
