using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh
{
    public class CreateNewChucDanhCommandHandler : IRequestHandler<CreateNewChucDanhCommand, string> 
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        public CreateNewChucDanhCommandHandler(IChucDanhRepository chucDanhRepository)
        {
            _chucDanhRepository = chucDanhRepository;
        }
        public async Task<string> Handle(CreateNewChucDanhCommand command, CancellationToken cancellationToken)
        {
            var isExisted = await _chucDanhRepository.AnyAsync(x => x.Name == command.TenChucDanh && x.NgayXoa == null, cancellationToken);
            if (isExisted)
                throw new NotFoundException("Chức danh này đã tồn tại");
            var add = new ThongTinChucDanhEntity()
            {
                Name = command.TenChucDanh
            };
            _chucDanhRepository.Add(add);
            await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo thành công";
        }
    }
}
