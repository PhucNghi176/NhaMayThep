using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NhaMayThep.Application.KhenThuong.Create
{
    public class CreateKhenThuongCommandHandler : IRequestHandler<CreateKhenThuongCommand, KhenThuongDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public CreateKhenThuongCommandHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _khenThuongRepository = khenThuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<KhenThuongDto> Handle(CreateKhenThuongCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }


            var k = new KhenThuongEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                HinhThucKhenThuong = request.HinhThucKhenThuong,
                LoaiKhenThuong = request.LoaiKhenThuong,
                TenDotKhenThuong = request.TenDotKhenThuong,
                NgayKhenThuong = request.NgayKhenThuong,
                TongGiaTri = request.TongGiaTri,
                DonViApDung = request.DonViApDung,

                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,

            };

            _khenThuongRepository.Add(k);
            await _khenThuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhenThuongDto(_mapper);
        }
    }
}
