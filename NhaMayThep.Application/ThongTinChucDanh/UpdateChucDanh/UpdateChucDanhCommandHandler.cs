using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh
{
    public class UpdateChucDanhCommandHandler : IRequestHandler<UpdateChucDanhCommand, string>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateChucDanhCommandHandler(IChucDanhRepository chucDanhRepository, ICurrentUserService currentUserService)
        {
            _chucDanhRepository = chucDanhRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateChucDanhCommand command, CancellationToken cancellationToken)
        {
            var duplicate = await _chucDanhRepository.AnyAsync(x => x.Name == command.Name && x.NgayXoa == null, cancellationToken);
            if (duplicate)
                throw new NotFoundException("Đã có tên chức danh này trong hệ thống");

            var result = await _chucDanhRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy chức danh với id: {command.Id}");

            result.Name = command.Name;
            result.NguoiCapNhatID = _currentUserService.UserId;
            result.NgayCapNhat = DateTime.Now;
            _chucDanhRepository.Update(result);

            if (await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
