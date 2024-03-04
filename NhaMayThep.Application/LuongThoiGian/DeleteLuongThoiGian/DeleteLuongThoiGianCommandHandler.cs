using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongThoiGian.DeleteLuongThoiGian
{
    public class DeleteLuongThoiGianCommandHandler : IRequestHandler<DeleteLuongThoiGianCommand, string>
    {
        private readonly ILuongThoiGianRepository _luongThoiGianRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteLuongThoiGianCommandHandler(
            ILuongThoiGianRepository luongThoiGianRepository,
            ICurrentUserService currentUserService)
        {
            _luongThoiGianRepository = luongThoiGianRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteLuongThoiGianCommand request, CancellationToken cancellationToken)
        {
            var luongThoiGian = await _luongThoiGianRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (luongThoiGian == null || (luongThoiGian.NguoiXoaID != null && luongThoiGian.NgayXoa.HasValue))
            {
                throw new NotFoundException("Lương thời gian không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            luongThoiGian.NguoiXoaID = _currentUserService.UserId;
            luongThoiGian.NgayXoa = DateTime.Now;
            _luongThoiGianRepository.Update(luongThoiGian);
            if (await _luongThoiGianRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
