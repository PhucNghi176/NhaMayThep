using AutoMapper;
using NhaMayThep.Application.Common.Exceptions;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinDaoTao.Update
{
    public class UpdateThongTinDaoTaoCommandHandler : IRequestHandler<UpdateThongTinDaoTaoCommand, ThongTinDaoTaoDto>
    {
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;
        public UpdateThongTinDaoTaoCommandHandler(ICurrentUserService currentUserService ,IThongTinDaoTaoRepository thongTinDaoTaoRepository, IMapper mapper, ITrinhDoHocVanRepository trinhDoHocVanRepository)
        {
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<ThongTinDaoTaoDto> Handle(UpdateThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindAnyAsync(x => x.ID == request.Id, cancellationToken);
            if (thongTinDaoTao == null || thongTinDaoTao.NgayXoa != null)
            {
                throw new NotFoundException("Thông Tin Đào Tạo không tồn tại!");
            }
            var trinhDoHocVan = await _trinhDoHocVanRepository.AnyAsync(x => x.ID == request.MaTrinhDoHocVanId && x.NgayXoa == null, cancellationToken);
            if (!trinhDoHocVan)
            {
                throw new NotFoundException("Mã Trình Độ Học Vấn không hợp lệ!");
            }

            thongTinDaoTao.MaTrinhDoHocVanID = request.MaTrinhDoHocVanId;
            thongTinDaoTao.TenTruong = request.TenTruong;
            thongTinDaoTao.ChuyenNganh = request.ChuyenNganh;
            thongTinDaoTao.NamTotNghiep = request.NamTotNghiep;
            thongTinDaoTao.TrinhDoVanHoa = request.TrinhDoVanHoa;
            thongTinDaoTao.NguoiCapNhatID = _currentUserService.UserId;
            thongTinDaoTao.NgayCapNhatCuoi = DateTime.Now;

            _thongTinDaoTaoRepository.Update(thongTinDaoTao);
            await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ThongTinDaoTaoDto>(thongTinDaoTao);
        }
    }
}
