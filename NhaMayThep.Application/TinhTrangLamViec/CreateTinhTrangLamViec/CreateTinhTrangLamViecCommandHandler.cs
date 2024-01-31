using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommandHandler : IRequestHandler<CreateTinhTrangLamViecCommand, string>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateTinhTrangLamViecCommandHandler(ITinhTrangLamViecRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public CreateTinhTrangLamViecCommandHandler() { }
        public async Task<string> Handle(CreateTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            if (await this._repository.FindAsync(x => x.Name.Equals(request.Name) && x.NgayXoa == null, cancellationToken) != null)
                throw new DuplicateNameException($"Đã tồn tại tình trạng làm việc có tên : {request.Name}.");
            var tinhtranglamviec = new TinhTrangLamViecEntity
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.UtcNow
            };
            _repository.Add(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return $"Tạo thành công tình trạng làm việc có tên : {request.Name}.";
        }
    }
}
