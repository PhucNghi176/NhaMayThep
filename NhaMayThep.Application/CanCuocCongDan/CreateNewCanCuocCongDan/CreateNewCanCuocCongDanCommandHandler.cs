using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
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
        private readonly ICurrentUserService _currentUserService;

        public CreateNewCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository, ICurrentUserService currentUserService)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateNewCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var isExsisted = _canCuocCongDanRepository.FindAsync(x => x.NhanVienID == request.NhanVienID && request.CanCuocCongDan == x.CanCuocCongDan && x.NgayXoa != null, cancellationToken);
            if (isExsisted != null)
            {
                return ("CanCuocCongDan cua nhan vien da ton tai");
            }
            var CanCuocCongDan = new CanCuocCongDanEntity
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
                NguoiTaoID = _currentUserService.UserId,
            };
            _canCuocCongDanRepository.Add(CanCuocCongDan);
            return await _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Them Thanh Cong" : "Them That Bai";


        }
    }
}
