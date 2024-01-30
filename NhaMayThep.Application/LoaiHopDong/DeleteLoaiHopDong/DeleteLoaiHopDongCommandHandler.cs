using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiHopDong.DeleteLoaiHopDong
{
    public class DeleteLoaiHopDongCommandHandler : IRequestHandler<DeleteLoaiHopDongCommand, string>
    {
        private readonly ILoaiHopDongReposity _loaiHopDongRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteLoaiHopDongCommandHandler(ILoaiHopDongReposity loaiHopDongRepository, ICurrentUserService currentUserService)
        {
            _loaiHopDongRepository = loaiHopDongRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteLoaiHopDongCommand command, CancellationToken cancellationToken)
        {
            var result = await _loaiHopDongRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Không tìm thấy loại hợp đồng với id: {command.Id}");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _loaiHopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Xóa thành công";
            else
                msg = "Xóa thất bại";
            return msg;
        }
    }
}
