using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.Create
{
    public class CreateThongTinLuongNhanVienCommandHandler : IRequestHandler<CreateThongTinLuongNhanVienCommand, ThongTinLuongNhanVienDto>
    {
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IHopDongRepository _hopDongRepository;
        private readonly IMapper _mapper;

        public CreateThongTinLuongNhanVienCommandHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, INhanVienRepository nhanVienRepository, IHopDongRepository hopDongRepository)
        {
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _nhanVienRepository = nhanVienRepository;
            _hopDongRepository = hopDongRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDto> Handle(CreateThongTinLuongNhanVienCommand request, CancellationToken cancellationToken)
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

            var thongtins = await _thongTinLuongNhanVienRepository.FindAllAsync(cancellationToken);
            foreach ( var t in thongtins )
            {
                if (t.MaSoNhanVien == request.MaSoNhanVien && t.MaSoHopDong == request.MaSoHopDong)
                {
                    throw new NotFoundException("Duplicate entry found for MaSoNhanVien and MaSoHopDong.");
                }
            }

            var k = new ThongTinLuongNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                MaSoHopDong = request.MaSoHopDong,
                Loai = request.Loai,
                LuongCu = request.LuongCu,
                LuongMoi = request.LuongMoi,
                NgayHieuLuc = request.NgayHieuLuc
            };

            _thongTinLuongNhanVienRepository.Add(k);
            await _thongTinLuongNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToThongTinLuongNhanVienDto(_mapper);
        }
    }
}
