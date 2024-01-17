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
    public class DeleteTinhTrangLamViecCommandHandler : IRequestHandler<DeleteTinhTrangLamViecCommand, bool>
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
        public async Task<bool> Handle(DeleteTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.FindAsync(x => x.ID.Equals(request.Id), cancellationToken);
            if (tinhtranglamviec == null || tinhtranglamviec.NgayXoa != null)
                return false;
            tinhtranglamviec.NguoiXoaID = _userservicerepository.UserId;
            tinhtranglamviec.NgayXoa = DateTime.UtcNow;
            _repository.Update(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
