using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac;
using NhaMayThep.Application.DonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien
{
    public class UpdateThongTinDangVienCommandHandler : IRequestHandler<UpdateThongTinDangVienCommand, ThongTinDangVienDto>
    {
        private IThongTinDangVienRepository _thongTinDangVienRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinDangVienCommandHandler(IThongTinDangVienRepository thongTinDangVienRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _thongTinDangVienRepository = thongTinDangVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<ThongTinDangVienDto> Handle(UpdateThongTinDangVienCommand request, CancellationToken cancellationToken)
        {
            

            var thongTinDangVien = await _thongTinDangVienRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (thongTinDangVien == null)
                throw new NotFoundException("Dang Vien is not found");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.NhanVienID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            thongTinDangVien.NgayVaoDang = request.NgayVaoDang;
            thongTinDangVien.CapDangVien = request.CapDangVien ;
            thongTinDangVien.NguoiCapNhatID = _currentUserService.UserId;
            thongTinDangVien.NgayCapNhatCuoi = DateTime.Now;

            _thongTinDangVienRepository.Update(thongTinDangVien);
            await _thongTinDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return thongTinDangVien.MapToThongTinDangVienDto(_mapper);
        }
    }
}
