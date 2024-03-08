using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri
{
    public class UpdateThongTinTrinhDoChinhTriCommandHandler : IRequestHandler<UpdateThongTinTrinhDoChinhTriCommand, string>
    {
        private readonly IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinTrinhDoChinhTriCommandHandler(IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository, ICurrentUserService currentUserService)
        {
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinTrinhDoChinhTriCommand request, CancellationToken cancellationToken)
        {
            var thongTinTrinhDoChinhTri = await _thongTinTrinhDoChinhTriRepository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (thongTinTrinhDoChinhTri == null || (thongTinTrinhDoChinhTri.NguoiXoaID != null && thongTinTrinhDoChinhTri.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin trình độ chính trị không tồn tại hoặc đã bị vô hiệu hóa");
            }

            var checkDuplicatoion = await _thongTinTrinhDoChinhTriRepository.AnyAsync(x => x.Name == request.TenTrinhDoChinhTri && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Tên trình độ chính trị đã tồn tại");

            thongTinTrinhDoChinhTri.Name = request.TenTrinhDoChinhTri;
            thongTinTrinhDoChinhTri.TrinhDoChinhTri = request.TrinhDoChinhTri;
            thongTinTrinhDoChinhTri.NguoiCapNhatID = _currentUserService.UserId;
            thongTinTrinhDoChinhTri.NgayCapNhat = DateTime.Now;
            _thongTinTrinhDoChinhTriRepository.Update(thongTinTrinhDoChinhTri);
            if (await _thongTinTrinhDoChinhTriRepository.UnitOfWork.SaveChangesAsync() > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
