using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.DeleteHopDongCommand
{
    public class DeleteHopDongCommandHandler : IRequestHandler<DeleteHopDongCommand, string>
    {
        private readonly IHopDongRepository _hopdongRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteHopDongCommandHandler(IHopDongRepository hopdongRepository, ICurrentUserService currentUserService)
        {
            _hopdongRepository = hopdongRepository; 
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteHopDongCommand command, CancellationToken cancellationToken)
        {
            var status = "";
            var result = await _hopdongRepository.FindAnyAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy hợp đồng với id: {command.Id}");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _hopdongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                status = "Xóa thành công";
            else 
                status = "Xóa thất bại";

            return status;
        }
    }
}
