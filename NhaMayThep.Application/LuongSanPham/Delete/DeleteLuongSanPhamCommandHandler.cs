using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongSanPham.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongSanPham.Delete
{
    public class DeleteLuongSanPhamCommandHandler : IRequestHandler<DeleteLuongSanPhamCommand, string>
    {
        private ILuongSanPhamRepository _LuongSanPhamRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteLuongSanPhamCommandHandler(ILuongSanPhamRepository LuongSanPhamRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _LuongSanPhamRepository = LuongSanPhamRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteLuongSanPhamCommand request, CancellationToken cancellationToken)
        {

            var LuongSanPham = await _LuongSanPhamRepository.FindAsync(x => x.ID == request.ID);
            if (LuongSanPham == null)
                throw new NotFoundException("Luong San Pham is not found");

            LuongSanPham.NguoiXoaID = _currentUserService.UserId;
            LuongSanPham.NgayXoa = DateTime.Now;

            _LuongSanPhamRepository.Update(LuongSanPham);
            await _LuongSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Delete Successfully";
        }
    }
}