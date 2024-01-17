using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandHandler : IRequestHandler<UpdateKhaiBaoTangLuongCommand, KhaiBaoTangLuongDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public UpdateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _khaiBaoTangLuongRepository = khaiBaoTangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<KhaiBaoTangLuongDto> Handle(UpdateKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var k = await _khaiBaoTangLuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Khai bao tang luong is not found");
            }

            k.NgayApDung = request.NgayApDung != default(DateTime) ? request.NgayApDung : k.NgayApDung;
            k.LyDo = string.IsNullOrEmpty(request.LyDo) ? k.LyDo : request.LyDo;
            k.PhanTramTang = (double)((request.PhanTramTang != 0) ? k.PhanTramTang : request.PhanTramTang);

            k.NguoiCapNhatID = _currentUserService.UserId;
            k.NgayCapNhatCuoi = DateTime.Now;

            _khaiBaoTangLuongRepository.Update(k);
            await _khaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
