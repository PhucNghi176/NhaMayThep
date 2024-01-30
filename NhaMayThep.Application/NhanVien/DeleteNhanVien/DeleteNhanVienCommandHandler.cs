using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVien
{
    public class DeleteNhanVienCommandHandler : IRequestHandler<DeleteNhanVienCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteNhanVienCommandHandler(INhanVienRepository nhanVienRepository, ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteNhanVienCommand command, CancellationToken cancellationToken)
        {
            var found = await _nhanVienRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (found == null)
                throw new NotFoundException("Id nhân viên không tồn tại");
            found.NguoiXoaID = _currentUserService.UserId;
            found.NgayXoa = DateTime.Now;
            _nhanVienRepository.Update(found);
            if (await _nhanVienRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
