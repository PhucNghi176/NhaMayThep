using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Delete
{
    public class DeleteMaDangKiCaLamHandler : IRequestHandler<DeleteMaDangKiCaLamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public DeleteMaDangKiCaLamHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteMaDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var dangKi = await _maDangKiCaLamRepository.FindAsync(x => x.ID == request.Id, cancellationToken);


            if (dangKi is null || dangKi.NgayXoa.HasValue)
            {
                return "Xóa Thất Bại";
            }

            dangKi.NguoiXoaID = _currentUserService.UserId;
            dangKi.NgayXoa = DateTime.Now;
            _maDangKiCaLamRepository.Update(dangKi);
            return await _maDangKiCaLamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Thành Công" : "Xóa Thất Bại";
            
        }
    }
}
