using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongCongNhat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Update
{
    public class UpdateLuongCongNhatCommandHandler : IRequestHandler<UpdateLuongCongNhatCommand, LuongCongNhatDto>
    {
        private ILuongCongNhatRepository _LuongCongNhatRepository;
        private INhanVienRepository _nhanVienRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLuongCongNhatCommandHandler(ILuongCongNhatRepository LuongCongNhatRepository, INhanVienRepository nhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _nhanVienRepository = nhanVienRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<LuongCongNhatDto> Handle(UpdateLuongCongNhatCommand request, CancellationToken cancellationToken)
        {


            var LuongCongNhat = await _LuongCongNhatRepository.FindAsync(x => x.MaSoNhanVien == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (LuongCongNhat == null)
                throw new NotFoundException("Dang Vien is not found");

            var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien && x.NgayXoa == null, cancellationToken: cancellationToken);
            if (nhanVien == null)
                throw new NotFoundException("Nhan Vien is not found");

            LuongCongNhat.SoGioLam = request.SoGioLam;
            LuongCongNhat.Luong1Gio = request.Luong1Gio;
            LuongCongNhat.TongLuong = request.TongLuong;
            LuongCongNhat.NguoiCapNhatID = _currentUserService.UserId;
            LuongCongNhat.NgayCapNhatCuoi = DateTime.Now;

            _LuongCongNhatRepository.Update(LuongCongNhat);
            await _LuongCongNhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return LuongCongNhat.MapToLuongCongNhatDto(_mapper);
        }
    }
}