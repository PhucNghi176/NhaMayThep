using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.BangLuong.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.Delete
{
    public class DeleteBangLuongCommandHandler : IRequestHandler<DeleteBangLuongCommand, string>
    {
        private IBangLuongRepository _BangLuongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteBangLuongCommandHandler(IBangLuongRepository BangLuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _BangLuongRepository = BangLuongRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteBangLuongCommand request, CancellationToken cancellationToken)
        {

            var BangLuong = await _BangLuongRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (BangLuong == null)
                throw new NotFoundException($"Không tìm thấy Bảng Lương ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            BangLuong.NguoiXoaID = _currentUserService.UserId;
            BangLuong.NgayXoa = DateTime.Now;

            _BangLuongRepository.Update(BangLuong);
            return await _BangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Bảng Lương thành công" : "Xóa Bảng Lương thất bại";
        }
    }
}
