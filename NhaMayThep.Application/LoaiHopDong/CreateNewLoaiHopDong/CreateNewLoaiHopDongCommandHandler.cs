﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.LoaiHopDong.CreateNewLoaiHopDong
{
    public class CreateNewLoaiHopDongCommandHandler : IRequestHandler<CreateNewLoaiHopDongCommand, string>

    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        public CreateNewLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
        }
        public async Task<string> Handle(CreateNewLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var isExisted = await _loaiHopDongRepository.AnyAsync(x => x.Name == command.TenHopDong && x.NgayXoa == null, cancellationToken);
            if (isExisted)
                throw new NotFoundException("Loại hợp đồng này đã tồn tại");
            var add = new LoaiHopDongEntity()
            {
                Name = command.TenHopDong
            };
            _loaiHopDongRepository.Add(add);
            if (await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
