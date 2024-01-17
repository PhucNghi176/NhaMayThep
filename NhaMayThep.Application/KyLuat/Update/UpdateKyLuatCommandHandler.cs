using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KyLuat.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Update
{
    public class UpdateKyLuatCommandHandler : IRequestHandler<UpdateKyLuatCommand, KyLuatDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;

        public UpdateKyLuatCommandHandler(IKyLuatRepository kyLuatRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
        }


        public async Task<KyLuatDto> Handle(UpdateKyLuatCommand request, CancellationToken cancellationToken)
        {
            var k = await _kyLuatRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Ky Luat not found");
            }

            k.HinhThucKyLuat = string.IsNullOrEmpty(request.HinhThucKyLuat) ? k.HinhThucKyLuat : request.HinhThucKyLuat;
            k.LoaiKyLuat = string.IsNullOrEmpty(request.LoaiKyLuat) ? k.LoaiKyLuat : request.LoaiKyLuat;
            k.TenDotKyLuat = string.IsNullOrEmpty(request.TenDotKyLuat) ? k.TenDotKyLuat : request.TenDotKyLuat;
            k.DonViApDung = string.IsNullOrEmpty(request.DonViApDung) ? k.DonViApDung : request.DonViApDung;
            k.NgayKyLuat = request.NgayKyLuat != default(DateTime) ? request.NgayKyLuat : k.NgayKyLuat;
            k.TongPhat = (double)((request.TongPhat != 0) ? k.TongPhat : request.TongPhat);

            k.NguoiCapNhatID = _currentUserService.UserId;
            k.NgayCapNhatCuoi = DateTime.Now;

            _kyLuatRepository.Update(k);
            await _kyLuatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKyLuatDto(_mapper);
        }
    }
}
