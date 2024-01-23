using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = await _chucDanhRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            var msg = "";
            if (result == null)
                throw new NotFoundException($"Không tìm thấy chức danh với id: {command.Id}");
            result.NgayXoa = DateTime.Now;
            result.NguoiXoaID = _currentUserService.UserId;
            if (await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                msg = "Xóa thành công";
            else
                msg = "Xóa thất bại";
            return msg;
        } 
    }
}
