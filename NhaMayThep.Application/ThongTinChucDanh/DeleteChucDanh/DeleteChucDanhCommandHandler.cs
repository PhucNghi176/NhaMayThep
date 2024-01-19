using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
namespace NhaMayThep.Application.ThongTinChucDanh.DeleteChucDanh
{
    public class DeleteChucDanhCommandHandler : IRequestHandler<DeleteChucDanhCommand, string>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeleteChucDanhCommandHandler(IChucDanhRepository chucDanhRepository, ICurrentUserService currentUserService)
        {
            _chucDanhRepository = chucDanhRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteChucDanhCommand command, CancellationToken cancellationToken)
        {
            var result = await _chucDanhRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Chuc danh with {command.Id} not found");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Remove Successfully";
            else
                msg = "Remove Failed";
            return msg;
        }
    }
}
