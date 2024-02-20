using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.DeleteNhanVienHangLoat
{
    public class DeleteNhanVienHangLoatCommandHandler : IRequestHandler<DeleteNhanVienHangLoatCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly INhanVienRepository _nhanVienRepository;

        public DeleteNhanVienHangLoatCommandHandler(ICurrentUserService currentUserService, INhanVienRepository nhanVienRepository)
        {
            _currentUserService = currentUserService;
            _nhanVienRepository = nhanVienRepository;
        }

        public async Task<string> Handle(DeleteNhanVienHangLoatCommand request, CancellationToken cancellationToken)
        {
            StringBuilder listNhanVienFail = new();
            foreach (var id in request.Ids)
            {
                var entity = await _nhanVienRepository.FindAsync(x => x.ID == id && x.NgayXoa == null, cancellationToken);
                if (entity != null)
                {
                    entity.NgayXoa = DateTime.UtcNow;
                    entity.NguoiXoaID = _currentUserService.UserId;
                    _nhanVienRepository.Update(entity);

                }
                else
                    listNhanVienFail.Append(id + ", ");
            }
            var result = await _nhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if (result > 0)
            {
                return listNhanVienFail.Length > 0 ? "Xóa thành công nhưng có nhân viên không tồn tại: \n " + listNhanVienFail.ToString() : "Xóa thành công";
            }
            else
            {
                return ("Xóa thất bại");
            }

        }
    }
}
