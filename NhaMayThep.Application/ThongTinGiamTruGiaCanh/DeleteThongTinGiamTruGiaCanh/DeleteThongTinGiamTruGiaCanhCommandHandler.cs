using MediatR;
using NhaMapThep.Application.Common.Models;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<DeleteThongTinGiamTruGiaCanhCommand, string>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICurrentUserService currentUserService)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository
                .FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if(thongtingiamtru == null || (thongtingiamtru.NguoiXoaID != null && thongtingiamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin giảm trừ gia cảnh không tồn tại hoặc đã bị xóa trước đó");
            }
            thongtingiamtru.NguoiXoaID = _currentUserService.UserId;
            thongtingiamtru.NgayXoa = DateTime.Now;
            _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
            try
            {
                await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Xóa thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình xóa");
            }
        }
    }
}
