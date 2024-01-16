using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
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
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public UpdateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
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

            k.MaSoNhanVien = request.MaSoNhanVien != null ? request.MaSoNhanVien : k.MaSoNhanVien;
            k.NgayApDung = (DateTime)(request.NgayApDung != null ? request.NgayApDung : k.NgayApDung);
            k.LyDo = request.LyDo != null ? request.LyDo : k.LyDo;
            k.PhanTramTang = (double)(request.PhanTramTang != null ? request.PhanTramTang : k.PhanTramTang);

            _khaiBaoTangLuongRepository.Update(k);
            await _khaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
