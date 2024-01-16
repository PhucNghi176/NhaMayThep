using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommandHandler : IRequestHandler<DeletePhongBanCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPhongBanRepository _phongBanRepository;
        public DeletePhongBanCommandHandler(IPhongBanRepository phongBanRepository, IMapper mapper)
        {
            _phongBanRepository = phongBanRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeletePhongBanCommand command, CancellationToken cancellationToken)
        {
            var phongBan = _phongBanRepository.FindAsync(x => x.ID == command.ID).Result;
            phongBan.NgayXoa = DateTime.UtcNow;
            phongBan.NguoiXoaID = command.NguoiXoaID;
            _phongBanRepository.Update(phongBan);
            await _phongBanRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
