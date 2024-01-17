using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.UpdateCanCuocCongDan
{
    public class UpdateCanCuocCongDanCommandHandler : IRequestHandler<UpdateCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;

        public UpdateCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
        }

        public async Task<string> Handle(UpdateCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayTao != null);
            if (CanCuocCongDan is null)
            {
                throw new NotFoundException($"Khong Tim Thay CanCuocCongDan {CanCuocCongDan.CanCuocCongDan}");
            }
            CanCuocCongDan.HoVaTen = request.HoVaTen;
            CanCuocCongDan.NgaySinh = request.NgaySinh;
            CanCuocCongDan.GioiTinh = request.GioiTinh;
            CanCuocCongDan.QuocTich = request.QuocTich;
            CanCuocCongDan.QueQuan = request.QueQuan;
            CanCuocCongDan.DiaChiThuongTru = request.DiaChiThuongTru;
            CanCuocCongDan.NgayCap = request.NgayCap;
            CanCuocCongDan.NoiCap = request.NoiCap;
            CanCuocCongDan.DanToc = request.DanToc;
            CanCuocCongDan.TonGiao = request.TonGiao;
            CanCuocCongDan.NgayCapNhatCuoi = DateTime.Now;
            _canCuocCongDanRepository.Update(CanCuocCongDan);
            return await _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cap Nhat Thanh Cong" : "Cap Nhat That Bai";
        }
    }

}

