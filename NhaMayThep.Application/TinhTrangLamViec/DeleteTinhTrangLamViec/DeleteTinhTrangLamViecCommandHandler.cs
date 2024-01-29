using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommandHandler : IRequestHandler<DeleteTinhTrangLamViecCommand, string>
    {
        private readonly ITinhTrangLamViecRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _userservicerepository;
        public DeleteTinhTrangLamViecCommandHandler(ITinhTrangLamViecRepository repository, IMapper mapper,ICurrentUserService userservicerepository)
        {
            _repository = repository;
            _mapper = mapper;
            _userservicerepository = userservicerepository;
        }
        public DeleteTinhTrangLamViecCommandHandler() { }
        public async Task<string> Handle(DeleteTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.FindAnyAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (tinhtranglamviec == null || tinhtranglamviec.NgayXoa != null)
                return $"Không tìm thấy tình trạng làm việc với ID : {request.Id} hoặc tình trạng làm việc này đã bị xóa.";
            tinhtranglamviec.NguoiXoaID = _userservicerepository.UserId;
            tinhtranglamviec.NgayXoa = DateTime.UtcNow;
            _repository.Update(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return $"Xóa thành công tình trạng làm việc với ID :{request.Id}";
        }
    }
}
