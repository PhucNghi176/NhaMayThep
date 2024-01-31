using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhaiBaoTangLuong.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommandHandler : IRequestHandler<DeleteKhaiBaoTangLuongCommand, string>
    {
        private IKhaiBaoTangLuongRepository _KhaiBaoTangLuongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository KhaiBaoTangLuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _KhaiBaoTangLuongRepository = KhaiBaoTangLuongRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var KhaiBaoTangLuong = await this._KhaiBaoTangLuongRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (KhaiBaoTangLuong == null)
                return $"Không tìm thấy mục Khai Báo Tăng Lương với ID : {request.ID} hoặc mục này đã bị xóa.";

            KhaiBaoTangLuong.NguoiXoaID = _currentUserService.UserId;
            KhaiBaoTangLuong.NgayXoa = DateTime.Now;

            _KhaiBaoTangLuongRepository.Update(KhaiBaoTangLuong);
            await _KhaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Xóa Khai Báo Tăng Lương thành công";
        }
    }
}