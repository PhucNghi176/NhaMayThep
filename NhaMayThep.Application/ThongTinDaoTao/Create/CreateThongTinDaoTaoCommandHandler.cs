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
        //private readonly INhanVienRepository _nhanVienRepository;
        //private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;

        public CreateThongTinDaoTaoCommandHandler(ICurrentUserService currentUserService ,IMapper mapper, IThongTinDaoTaoRepository thongTinDaoTaoRepository/*, INhanVienRepository nhanVienRepository, ITrinhDoHocVanRepository trinhDoHocVanRepository*/)
        {
            _mapper = mapper;
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _currentUserService = currentUserService;
            //_nhanVienRepository = nhanVienRepository;
            //_trinhDoHocVanRepository = trinhDoHocVanRepository;
        }

        public async Task<string> Handle(CreateThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            //var nhanVien = await _nhanVienRepository.FindByIdAsync(request.NhanVienId, cancellationToken);
            //if (nhanVien == null)
            //{
            //    throw new NotFoundException("NhanVien Does Not Exist");
            //}
            //var maTrinhDo = await _trinhDoHocVanRepository.FindByIdAsync(request.MaTrinhDoHocVanId, cancellationToken);
            //if (maTrinhDo == null)
            //{
            //    throw new NotFoundException("TrinhDoHocVan Does Not Exist");
            //}

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
            return await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Success" : "Fail";

        }
    }
}
