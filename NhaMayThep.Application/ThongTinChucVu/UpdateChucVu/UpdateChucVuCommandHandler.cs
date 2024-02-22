using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinChucVu.UpdateChucVu
{
    public class UpdateChucVuCommandHandler : IRequestHandler<UpdateChucVuCommand, string>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateChucVuCommandHandler(IChucVuRepository chucVuRepository, ICurrentUserService currentUserService)
        {
            _chucVuRepository = chucVuRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateChucVuCommand command, CancellationToken cancellationToken)
        {
            var duplicate = await _chucVuRepository.AnyAsync(x => x.Name == command.Name && x.NgayXoa == null, cancellationToken);
            if (duplicate)
                throw new NotFoundException("Đã có tên chức vụ này trong hệ thống");

            var result = await _chucVuRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy chức vụ với id: {command.Id}");

            result.Name = command.Name;
            result.NguoiCapNhatID = _currentUserService.UserId;
            result.NgayCapNhat = DateTime.Now;
            _chucVuRepository.Update(result);

            if (await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";

        }
    }
}
