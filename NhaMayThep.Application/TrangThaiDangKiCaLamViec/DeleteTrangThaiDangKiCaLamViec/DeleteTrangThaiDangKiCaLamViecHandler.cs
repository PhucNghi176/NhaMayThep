using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec
{
    public class DeleteTrangThaiDangKiCaLamViecHandler : IRequestHandler<DeleteTrangThaiDangKiCaLamViecCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ITrangThaiDangKiCaLamViecRepository _trangThaiDangKiCaLamViecRepository;
        public readonly IMapper _mapper;

        public DeleteTrangThaiDangKiCaLamViecHandler(ITrangThaiDangKiCaLamViecRepository trangThaiDangKiCaLamViecRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _trangThaiDangKiCaLamViecRepository = trangThaiDangKiCaLamViecRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteTrangThaiDangKiCaLamViecCommand request, CancellationToken cancellationToken)
        {
            var trangThai = await _trangThaiDangKiCaLamViecRepository.FindAsync(x => x.ID == request.Id, cancellationToken);


            if (trangThai is null || trangThai.NgayXoa.HasValue)
            {
                return "Xóa Thất Bại";
            }

            trangThai.NguoiXoaID = _currentUserService.UserId;
            trangThai.NgayXoa = DateTime.Now;
            _trangThaiDangKiCaLamViecRepository.Update(trangThai);
            return await _trangThaiDangKiCaLamViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Thành Công" : "Xóa Thất Bại";
        }
    }
}
