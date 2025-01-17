﻿using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

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
            if (isExisted)
            {
                return $"Loại bảo hiểm {command.TenLoaiBaoHiem} đã tồn tại";
            }
            var add = new BaoHiemEntity()
            {
                Name = command.TenLoaiBaoHiem,
                PhanTramKhauTru = command.PhantramKhauTru
            };
            _baoHiemRepository.Add(add);
            if (await _baoHiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
