using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Create
{
    public class CreateLichSuCongTacNhanVienCommandHandler : IRequestHandler<CreateLichSuCongTacNhanVienCommand, LichSuCongTacNhanVienDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly ILoaiCongTacRepository _loaiCongTacRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;

        public CreateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, 
            IMapper mapper, ILoaiCongTacRepository loaiCongTacRepository, INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
            _loaiCongTacRepository = loaiCongTacRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<LichSuCongTacNhanVienDto> Handle(CreateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien is null || nhanVien.NgayXoa.HasValue) 
            {
                throw new NotFoundException("Nhân Viên Không Tồn Tại");
            }
            var ct = await _loaiCongTacRepository.FindAsync(x => x.ID == request.LoaiCongTacID, cancellationToken);
            if (ct is null)
            {
                throw new NotFoundException("Loại Công Tác Không Tồn Tại");
            }

            var lichSuCongTacNhanVien = new LichSuCongTacNhanVienEntity()
            {
                LoaiCongTacID = request.LoaiCongTacID,
                MaSoNhanVien = request.MaSoNhanVien,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                NoiCongTac = request.NoiCongTac,
                LyDo = request.LyDo,
                NguoiTaoID = _currentUserService.UserId,
            };
            _lichSuCongTacNhanVienRepository.Add(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return lichSuCongTacNhanVien.MapToLichSuCongTacNhanVienDto(_mapper);
        }
    }
}
