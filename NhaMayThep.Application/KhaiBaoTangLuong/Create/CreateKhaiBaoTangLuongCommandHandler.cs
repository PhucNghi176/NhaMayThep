using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Create
{
    public class CreateKhaiBaoTangLuongCommandHandler : IRequestHandler<CreateKhaiBaoTangLuongCommand, KhaiBaoTangLuongDto>
    {
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public CreateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper, INhanVienRepository nhanVienRepository)
        {
            _khaiBaoTangLuongRepository = khaiBaoTangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
        }


        public async Task<KhaiBaoTangLuongDto> Handle(CreateKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _nhanVienRepository.FindByIdAsync(request.MaSoNhanVien.ToString(), cancellationToken);

            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan vien not found");
            }


            var k = new KhaiBaoTangLuongEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                NgayApDung = request.NgayApDung,
                PhanTramTang = request.PhanTramTang,
                LyDo = request.LyDo

            };

            _khaiBaoTangLuongRepository.Add(k);
            await _khaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
