using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
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
    public class CreateNewPhuCapCommandHandler : IRequestHandler<CreateNewPhuCapCommand, string> 
    {
        private readonly IPhuCapRepository _phuCapRepository;
        public CreateNewPhuCapCommandHandler(IPhuCapRepository phuCapRepository)
        {
            _phuCapRepository = phuCapRepository;
        }
        public async Task<string> Handle(CreateNewPhuCapCommand command, CancellationToken cancellationToken)
        {
            var isExisted = await _phuCapRepository.AnyAsync(x => x.Name == command.TenPhuCap && x.NgayXoa == null, cancellationToken);
            if (isExisted)
                throw new NotFoundException("Phụ cấp đã tồn tại");
            var add = new ThongTinPhuCapEntity()
            {
                Name = command.TenPhuCap,
                PhanTramPhuCap = command.PhanTramPhuCap
            };
            _phuCapRepository.Add(add);
            await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo thành công";
        }
    }
}
