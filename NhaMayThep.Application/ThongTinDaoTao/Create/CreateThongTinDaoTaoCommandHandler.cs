using AutoMapper;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.Base;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.ThongTinDaoTao.Create;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;


namespace NhaMayThep.Application.ThongTinDaoTao.CreateThongTinDaoTao
{
    public class CreateThongTinDaoTaoCommandHandler : IRequestHandler<CreateThongTinDaoTaoCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;

        public CreateThongTinDaoTaoCommandHandler(ICurrentUserService currentUserService ,IMapper mapper, IThongTinDaoTaoRepository thongTinDaoTaoRepository, ITrinhDoHocVanRepository trinhDoHocVanRepository, INhanVienRepository nhanVienRepository)
        {
            _mapper = mapper;
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<string> Handle(CreateThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            var existingNhanVien = await _nhanVienRepository.AnyAsync(x => x.ID == request.NhanVienId && x.NgayXoa == null, cancellationToken);
            if (!existingNhanVien)
            {
                return "Thất Bại! Nhân viên ID không tồn tại.";
            }
            var trinhDoHocVan = await _trinhDoHocVanRepository.AnyAsync(x => x.ID == request.MaTrinhDoHocVanId && x.NgayXoa == null, cancellationToken);
            if (!trinhDoHocVan)
            {
                return "Thất Bại! MaTrinhDoHocVanID không hợp lệ.";
            }
            var existingThongTinDaoTao = await _thongTinDaoTaoRepository.AnyAsync(x => x.NhanVienID == request.NhanVienId && x.NgayXoa == null,  cancellationToken);
            if (existingThongTinDaoTao)
            {
                return "Thất Bại! Nhân viên đã có trình độ đào tạo.";
            }
            var thongTinDaoTao = new ThongTinDaoTaoEntity
            {
                NhanVienID = request.NhanVienId,
                MaTrinhDoHocVanID = request.MaTrinhDoHocVanId,
                TenTruong = request.TenTruong,
                ChuyenNganh = request.ChuyenNganh,
                NamTotNghiep = request.NamTotNghiep,
                TrinhDoVanHoa = request.TrinhDoVanHoa,
                NguoiTaoID = _currentUserService.UserId,
            };

            _thongTinDaoTaoRepository.Add(thongTinDaoTao);
            return await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Thành Công!" : "Thất Bại!";

        }
    }
}
