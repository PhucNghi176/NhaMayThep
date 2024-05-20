using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MucSanPham.Update
{
    public class UpdateMucSanPhamCommandHandler : IRequestHandler<UpdateMucSanPhamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMucSanPhamRepository _mucSanPhamRepository;
        public UpdateMucSanPhamCommandHandler(ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }

        public async Task<string> Handle(UpdateMucSanPhamCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _mucSanPhamRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.LuongMucSanPham = command.LuongMucSanPham;
            existEntity.MucSanPhamToiDa = command.MucSanPhamToiDa;
            existEntity.MucSanPhamToiThieu = command.MucSanPhamToiThieu;
            existEntity.NgayCapNhatCuoi = DateTime.UtcNow;
            existEntity.NguoiCapNhatID = _currentUserService.UserId;
            _mucSanPhamRepository.Update(existEntity);
            return await _mucSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
