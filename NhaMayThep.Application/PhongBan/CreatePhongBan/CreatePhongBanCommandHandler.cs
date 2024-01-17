using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;


namespace NhaMayThep.Application.PhongBan.CreatePhongBan
{
    public class CreatePhongBanCommandHandler : IRequestHandler<CreatePhongBanCommand, bool>
    {
        private readonly IPhongBanRepository _phongBanRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePhongBanCommandHandler(IPhongBanRepository phongBanRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _phongBanRepository = phongBanRepository;
        }
        public async Task<bool> Handle(CreatePhongBanCommand command, CancellationToken cancellationToken)
        {
            var existName = await _phongBanRepository.FindAsync(x => x.Name == command.Name && x.NguoiXoaID == null);
            if (existName != null)
            {
                throw new DuplicateNameException("Tên phòng ban: " + command.Name + " đã tồn tại");
            }

            PhongBanEntity entity = new PhongBanEntity()
            {
                Name = command.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow              
            };
            _phongBanRepository.Add(entity);
            return await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : false;
        }
    }
}
