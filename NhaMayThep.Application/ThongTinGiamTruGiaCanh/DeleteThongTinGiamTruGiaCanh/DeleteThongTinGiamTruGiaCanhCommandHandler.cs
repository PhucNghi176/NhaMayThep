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
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository.FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if(thongtingiamtru == null)
            {
                throw new NotFoundException("ThongTinGiamTruGiaCanh does not exists");
            }
            else
            {
                thongtingiamtru.NguoiXoaID = request.NguoiXoaid;
                thongtingiamtru.NgayXoa = DateTime.Now;
                _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
                var result = await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                if (result > 0)
                {
                    return "Delete Successfully!";
                }
                else
                {
                    return "Delete Failed!";
                }
            }
        }
    }
}
