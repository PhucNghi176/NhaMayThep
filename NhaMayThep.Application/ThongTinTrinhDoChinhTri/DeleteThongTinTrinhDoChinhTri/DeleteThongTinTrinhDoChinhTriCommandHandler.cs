using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri
{
    public class DeleteThongTinTrinhDoChinhTriCommandHandler : IRequestHandler<DeleteThongTinTrinhDoChinhTriCommand, string>
    {
        private readonly IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinTrinhDoChinhTriCommandHandler(IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository, ICurrentUserService currentUserService)
        {
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinTrinhDoChinhTriCommand request, CancellationToken cancellationToken)
        {
            var thongTinTrinhDoChinhTri = await _thongTinTrinhDoChinhTriRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinTrinhDoChinhTri == null || (thongTinTrinhDoChinhTri.NguoiXoaID != null && thongTinTrinhDoChinhTri.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin trình độ chính trị không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongTinTrinhDoChinhTri.NguoiXoaID = _currentUserService.UserId;
            thongTinTrinhDoChinhTri.NgayXoa = DateTime.Now;
            _thongTinTrinhDoChinhTriRepository.Update(thongTinTrinhDoChinhTri);
            if (await _thongTinTrinhDoChinhTriRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Xóa thành công";
            else
                return "Xóa thất bại";
        }
    }
}
