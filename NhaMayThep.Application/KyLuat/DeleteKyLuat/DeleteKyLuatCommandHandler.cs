using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.DeleteKyLuat
{
    public class DeleteKyLuatCommandHandler : IRequestHandler<DeleteKyLuatCommand, string>
    {
        private readonly IKyLuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public async Task<string> Handle(DeleteKyLuatCommand request, CancellationToken cancellationToken)
        {
            var kyluat = await this._repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (kyluat == null)
                return $"Không tìm thấy trường hợp kỷ luật với ID : {request.Id} hoặc trường hợp này đã bị xóa.";
            kyluat.NgayXoa = DateTime.UtcNow;
            kyluat.NguoiXoaID = this._currentUserService.UserId;
            this._repository.Update(kyluat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Xóa thành công trường hợp kỷ luật với ID : {request.Id}.";
        }
    }
}
