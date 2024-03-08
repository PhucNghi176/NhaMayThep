using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.CreateThueSuat
{
    public class CreateThueSuatCommandHandler : IRequestHandler<CreateThueSuatCommand, string>
    {
        private readonly IThueSuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateThueSuatCommandHandler(IThueSuatRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public CreateThueSuatCommandHandler() { }
        public async Task<string> Handle(CreateThueSuatCommand request, CancellationToken cancellationToken)
        {
            var thuesuat = new ThueSuatEntity
            {
                Name = request.name,
                BacThue = request.BacThue,
                DauThuNhapTinhThueTrenNam = request.DauThuNhapTinhThueTrenNam,
                CuoiThuNhapTinhThueTrenNam = request.CuoiThuNhapTinhThueTrenNam,
                DauThuNhapTinhThueTrenThang = request.DauThuNhapTinhThueTrenThang,
                CuoiThuNhapTinhThueTrenThang = request.CuoiThuNhapTinhThueTrenThang,
                PhanTramThueSuat = request.PhanTramThueSuat,
                NguoiTaoID = this._currentUserService?.UserId,
                NgayTao = DateTime.UtcNow,
            };
            this._repository.Add(thuesuat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Tạo thành công mục thuế suất có tên {request.name}";
        }
    }
}
