using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.DeleteLoaiHopDong
{
    public class DeleteLoaiHopDongCommandHandler : IRequestHandler<DeleteLoaiHopDongCommand, string>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        public DeleteLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
        }
        public async Task<string> Handle(DeleteLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var result = await _loaiHopDongRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Loai hop dong with {command.Id} not found");
            result.NgayXoa = DateTime.Now;
            if (await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Remove Successfully";
            else
                msg = "Remove Failed";
            return msg;
        } 
    }
}
