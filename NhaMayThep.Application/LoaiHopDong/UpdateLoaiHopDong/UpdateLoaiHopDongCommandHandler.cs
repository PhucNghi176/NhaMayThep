using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.UpdateLoaiHopDong
{
    public class UpdateLoaiHopDongCommandHandler : IRequestHandler<UpdateLoaiHopDongCommand, string>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository, ICurrentUserService currentUserService)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var duplicate = await _loaiHopDongRepository.AnyAsync(x => x.Name == command.TenHopDong && x.NgayXoa == null, cancellationToken);
            if (duplicate)
                throw new NotFoundException("Đã có tên loại hợp đồng này trong hệ thống");

            var result = await _loaiHopDongRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy loại hợp đồng với id: {command.Id}");

            result.Name = command.TenHopDong;
            result.NguoiCapNhatID = _currentUserService.UserId;
            result.NgayCapNhat = DateTime.Now;
            _loaiHopDongRepository.Update(result);

            if (await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
