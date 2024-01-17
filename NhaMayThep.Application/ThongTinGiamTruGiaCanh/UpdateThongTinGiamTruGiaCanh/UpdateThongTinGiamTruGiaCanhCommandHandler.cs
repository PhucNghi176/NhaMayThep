using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.UpdateThongTinGiamTruGiaCanh
{
    public class UpdateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<UpdateThongTinGiamTruGiaCanhCommand, string>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICanCuocCongDanRepository canCuocCongDanRepository,
            IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var giamtru = await _thongTinGiamTruRepository
                .FindAsync(x => x.ID.Equals(request.MaGiamTruID), cancellationToken);
            if (giamtru == null || (giamtru.NguoiXoaID != null && giamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin giảm trừ không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var thongtingiamtruCur = await _thongTinGiamTruGiaCanhRepository
                .FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan, cancellationToken);
            if (thongtingiamtruCur != null || (thongtingiamtruCur != null && thongtingiamtruCur.NguoiXoaID != null && thongtingiamtruCur.NgayXoa.HasValue))
            {
                throw new NotFoundException("Căn cước công dân này đã có thông tin miễn trừ gia cảnh hoặc đã bị vô hiệu hóa trước đó");
            }
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository
                .FindAsync(x => x.ID.Equals(request.Id),cancellationToken);
            if (thongtingiamtru == null ||(thongtingiamtru.NguoiXoaID != null && thongtingiamtru.NgayXoa.HasValue))
            {
                throw new NotFoundException("Thông tin giảm trừ gia cảnh không tồn tại hoặc đã bị vô hiệu hóa");
            }
            var cccd = await _canCuocCongDanRepository
                    .FindAsync(x => x.CanCuocCongDan.Equals(request.CanCuocCongDan), cancellationToken);
            if (cccd == null || (cccd.NguoiXoaID != null && cccd.NgayXoa.HasValue))
            {
                throw new NotFoundException($"Căn cước công dân {request.CanCuocCongDan} không tồn tại hoặc đã bị vô hiệu hóa trước đó");
            }
            thongtingiamtru.NguoiCapNhatID = _currentUserService.UserId;
            thongtingiamtru.NgayCapNhatCuoi = DateTime.Now;
            thongtingiamtru.MaGiamTruID = giamtru.ID;
            thongtingiamtru.ThongTinGiamTru = giamtru;
            thongtingiamtru.DiaChiLienLac = request.DiaChiLienLac ?? thongtingiamtru.DiaChiLienLac;
            thongtingiamtru.QuanHeVoiNhanVien = request.QuanHeVoiNhanVien ?? thongtingiamtru.DiaChiLienLac;
            thongtingiamtru.CanCuocCongDan = cccd.CanCuocCongDan;
            thongtingiamtru.NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc;
            _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
            try
            {
                await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Cập nhật thành công";
            }
            catch (Exception)
            {
                throw new NotFoundException("Đã xảy ra lỗi trong quá trình cập nhật");
            }
        }
    }
}
