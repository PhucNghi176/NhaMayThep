using AutoMapper;
using NhaMayThep.Application.Common.Exceptions;
using NhaMayThep.Domain.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.ThongTinDaoTao.Update
{
    public class UpdateThongTinDaoTaoCommandHandler : IRequestHandler<UpdateThongTinDaoTaoCommand, ThongTinDaoTaoDto>
    {
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly IMapper _mapper;

        public UpdateThongTinDaoTaoCommandHandler(IThongTinDaoTaoRepository thongTinDaoTaoRepository, IMapper mapper)
        {
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _mapper = mapper;
        }

        public async Task<ThongTinDaoTaoDto> Handle(UpdateThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindByIdAsync(request.Id, cancellationToken);
            if (thongTinDaoTao == null)
            {
                throw new NotFoundException("ThongTinDaoTao Does Not Exist");
            }

            thongTinDaoTao.TenTruong = request.TenTruong;
            thongTinDaoTao.ChuyenNganh = request.ChuyenNganh;
            thongTinDaoTao.NamTotNghiep = request.NamTotNghiep;
            thongTinDaoTao.TrinhDoVanHoa = request.TrinhDoVanHoa;

            _thongTinDaoTaoRepository.Update(thongTinDaoTao);
            await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ThongTinDaoTaoDto>(thongTinDaoTao);
        }
    }
}
