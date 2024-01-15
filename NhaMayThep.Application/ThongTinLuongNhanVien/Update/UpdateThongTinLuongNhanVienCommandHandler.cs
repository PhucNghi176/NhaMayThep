using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
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
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;

        public UpdateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(UpdateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindByIdAsync(request.MaSoNhanVien.ToString(), cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }

            var hopdong = await _hopDongRepository.FindByIdAsync(request.MaSoHopDong.ToString(), cancellationToken);

            if (hopdong == null)
            {
                throw new NotFoundException("Hop dong not found");
            }

            var k = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);

            if (k == null)
            {
                throw new NotFoundException("The list is empty");
            }

            var t = k.FirstOrDefault(x => x.MaSoNhanVien == request.MaSoNhanVien.ToString());

            if (t == null)
            {
                throw new NotFoundException("Thong Tin Luong Nhan Vien With MSNV not exist");
            }

            t.MaSoHopDong = request.MaSoHopDong == null ? t.MaSoHopDong : request.MaSoHopDong;
            t.Loai = request.Loai == null ? t.Loai : request.Loai;
            t.LuongCu = request.LuongCu == null ? t.LuongCu : request.LuongCu;
            t.LuongHienTai = request.LuongHienTai == null ? t.LuongHienTai : request.LuongHienTai;
            t.NgayHieuLuc = request.NgayHieuLuc == null ? t.NgayHieuLuc : request.NgayHieuLuc;



            _thongTinLuongNhanVienRepository.Update(t);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return t.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
