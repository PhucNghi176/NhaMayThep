using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.UpdateBaoHiem
{
    public class UpdateBaoHiemCommandHandler : IRequestHandler<UpdateBaoHiemCommand, string>
    {
        private readonly IBaoHiemRepository _baoHiemRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateBaoHiemCommandHandler(IBaoHiemRepository baoHiemRepository, ICurrentUserService currentUserService)
        {
            _baoHiemRepository = baoHiemRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateBaoHiemCommand command, CancellationToken cancellationToken)
        {
            var duplicate = await _baoHiemRepository.AnyAsync(x => x.Name == command.TenLoaiBaoHiem && x.NgayXoa == null, cancellationToken);
            if (duplicate)
                throw new NotFoundException("Đã có tên bảo hiểm này trong hệ thống");

            var update = await _baoHiemRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (update == null)
                throw new NotFoundException($"Không tìm thấy bảo hiểm với id: {command.Id}");

            update.Name = command.TenLoaiBaoHiem;
            update.PhanTramKhauTru = command.PhanTramKhauTru;
            update.NguoiCapNhatID = _currentUserService.UserId;
            update.NgayCapNhat = DateTime.Now;
            _baoHiemRepository.Update(update);
            if (await _baoHiemRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
