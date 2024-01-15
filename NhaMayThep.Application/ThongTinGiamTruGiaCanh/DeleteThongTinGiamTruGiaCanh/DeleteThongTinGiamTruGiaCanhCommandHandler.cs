using MediatR;
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
    public class DeleteThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<DeleteThongTinGiamTruGiaCanhCommand, bool>
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
        public async Task<bool> Handle(DeleteThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository.FindById(request.Id, cancellationToken);
            if(thongtingiamtru == null)
            {
                throw new NotFoundException("ThongTinGiamTruGiaCanh does not exists");
            }
            else
            {
                thongtingiamtru.NguoiXoaID = _currentUserService.UserId ?? "0571cc1357c64e75a9907c37a366bfd3"; //Not authorize
                thongtingiamtru.NgayXoa = DateTime.Now;
                _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
                var result = await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
