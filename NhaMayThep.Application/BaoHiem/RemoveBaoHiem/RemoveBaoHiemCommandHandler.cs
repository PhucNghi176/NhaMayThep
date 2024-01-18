using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.RemoveBaoHiem
{
    public class RemoveBaoHiemCommandHandler : IRequestHandler<RemoveBaoHiemCommand, string>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly ICurrentUserService _currentUserService;
        public RemoveBaoHiemCommandHandler(IBaoHiemRepository baoHiemRepository, ICurrentUserService currentUserService)
        {
            _baoHiemRepository = baoHiemRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(RemoveBaoHiemCommand command, CancellationToken cancellationToken)
        {
            var remove = await _baoHiemRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (remove == null)
                throw new NotFoundException($"Not found Bao hiem with id: {command.Id}");
            remove.NgayXoa = DateTime.Now;
            remove.NguoiXoaID = _currentUserService.UserId;
            if (await _baoHiemRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Remove Successfully";
            else
                return "Remove Failed";
        }
    }
}
