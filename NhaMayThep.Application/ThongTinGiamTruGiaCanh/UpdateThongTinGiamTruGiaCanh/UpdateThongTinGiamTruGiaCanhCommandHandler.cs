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
    public class UpdateThongTinGiamTruGiaCanhCommandHandler : IRequestHandler<UpdateThongTinGiamTruGiaCanhCommand, ThongTinGiamTruGiaCanhDto>
    {
        private readonly IThongTinGiamTruGiaCanhRepository _thongTinGiamTruGiaCanhRepository;
        private readonly IThongTinGiamTruRepository _thongTinGiamTruRepository;
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly IMapper _mapper;
        public UpdateThongTinGiamTruGiaCanhCommandHandler(
            IThongTinGiamTruRepository thongTinGiamTruRepository,
            IThongTinGiamTruGiaCanhRepository thongTinGiamTruGiaCanhRepository,
            ICanCuocCongDanRepository canCuocCongDanRepository,
            IMapper mapper)
        {
            _thongTinGiamTruGiaCanhRepository = thongTinGiamTruGiaCanhRepository;
            _thongTinGiamTruRepository = thongTinGiamTruRepository;
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinGiamTruGiaCanhDto> Handle(UpdateThongTinGiamTruGiaCanhCommand request, CancellationToken cancellationToken)
        {
            var giamtru = await _thongTinGiamTruRepository.FindAsync(x => x.ID == request.MaGiamTruID && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
            if (giamtru == null)
            {
                throw new NotFoundException("Giamtru does not exists");
            }
            var thongtingiamtru = await _thongTinGiamTruGiaCanhRepository.FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null && x.NgayXoa == null, cancellationToken);
            if (thongtingiamtru == null)
            {
                throw new NotFoundException("ThongTinGiamTruGiaCanh does not exists");
            }
            else
            {
                var cccd = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayXoa == null && x.NguoiXoaID == null, cancellationToken);
                if(cccd == null)
                {
                    throw new NotFoundException($"Can Cuoc Cong Dan {request.CanCuocCongDan} does not exists");
                }
                thongtingiamtru.NguoiCapNhatID = request.NguoiCapNhatid;
                thongtingiamtru.NgayCapNhatCuoi = DateTime.Now;
                thongtingiamtru.MaGiamTruID = giamtru.ID;
                thongtingiamtru.ThongTinGiamTru = giamtru;
                thongtingiamtru.DiaChiLienLac = request.DiaChiLienLac ?? thongtingiamtru.DiaChiLienLac;
                thongtingiamtru.QuanHeVoiNhanVien = request.QuanHeVoiNhanVien ?? thongtingiamtru.DiaChiLienLac;
                thongtingiamtru.CanCuocCongDan = cccd.CanCuocCongDan;
                thongtingiamtru.NgayXacNhanPhuThuoc = request.NgayXacNhanPhuThuoc;
                _thongTinGiamTruGiaCanhRepository.Update(thongtingiamtru);
                await _thongTinGiamTruGiaCanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return thongtingiamtru.MapToThongTinGiamTruGiaCanhDto(_mapper);
            }
        }
    }
}
