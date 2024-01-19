using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.CreateNewBaoHiem
{
    public class CreateNewBaoHiemCommandHandler : IRequestHandler<CreateNewBaoHiemCommand, string>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        public CreateNewBaoHiemCommandHandler(IBaoHiemRepository baoHiemRepository)
        {
            _baoHiemRepository = baoHiemRepository;
        }
        public async Task<string> Handle(CreateNewBaoHiemCommand command, CancellationToken cancellationToken)
        {
            var isExisted = await _baoHiemRepository.AnyAsync(x => x.Name == command.TenLoaiBaoHiem && x.NgayXoa == null, cancellationToken);
            if(isExisted)
            {
                return $"This {command.TenLoaiBaoHiem} is already existed";
            }
            var add = new BaoHiemEntity()
            {
                Name = command.TenLoaiBaoHiem,
                PhanTramKhauTru = command.PhantramKhauTru
            };
            _baoHiemRepository.Add(add);
            if (await _baoHiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Add Successful, Bao hiem id is: {add.ID}";
            else
                return "Add Failed";
        }
    }
}
