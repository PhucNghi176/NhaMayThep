using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinDaoTao.Delete
{
    public class DeleteThongTinDaoTaoCommandHandler : IRequestHandler<DeleteThongTinDaoTaoCommand, string>
    {
        private readonly IThongTinDaoTaoRepository _thongTinDaoTaoRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteThongTinDaoTaoCommandHandler(ICurrentUserService currentUserService ,IThongTinDaoTaoRepository thongTinDaoTaoRepository, IMapper mapper)
        {
            _thongTinDaoTaoRepository = thongTinDaoTaoRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteThongTinDaoTaoCommand request, CancellationToken cancellationToken)
        {
            var thongTinDaoTao = await _thongTinDaoTaoRepository.FindAnyAsync(x => x.ID == request.Id, cancellationToken);
            if (thongTinDaoTao == null || thongTinDaoTao.NgayXoa != null)
            {
                return "Xóa Thất Bại!";
            }
            thongTinDaoTao.NgayXoa = DateTime.Now;
            thongTinDaoTao.NguoiXoaID = _currentUserService.UserId;
            _thongTinDaoTaoRepository.Update(thongTinDaoTao);
            await _thongTinDaoTaoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Xóa Thành Công!";
        }
    }
}
