using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Update
{
    public class UpdateThongTinLuongNhanVienCommandHandler : IRequestHandler<UpdateThongTinLuongNhanVienCommand, ThongTinLuongNhanVienDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;

        public UpdateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(UpdateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var thongtin = await _thongTinLuongNhanVienRepository.FindByIdAsync(request.Id, cancellationToken);

            if (thongtin == null || thongtin.NgayXoa != null)
            {
                throw new NotFoundException("Thong tin not found");
            }

            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }

            var hopdong = await _hopDongRepository.FindAsync(x => x.ID == request.MaSoHopDong, cancellationToken);

            if (hopdong == null)
            {
                throw new NotFoundException("Hop dong not found");
            }


            thongtin.MaSoNhanVien = string.IsNullOrEmpty(request.MaSoNhanVien) ? thongtin.MaSoNhanVien : request.MaSoNhanVien;
            thongtin.MaSoHopDong = string.IsNullOrEmpty(request.MaSoHopDong) ? thongtin.MaSoHopDong : request.MaSoHopDong;
            thongtin.Loai = string.IsNullOrEmpty(request.Loai) ? thongtin.Loai : request.Loai;
            thongtin.LuongCu = (request.LuongCu != 0) ? request.LuongCu : thongtin.LuongCu;
            thongtin.LuongMoi = (request.LuongCu != 0) ? request.LuongMoi : thongtin.LuongMoi;
            thongtin.NgayHieuLuc = request.NgayHieuLuc != default(DateTime) ? request.NgayHieuLuc : thongtin.NgayHieuLuc;

            thongtin.NgayCapNhatCuoi = DateTime.Now;
            thongtin.NguoiCapNhatID = _currentUserService.UserId;

            _thongTinLuongNhanVienRepository.Update(thongtin);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return thongtin.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
