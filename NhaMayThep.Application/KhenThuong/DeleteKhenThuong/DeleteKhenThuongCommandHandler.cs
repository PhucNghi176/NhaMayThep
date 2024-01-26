using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.KhenThuong.DeleteKhenThuong
{
    public class DeleteKhenThuongCommandHandler : IRequestHandler<DeleteKhenThuongCommand, bool>
    {
        private readonly IKhenThuongRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteKhenThuongCommandHandler(IKhenThuongRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public DeleteKhenThuongCommandHandler() { }
        public async Task<bool> Handle(DeleteKhenThuongCommand request, CancellationToken cancellationToken)
        {
            var khenthuong = await this._repository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (khenthuong == null)
                return false;
            khenthuong.NgayXoa = DateTime.UtcNow;
            khenthuong.NguoiXoaID = this._currentUserService.UserId;
            this._repository.Update(khenthuong);
            await this._repository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
