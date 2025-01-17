﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu
{
    public class DeleteQuaTrinhNhanSuCommandHandler : IRequestHandler<DeleteQuaTrinhNhanSuCommand, string>
    {
        private readonly IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }

        public async Task<string> Handle(DeleteQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _quaTrinhNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException("Quá trình nhân viên: " + command.ID + " không tồn tại");
            }
            entity.NguoiXoaID = _currentUserService.UserId;
            entity.NgayXoa = DateTime.UtcNow;
            _quaTrinhNhanSuRepository.Update(entity);
            return await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
