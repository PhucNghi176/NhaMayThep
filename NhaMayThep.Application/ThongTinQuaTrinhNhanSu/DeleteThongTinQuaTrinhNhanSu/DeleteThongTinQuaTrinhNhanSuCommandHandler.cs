using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.DeleteThongTinQuaTrinhNhanSu
{
    public class DeleteThongTinQuaTrinhNhanSuCommandHandler : IRequestHandler<DeleteThongTinQuaTrinhNhanSuCommand, string>
    {
        IThongTinQuaTrinhNhanSuRepository _thongTinQuaTrinhNhanSuRepository;
        ICurrentUserService _currentUserService;
        public DeleteThongTinQuaTrinhNhanSuCommandHandler(ICurrentUserService currentUserService, IThongTinQuaTrinhNhanSuRepository thongTinQuaTrinhNhanSuRepository)
        {
            _currentUserService = currentUserService;
            _thongTinQuaTrinhNhanSuRepository = thongTinQuaTrinhNhanSuRepository;
        }
        public async Task<string> Handle(DeleteThongTinQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = await _thongTinQuaTrinhNhanSuRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (entity == null)
            {
                throw new NotFoundException("Thông tin quá trình nhân sự không tồn tại");
            }
            entity.NgayXoa = DateTime.UtcNow;
            entity.NguoiXoaID = _currentUserService.UserId;
            _thongTinQuaTrinhNhanSuRepository.Update(entity);
            return await _thongTinQuaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
