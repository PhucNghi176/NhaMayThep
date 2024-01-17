using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrinhDoHocVan.Delete
{
    public class DeleteTrinhDoHocVanCommandHandler : IRequestHandler<DeleteTrinhDoHocVanCommand, string>
    {
        private readonly ITrinhDoHocVanRepository _trinhDoHocVanRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteTrinhDoHocVanCommandHandler(ICurrentUserService currentUserService ,ITrinhDoHocVanRepository trinhDoHocVanRepository, IMapper mapper)
        {
            _trinhDoHocVanRepository = trinhDoHocVanRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteTrinhDoHocVanCommand request, CancellationToken cancellationToken)
        {
            var trinhDoHocVan = await _trinhDoHocVanRepository.FindByIdAsync(request.Id, cancellationToken);
            if (trinhDoHocVan == null)
            {
                return "Fail";
            }
            trinhDoHocVan.NgayXoa = DateTime.Now;
            trinhDoHocVan.NguoiXoaID = _currentUserService.UserId;
            _trinhDoHocVanRepository.Update(trinhDoHocVan);
            await _trinhDoHocVanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Success";
        }
    }
}
