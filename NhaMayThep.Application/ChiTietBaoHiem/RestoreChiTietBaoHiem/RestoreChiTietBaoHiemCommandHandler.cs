using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.RestoreChiTietBaoHiem
{
    public class RestoreChiTietBaoHiemCommandHandler : IRequestHandler<RestoreChiTietBaoHiemCommand, string>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly ICurrentUserService _currentUser;
        public RestoreChiTietBaoHiemCommandHandler(IChiTietBaoHiemRepository chitietbaohiemRepository, ICurrentUserService currentUser)
        {
            _chitietbaohiemRepository = chitietbaohiemRepository;
            _currentUser = currentUser;
        }

        public async Task<string> Handle(RestoreChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkEntityExists = await _chitietbaohiemRepository.FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID != null && x.NgayXoa.HasValue, cancellationToken);
            if(checkEntityExists == null)
            {
                throw new NotFoundException($"Không tồn tại chi tiết bảo hiểm nào với Id '{request.Id}' bị xóa");
            }
            checkEntityExists.NguoiXoaID = null;
            checkEntityExists.NgayXoa = null;
            checkEntityExists.NguoiCapNhatID = _currentUser.UserId;
            checkEntityExists.NgayCapNhatCuoi = DateTime.Now;
            _chitietbaohiemRepository.Update(checkEntityExists);
            var result = await _chitietbaohiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            if(result > 0)
            {
                return "Phục hồi thành công";
            }
            else
            {
                return "Phục hồi thất bại";
            }
        }
    }
}
