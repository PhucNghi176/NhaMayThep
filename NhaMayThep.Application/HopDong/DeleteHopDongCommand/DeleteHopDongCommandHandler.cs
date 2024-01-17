using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommandHandler : IRequestHandler<DeleteHopDongCommand, string>
    {
        private readonly IHopDongRepository _hopdongRepository;
        public DeleteHopDongCommandHandler(IHopDongRepository hopdongRepository, IMapper mapper)
        {
            _hopdongRepository = hopdongRepository;
        }
        public async Task<string> Handle(DeleteHopDongCommand command, CancellationToken cancellationToken)
        {
            var status = "";
            var result = await _hopdongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Not found Hop dong{command.Id}");
            result.NgayXoa = DateTime.Now;
            if (await _hopdongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                status = "Remove Successfully";
            else
                status = "Remove Failed";
            return status;
        }
    }
}
