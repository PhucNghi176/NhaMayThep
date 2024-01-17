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

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommandHandler : IRequestHandler<DeleteLoaiHoaDonCommand, string>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository,
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = await _LoaiHoaDonRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiHoaDon is null ||loaiHoaDon.NgayXoa.HasValue)
            {
                return "Xóa Thất Bại";
            }
           
                loaiHoaDon.NguoiXoaID = _currentUserService.UserId;
                loaiHoaDon.NgayXoa = DateTime.Now;
                _LoaiHoaDonRepository.Update(loaiHoaDon);
                await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Xóa Thành Công";
           
        }
    }
}
