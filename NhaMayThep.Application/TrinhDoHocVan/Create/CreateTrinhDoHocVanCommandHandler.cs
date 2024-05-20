using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrinhDoHocVan.Create
{
    public class CreateTrinhDoHocVanCommandHandler : IRequestHandler<CreateTrinhDoHocVanCommand, string>
    {
        private readonly ITrinhDoHocVanRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public CreateTrinhDoHocVanCommandHandler(ICurrentUserService currentUserService, ITrinhDoHocVanRepository repository)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var existingTrinhDoHocVan = await _repository.FindAsync(x => x.Name == request.TenTrinhDo, cancellationToken);

            if (existingTrinhDoHocVan != null)
            {
                return "Đã tồn tại Trình Độ Học Vấn này!";
            }

            var trinhDoHocVanEntity = new TrinhDoHocVanEntity
            {
                Name = request.TenTrinhDo,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };

            _repository.Add(trinhDoHocVanEntity);


            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo Thành Công!";
        }
    }
}
