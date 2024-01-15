using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommandHandler : IRequestHandler<CreateNewLoaiHopDongCommand, int> 
    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        public CreateNewLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
        }
        public async Task<int> Handle(CreateNewLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var add = new LoaiHopDongEntity()
            {
                ID = 0,
                Name = command.TenHopDong
            };
            _loaiHopDongRepository.Add(add);
            await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return add.ID;
        }
    }
}
