using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhenThuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Update
{
    public class UpdateKhenThuongCommandHandler : IRequestHandler<UpdateKhenThuongCommand, KhenThuongDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;

        public UpdateKhenThuongCommandHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
        }


        public async Task<KhenThuongDto> Handle(UpdateKhenThuongCommand request, CancellationToken cancellationToken)
        {

            var k = await _khenThuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Khen Thuong not found");
            }

            k.HinhThucKhenThuong = string.IsNullOrEmpty(request.HinhThucKhenThuong) ? k.HinhThucKhenThuong : request.HinhThucKhenThuong;
            k.LoaiKhenThuong = string.IsNullOrEmpty(request.LoaiKhenThuong) ? k.LoaiKhenThuong : request.LoaiKhenThuong;
            k.TenDotKhenThuong = string.IsNullOrEmpty(request.TenDotKhenThuong) ? k.TenDotKhenThuong : request.TenDotKhenThuong;
            k.DonViApDung = string.IsNullOrEmpty(request.DonViApDung) ? k.DonViApDung : request.DonViApDung;
            k.NgayKhenThuong = request.NgayKhenThuong != default(DateTime) ? request.NgayKhenThuong : k.NgayKhenThuong;
            k.TongGiaTri = (double)((request.TongGiaTri != 0) ? k.TongGiaTri : request.TongGiaTri);

            k.NgayCapNhatCuoi = DateTime.Now;
            k.NguoiCapNhatID = _currentUserService.UserId;

            _khenThuongRepository.Update(k);
            await _khenThuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhenThuongDto(_mapper);
        }
    }
}
