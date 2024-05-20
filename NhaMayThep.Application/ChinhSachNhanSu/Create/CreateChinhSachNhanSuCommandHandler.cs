using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommandHandler : IRequestHandler<CreateChinhSachNhanSuCommand, string>
    {
        private readonly IChinhSachNhanSuRepository _chinhSachNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateChinhSachNhanSuCommandHandler(ICurrentUserService currentUserService, IChinhSachNhanSuRepository chinhSachNhanSuRepository)
        {
            _chinhSachNhanSuRepository = chinhSachNhanSuRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateChinhSachNhanSuCommand command, CancellationToken cancellationToken)
        {
            ChinhSachNhanSuEntity entity = new ChinhSachNhanSuEntity()
            {
                Name = command.Name,
                MucDo = command.MucDo,
                NgayHieuLuc = command.NgayHieuLuc,
                NoiDung = command.NoiDung,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow,
            };
            _chinhSachNhanSuRepository.Add(entity);
            return await _chinhSachNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
