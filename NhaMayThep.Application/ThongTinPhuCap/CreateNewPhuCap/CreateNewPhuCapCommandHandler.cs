using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateNewPhuCap
{
    public class CreateNewPhuCapCommandHandler : IRequestHandler<CreateNewPhuCapCommand, int> 
    {
        private readonly IPhuCapRepository _phuCapRepository;
        public CreateNewPhuCapCommandHandler(IPhuCapRepository phuCapRepository)
        {
            _phuCapRepository = phuCapRepository;
        }
        public async Task<int> Handle(CreateNewPhuCapCommand command, CancellationToken cancellationToken)
        {
            var add = new ThongTinPhuCapEntity()
            {
                ID = 0,
                Name = command.TenPhuCap,
                PhanTramPhuCap = command.PhanTramPhuCap
            };
            _phuCapRepository.Add(add);
            await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.ID;
        }
    }
}
