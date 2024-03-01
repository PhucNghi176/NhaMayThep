using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietBaoHiem.DeleteChiTietBaoHiem
{
    public class DeleteChiTietBaoHiemCommandHandler : IRequestHandler<DeleteChiTietBaoHiemCommand, string>
    {
        private readonly IChiTietBaoHiemRepository _chitietbaohiemRepository;
        private readonly ICurrentUserService _currentuser;
        public DeleteChiTietBaoHiemCommandHandler(IChiTietBaoHiemRepository chiTietBaoHiemRepository,
            ICurrentUserService currentUser)
        {
            _chitietbaohiemRepository = chiTietBaoHiemRepository;
            _currentuser = currentUser;
        }
        public async Task<string> Handle(DeleteChiTietBaoHiemCommand request, CancellationToken cancellationToken)
        {
            var checkEntityExists= await _chitietbaohiemRepository.FindAsync(x=> x.ID.Equals(request.Id) && x.NguoiXoaID == null && !x.NgayXoa.HasValue,cancellationToken);
            if(checkEntityExists == null)
            {
                throw new NotFoundException($"Không tồn tại chi tiết báo hiểm với Id '{request.Id}'");
            }
            checkEntityExists.NguoiXoaID = _currentuser.UserId;
            checkEntityExists.NgayXoa = DateTime.Now;
            _chitietbaohiemRepository.Update(checkEntityExists);
            var result =await _chitietbaohiemRepository.UnitOfWork.SaveChangesAsync(cancellationToken); 
            if(result >0 )
            {
                return "Xóa thành công";
            }
            else
            {
                return "Xóa thất bại";
            }
        }
    }
}
