using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMapThep.Application.TrinhDoHocVan.Commands
{
    public class CreateTrinhDoHocVanCommandHandler : IRequestHandler<CreateTrinhDoHocVanCommand, string>
    {
        private readonly ITrinhDoHocVanRepository _repository;
        private readonly ICurrentUserService _currentUserService;

        public CreateTrinhDoHocVanCommandHandler(ICurrentUserService currentUserService ,ITrinhDoHocVanRepository repository)
        {
            _repository = repository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var trinhDoHocVanEntity = new TrinhDoHocVanEntity
            {
                Name = request.TenTrinhDo,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
                // Set other properties as needed
            };

            _repository.Add(trinhDoHocVanEntity);


             await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Success";
        }
    }
}
