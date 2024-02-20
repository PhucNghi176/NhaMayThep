using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThueSuat.UpdateThueSuat
{
    public class UpdateThueSuatCommandHandler : IRequestHandler<UpdateThueSuatCommand, string>
    {
        private readonly IThueSuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThueSuatCommandHandler(IThueSuatRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public UpdateThueSuatCommandHandler() { }
        public async Task<string> Handle(UpdateThueSuatCommand request, CancellationToken cancellationToken)
        {
            var thuesuat = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (thuesuat == null)
                throw new NotFoundException($"Không tìm thấy mục thuế với ID : {request.ID}");
            thuesuat.ThuNhapTinhThueTrenThang = request.ThuNhapTinhThueTrenThang;
            thuesuat.ThuNhapTinhThueTrenNam = request.ThuNhapTinhThueTrenNam;
            thuesuat.BacThue = request.BacThue;
            thuesuat.Name = request.Name;
            thuesuat.PhanTramThueSuat = request.PhanTramThueSuat;
            thuesuat.NguoiCapNhatID = this._currentUserService?.UserId;
            thuesuat.NgayCapNhat = DateTime.UtcNow;
            this._repository.Update(thuesuat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Cập nhật thành công mục thuế có ID : {request.ID}";
        }
    }
}
