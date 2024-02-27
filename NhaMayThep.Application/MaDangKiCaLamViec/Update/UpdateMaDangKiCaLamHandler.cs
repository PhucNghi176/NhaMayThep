using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Update
{
    public class UpdateMaDangKiCaLamHandler : IRequestHandler<UpdateMaDangKiCaLamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public UpdateMaDangKiCaLamHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateMaDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var dangKi = await _maDangKiCaLamRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (dangKi == null || dangKi.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Đăng Kí trên Không Tồn Tại");
            }
            
            dangKi.Name = request.Name;
            dangKi.ThoiGianCaLamBatDau = request.ThoiGianCaLamBatDau;
            dangKi.ThoiGianCaLamKetThuc = request.ThoiGianCaLamKetThuc;

            dangKi.NguoiCapNhatID = _currentUserService.UserId;
            dangKi.NgayCapNhat = DateTime.Now;
            _maDangKiCaLamRepository.Update(dangKi);
            return await _maDangKiCaLamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập Nhật Thành Công" : "Cập Nhật Thất Bại";
        }
    }
}
