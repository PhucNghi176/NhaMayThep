using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Update
{
    public class UpdateKhaiBaoTangLuongCommandHandler : IRequestHandler<UpdateKhaiBaoTangLuongCommand, KhaiBaoTangLuongDto>
    {
        private IKhaiBaoTangLuongRepository _KhaiBaoTangLuongRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository KhaiBaoTangLuongRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _KhaiBaoTangLuongRepository = KhaiBaoTangLuongRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<KhaiBaoTangLuongDto> Handle(UpdateKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {


            var KhaiBaoTangLuong = await _KhaiBaoTangLuongRepository.FindAsync(x => x.ID == request.ID && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (KhaiBaoTangLuong == null)
                throw new NotFoundException("Khai Bao Tang Luong is not found");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            KhaiBaoTangLuong.PhanTramTang = request.PhanTramTang;
            KhaiBaoTangLuong.NgayApDung = request.NgayApDung;
            KhaiBaoTangLuong.LyDo = request.LyDo;
            KhaiBaoTangLuong.NguoiCapNhatID = _currentUserService.UserId;
            KhaiBaoTangLuong.NgayCapNhatCuoi = DateTime.Now;

            _KhaiBaoTangLuongRepository.Update(KhaiBaoTangLuong);
            await _KhaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return KhaiBaoTangLuong.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
