
﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;

using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;


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
            if (await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
