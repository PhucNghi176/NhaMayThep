using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang
{
    public class CreateThongTinChucVuDangCommandHandler : IRequestHandler<CreateThongTinChucVuDangCommand, string>
    {
        private readonly IThongTinChucVuDangRepository _thongTinChucVuDangRepository;
        public CreateThongTinChucVuDangCommandHandler(IThongTinChucVuDangRepository thongTinChucVuDangRepository)
        {
            _thongTinChucVuDangRepository = thongTinChucVuDangRepository;
        }
        public async Task<string> Handle(CreateThongTinChucVuDangCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _thongTinChucVuDangRepository.AnyAsync(x => x.Name == request.TenChucVuDang && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Thông tin chức vụ đảng đã tồn tại");

            var thongTinChucVuDang = new ThongTinChucVuDangEntity()
            {
                Name = request.TenChucVuDang,
                ChucVuDang = request.ChucVuDang
            };

            _thongTinChucVuDangRepository.Add(thongTinChucVuDang);
            if (await _thongTinChucVuDangRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
