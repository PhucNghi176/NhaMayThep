using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec
{
    public class UpdateTinhTrangLamViecCommandHandler : IRequestHandler<UpdateTinhTrangLamViecCommand, string>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateTinhTrangLamViecCommandHandler(ITinhTrangLamViecRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public UpdateTinhTrangLamViecCommandHandler() { }
        public async Task<string> Handle(UpdateTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (tinhtranglamviec == null)
                throw new NotFoundException($"không tìm thấy tình trạng làm việc với ID : {request.Id} hoặc nó đã bị xóa.");
            tinhtranglamviec.Name = request.Name ?? tinhtranglamviec.Name;
            tinhtranglamviec.NguoiCapNhatID = _currentUserService.UserId;
            tinhtranglamviec.NgayCapNhat = DateTime.UtcNow;
            _repository.Update(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return $"Cập nhật thành công tình trạng làm việc với ID : {request.Id}";
        }
    }
}
