using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Delete
{
    public class DeleteMucSanPhamCommandHandler : IRequestHandler<DeleteMucSanPhamCommand, string>
    {
        ICurrentUserService _currentUserService;
        IMucSanPhamRepository _mucSanPhamRepository;
        public DeleteMucSanPhamCommandHandler(ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<string> Handle(DeleteMucSanPhamCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _mucSanPhamRepository.FindAnyAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.NgayXoa = DateTime.UtcNow;
            existEntity.NguoiXoaID = _currentUserService.UserId;
            _mucSanPhamRepository.Update(existEntity);
            return await _mucSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
