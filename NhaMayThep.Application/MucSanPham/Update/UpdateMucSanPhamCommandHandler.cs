using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Update
{
    public class UpdateMucSanPhamCommandHandler : IRequestHandler<UpdateMucSanPhamCommand, string>
    {
        ICurrentUserService _currentUserService;
        IMucSanPhamRepository _mucSanPhamRepository;
        public UpdateMucSanPhamCommandHandler(ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }

        public async Task<string> Handle(UpdateMucSanPhamCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _mucSanPhamRepository.FindAnyAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }

            var existName = await _mucSanPhamRepository.AnyAsync(x => x.Name == command.Name && x.ID != command.ID && x.NguoiXoaID == null);
            if (existName)
            {
                throw new DuplicateNameException("Name của MucSanPham đã tồn tại");
            }

            existEntity.Name = command.Name;
            existEntity.LuongMucSanPham = command.LuongMucSanPham;
            existEntity.MucSanPhamToiDa = command.MucSanPhamToiDa;
            existEntity.MucSanPhamToiThieu = command.MucSanPhamToiThieu;
            existEntity.NgayCapNhat = DateTime.UtcNow;
            existEntity.NguoiCapNhatID = _currentUserService.UserId;
            _mucSanPhamRepository.Update(existEntity);
            return await _mucSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
