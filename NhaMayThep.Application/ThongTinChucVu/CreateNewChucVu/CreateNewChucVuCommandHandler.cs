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

namespace NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu
{
    public class CreateNewChucVuCommandHandler : IRequestHandler<CreateNewChucVuCommand, int> 
    {
        private readonly IChucVuRepository _chucVuRepository;
        public CreateNewChucVuCommandHandler(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }
        public async Task<int> Handle(CreateNewChucVuCommand command, CancellationToken cancellationToken)
        {
            var add = new ThongTinChucVuEntity()
            {
                Name = command.TenChucVu
            };
            _chucVuRepository.Add(add);
            await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.ID;
        }
    }
}
