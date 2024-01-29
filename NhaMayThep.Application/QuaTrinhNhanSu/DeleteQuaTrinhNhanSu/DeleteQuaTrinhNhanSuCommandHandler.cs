using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.Base;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.DeleteQuaTrinhNhanSu
{
    public class DeleteQuaTrinhNhanSuCommandHandler : IRequestHandler<DeleteQuaTrinhNhanSuCommand, string>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        ICurrentUserService _currentUserService;
        public DeleteQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }

        public async Task<string> Handle(DeleteQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _quaTrinhNhanSuRepository.FindAnyAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
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
