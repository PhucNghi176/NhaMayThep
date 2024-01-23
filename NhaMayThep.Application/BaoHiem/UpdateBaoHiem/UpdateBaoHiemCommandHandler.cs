using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.UpdateBaoHiem
{
    public class UpdateBaoHiemCommandHandler : IRequestHandler<UpdateBaoHiemCommand, BaoHiemDto>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly IMapper _mapper;
        public UpdateBaoHiemCommandHandler(IBaoHiemRepository baoHiemRepository, IMapper mapper)
        {
            _baoHiemRepository = baoHiemRepository;
            _mapper = mapper;
        }
        public async Task<BaoHiemDto> Handle(UpdateBaoHiemCommand command, CancellationToken cancellationToken)
        {
            var update = await _baoHiemRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (update == null)
                throw new NotFoundException($"Bao hiem with id: {command.Id} not found");
            update.Name = command.TenLoaiBaoHiem;
            update.PhanTramKhauTru = command.PhanTramKhauTru;
            _baoHiemRepository.Update(update);
            if (await _baoHiemRepository.UnitOfWork.SaveChangesAsync() > 0)
                return update.MapToBaoHiemDto(_mapper);
            else
                throw new Exception("Update Failed");
        }
    }
}
