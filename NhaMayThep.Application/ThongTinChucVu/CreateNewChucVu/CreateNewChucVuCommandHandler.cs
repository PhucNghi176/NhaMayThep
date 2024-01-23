
﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;

using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu
{
    public class CreateNewChucVuCommandHandler : IRequestHandler<CreateNewChucVuCommand, string> 

    {
        private readonly IChucVuRepository _chucVuRepository;
        public CreateNewChucVuCommandHandler(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }
        public async Task<string> Handle(CreateNewChucVuCommand command, CancellationToken cancellationToken)
        {
            var isExisted = await _chucVuRepository.AnyAsync(x => x.Name == command.TenChucVu && x.NgayXoa == null, cancellationToken);
            if (isExisted)
                throw new NotFoundException("Chức vụ này đã tồn tại");
            var add = new ThongTinChucVuEntity()
            {
                Name = command.TenChucVu
            };
            _chucVuRepository.Add(add);
            await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo thành công";
        }
    }
}
