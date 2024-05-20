using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.Create
{
    public class CreateMucSanPhamCommandHandler : IRequestHandler<CreateMucSanPhamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        public CreateMucSanPhamCommandHandler(ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<string> Handle(CreateMucSanPhamCommand command, CancellationToken cancellationToken)
        {
            MucSanPhamEntity entity = new MucSanPhamEntity()
            {
                LuongMucSanPham = command.LuongMucSanPham,
                MucSanPhamToiDa = command.MucSanPhamToiDa,
                MucSanPhamToiThieu = command.MucSanPhamToiThieu,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = _currentUserService.UserId,
            };
            _mucSanPhamRepository.Add(entity);
            return await _mucSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
