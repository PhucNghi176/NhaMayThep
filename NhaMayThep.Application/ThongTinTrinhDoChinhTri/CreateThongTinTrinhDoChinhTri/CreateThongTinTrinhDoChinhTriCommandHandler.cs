using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri
{
    public class CreateThongTinTrinhDoChinhTriCommandHandler : IRequestHandler<CreateThongTinTrinhDoChinhTriCommand, string>
    {
        private readonly IThongTinTrinhDoChinhTriRepository _thongTinTrinhDoChinhTriRepository;
        public CreateThongTinTrinhDoChinhTriCommandHandler(IThongTinTrinhDoChinhTriRepository thongTinTrinhDoChinhTriRepository)
        {
            _thongTinTrinhDoChinhTriRepository = thongTinTrinhDoChinhTriRepository;
        }
        public async Task<string> Handle(CreateThongTinTrinhDoChinhTriCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _thongTinTrinhDoChinhTriRepository.AnyAsync(x => x.Name == request.TenTrinhDoChinhTri && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Thông tin trình độ chính trị đã tồn tại");

            var thongTinTrinhDoChinhTri = new ThongTinTrinhDoChinhTriEntity()
            {
                Name = request.TenTrinhDoChinhTri,
                TrinhDoChinhTri = request.TrinhDoChinhTri
            };

            _thongTinTrinhDoChinhTriRepository.Add(thongTinTrinhDoChinhTri);
            if (await _thongTinTrinhDoChinhTriRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
