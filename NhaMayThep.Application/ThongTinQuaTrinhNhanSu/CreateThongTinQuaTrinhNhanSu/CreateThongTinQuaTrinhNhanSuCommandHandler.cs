using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.CreateThongTinQuaTrinhNhanSu
{
    public class CreateThongTinQuaTrinhNhanSuCommandHandler : IRequestHandler<CreateThongTinQuaTrinhNhanSuCommand, string>
    {
        private readonly IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateThongTinQuaTrinhNhanSuCommandHandler(ICurrentUserService currentUserService, IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _currentUserService = currentUserService;
            _thongTinQuaTrinhNhanSuRepository = thongTinQuaTrinhNhanSuRepository;
        }
        public async Task<string> Handle(CreateThongTinQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var existName = await _thongTinQuaTrinhNhanSuRepository.AnyAsync(x => x.Name == command.Name && x.NguoiXoaID == null, cancellationToken);
            if (existName == true)
            {
                throw new DuplicationException("Thông tin quá trình nhân sự: " + command.Name + " đã tồn tại");
            }
            ThongTinQuaTrinhNhanSuEntity entity = new ThongTinQuaTrinhNhanSuEntity()
            {
                Name = command.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow
            };
            _thongTinQuaTrinhNhanSuRepository.Add(entity);
            return await _thongTinQuaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
