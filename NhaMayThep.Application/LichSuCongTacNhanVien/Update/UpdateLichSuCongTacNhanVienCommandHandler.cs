using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Update
{
    public class UpdateLichSuCongTacNhanVienCommandHandler : IRequestHandler<UpdateLichSuCongTacNhanVienCommand>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;

        public UpdateLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
        }

        public async Task Handle(UpdateLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSu = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (lichSu is null) 
            {
                throw new DllNotFoundException(nameof(lichSu));
            }
            lichSu.LoaiCongTacID = request.LoaiCongTacID;
            lichSu.NgayBatDau = request.BD;
            lichSu.NgayKetThuc = request.KT;
            lichSu.NoiCongTac = request.NoiCongTac;
            lichSu.LyDo = request.LyDo;
        }
    }
}
