using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinDaoTao.Delete
{
    public class DeleteThongTinDaoTaoCommandHandler : IRequestHandler<DeleteThongTinDaoTaoCommand, string>
    {
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly IMapper _mapper;

        public DeleteThongTinDaoTaoCommandHandler(IThongTinDaoTaoRepository thongTinDaoTaoRepository, IMapper mapper)
        {
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindByIdAsync(request.Id, cancellationToken);
            if (thongTinDaoTao == null)
            {
                return "Fail";
            }
            thongTinDaoTao.NgayXoa = DateTime.Now;
            _thongTinDaoTaoRepository.Update(thongTinDaoTao);
            await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Success";
        }
    }
}
