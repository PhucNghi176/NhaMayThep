using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhenThuong.Create;
using NhaMayThep.Application.KhenThuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Create
{
    public class CreateKyLuatCommandHandler : IRequestHandler<CreateKyLuatCommand, KyLuatDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public CreateKyLuatCommandHandler(IKyLuatRepository kyLuatRepository, IMapper mapper, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _kyLuatRepository = kyLuatRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<KyLuatDto> Handle(CreateKyLuatCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }


            var k = new KyLuatEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                HinhThucKyLuat = request.HinhThucKyLuat,
                LoaiKyLuat = request.LoaiKyLuat,
                TenDotKyLuat = request.TenDotKyLuat,
                NgayKyLuat = request.NgayKiLuat,
                TongPhat = request.TongPhat,
                DonViApDung = request.DonViApDung,

                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,

            };

            _kyLuatRepository.Add(k);
            await _kyLuatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKyLuatDto(_mapper);
        }
    }
}
