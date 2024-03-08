using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.CreateCapBacLuong
{
    public class CreateCapBacLuongCommandHandler : IRequestHandler<CreateCapBacLuongCommand, string>
    {
        private readonly ICapBacLuongRepository _capBacLuongRepository;
        public CreateCapBacLuongCommandHandler(ICapBacLuongRepository capBacLuongRepository)
        {
            _capBacLuongRepository = capBacLuongRepository;
        }
        public async Task<string> Handle(CreateCapBacLuongCommand request, CancellationToken cancellationToken)
        {
            var checkDuplicatoion = await _capBacLuongRepository.AnyAsync(x => x.Name == request.TenCapBac && x.NgayXoa == null, cancellationToken);
            if (checkDuplicatoion)
                throw new DuplicationException("Cấp bậc lương đã tồn tại");

            var capBacLuong = new CapBacLuongEntity()
            {
                Name = request.TenCapBac,
                HeSoLuong = request.HeSoLuong,
                TrinhDo = request.TrinhDo
            };

            _capBacLuongRepository.Add(capBacLuong);
            if (await _capBacLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
