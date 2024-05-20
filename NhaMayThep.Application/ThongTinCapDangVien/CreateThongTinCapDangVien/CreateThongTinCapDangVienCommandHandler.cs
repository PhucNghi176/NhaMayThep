using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien
{
    public class CreateThongTinCapDangVienCommandHandler : IRequestHandler<CreateThongTinCapDangVienCommand, string>
    {
        private readonly IThongTinCapDangVienRepository _thongTinCapDangVienRepository;
        public CreateThongTinCapDangVienCommandHandler(IThongTinCapDangVienRepository thongTinCapDangVienRepository)
        {
            _thongTinCapDangVienRepository = thongTinCapDangVienRepository;
        }
        public async Task<string> Handle(CreateThongTinCapDangVienCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _thongTinCapDangVienRepository.AnyAsync(x => x.Name == request.TenCapDangVien && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Thông tin cấp đảng viên đã tồn tại");

            var thongTinCapDangVien = new ThongTinCapDangVienEntity()
            {
                Name = request.TenCapDangVien
            };

            _thongTinCapDangVienRepository.Add(thongTinCapDangVien);
            if (await _thongTinCapDangVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
