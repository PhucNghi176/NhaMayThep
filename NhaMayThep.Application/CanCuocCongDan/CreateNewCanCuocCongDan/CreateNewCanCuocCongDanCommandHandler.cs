using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan
{
    public class CreateNewCanCuocCongDanCommandHandler : IRequestHandler<CreateNewCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public CreateNewCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository, ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<string> Handle(CreateNewCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {

            var isExsisted = await _canCuocCongDanRepository.AnyAsync(x => x.NhanVienID == request.NhanVienID && x.NgayXoa == null, cancellationToken);
            if (isExsisted)
            {
                throw new DuplicationException("Nhân Viên đã có Căn Cước Công Dân");
            }
            isExsisted = await _canCuocCongDanRepository.AnyAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayXoa == null, cancellationToken);
            if (isExsisted)
            {
                throw new DuplicationException("Mã số Căn Cước Công Dân này đã tồn tại");
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
