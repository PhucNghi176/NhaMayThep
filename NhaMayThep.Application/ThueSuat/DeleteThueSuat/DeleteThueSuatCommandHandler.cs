using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThueSuat.DeleteThueSuat
{
    public class DeleteThueSuatCommandHandler : IRequestHandler<DeleteThueSuatCommand, string>
    {
        private readonly IThueSuatRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteThueSuatCommandHandler(IThueSuatRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public DeleteThueSuatCommandHandler() { }
        public async Task<string> Handle(DeleteThueSuatCommand request, CancellationToken cancellationToken)
        {
            var thuesuat = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (thuesuat == null)
                throw new NotFoundException($"Không tìm thấy mục thuế với ID : {request.ID}");
            thuesuat.NguoiXoaID = this._currentUserService?.UserId;
            thuesuat.NgayXoa = DateTime.UtcNow;
            this._repository.Update(thuesuat);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return $"Xóa thành công mục thuế có ID :{request.ID}";
        }
    }
}
