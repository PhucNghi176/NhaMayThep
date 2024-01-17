using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan
{
    public class CreateNewCanCuocCongDanCommandHandler : IRequestHandler<CreateNewCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;

        public CreateNewCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
        }

        public async Task<string> Handle(CreateNewCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan= new CanCuocCongDanEntity
            {
                CanCuocCongDan = request.CanCuocCongDan,
                NhanVienID = request.NhanVienID,
                HoVaTen = request.HoVaTen,
                NgaySinh = request.NgaySinh,
                GioiTinh = request.GioiTinh,
                QuocTich = request.QuocTich,
                QueQuan = request.QueQuan,
                DiaChiThuongTru = request.DiaChiThuongTru,
                NgayCap = request.NgayCap,
                NoiCap = request.NoiCap,
                DanToc = request.DanToc,
                TonGiao = request.TonGiao,
                NgayTao = DateTime.Now,
                NgayCapNhatCuoi = DateTime.Now,               
            };
            _canCuocCongDanRepository.Add(CanCuocCongDan);          
           return await _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Them Thanh Cong" : "Them That Bai";
           

        }
    }
}
