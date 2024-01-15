using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Create
{
    public class CreateLichSuCongTacNhanVienCommandHandler : IRequestHandler<CreateLichSuCongTacNhanVienCommand, LichSuCongTacNhanVienDto>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public CreateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<LichSuCongTacNhanVienDto> Handle(CreateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSuCongTacNhanVien = new LichSuCongTacNhanVienEntity()
            {
                LoaiCongTacID = request.LoaiCongTacID,
                MaSoNhanVien = request.MaSoNhanVien,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                NoiCongTac = request.NoiCongTac,
                LyDo = request.LyDo,
            };
            _lichSuCongTacNhanVienRepository.Add(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return lichSuCongTacNhanVien.MapToLichSuCongTacNhanVienDto(_mapper);
        }
    }
}
