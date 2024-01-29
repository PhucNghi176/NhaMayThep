using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh
{
    public class RestoreThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<RestoreThongTinGiamTruGiaCanhCommand, string>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public RestoreThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICurrentUserService currentUserService,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }
        public async Task<string> Handle(RestoreThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository
                .FindAnyAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID != null && x.NgayXoa.HasValue, cancellationToken);
            if (thongtingiamtru == null)
            {
                throw new NotFoundException("Không tìm thấy thông tin miễn trừ gia cảnh này");
            }
            thongtingiamtru.NguoiXoaID = null;
            thongtingiamtru.NgayXoa = null;
            thongtingiamtru.NguoiCapNhatID = _currentUserService.UserId;
            thongtingiamtru.NgayCapNhatCuoi= DateTime.Now;
            _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
            try
            {
                await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Phục hồi thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình phục hồi");
            }
        }
    }
}
