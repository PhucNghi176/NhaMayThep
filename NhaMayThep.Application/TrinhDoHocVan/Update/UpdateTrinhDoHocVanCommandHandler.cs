using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class UpdateTrinhDoHocVanCommandHandler : IRequestHandler<UpdateTrinhDoHocVanCommand>
    {
        private readonly ITrinhDoHocVanRepository _repository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateTrinhDoHocVanCommandHandler(ICurrentUserService currentUserService ,ITrinhDoHocVanRepository repository)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task Handle(UpdateTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAnyAsync(x => x.ID == request.Id, cancellationToken);

            if (entity == null || entity.NgayXoa != null)
            {
                throw new NotFoundException("Trình Độ Học Vấn Không Tồn Tại");
            }
            if (entity != null)
            {
                entity.Name = request.TenTrinhDo;
                entity.NguoiCapNhatID = _currentUserService.UserId;
                entity.NgayCapNhat = DateTime.Now;

                await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
