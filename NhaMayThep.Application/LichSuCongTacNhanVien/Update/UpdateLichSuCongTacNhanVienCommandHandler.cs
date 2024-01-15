using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommandHandler : IRequestHandler<UpdateLichSuCongTacNhanVienCommand, LichSuCongTacNhanVienDto>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public UpdateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<LichSuCongTacNhanVienDto> Handle(UpdateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSuCongTacNhanVien = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.Id.ToString(), cancellationToken);
            if (lichSuCongTacNhanVien == null)
            {
                throw new NotFoundException("Does Not Exist!");
            }
            
            lichSuCongTacNhanVien.MaSoNhanVien = request.MaSoNhanVien;
            lichSuCongTacNhanVien.NgayBatDau = request.NgayBatDau;
            lichSuCongTacNhanVien.NgayKetThuc = request.NgayKetThuc;
            lichSuCongTacNhanVien.NoiCongTac = request.NoiCongTac;
            lichSuCongTacNhanVien.LoaiCongTacID = request.LoaiCongTacID;
            lichSuCongTacNhanVien.LyDo = request.LyDo;
            _lichSuCongTacNhanVienRepository.Update(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return lichSuCongTacNhanVien.MapToLichSuCongTacNhanVienDto(_mapper);

        }
    }
}
