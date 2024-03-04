using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhuCapCongDoan.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhuCapCongDoan.Delete
{
    public class DeletePhuCapCongDoanCommandHandler : IRequestHandler<DeletePhuCapCongDoanCommand, string>
    {
        ICurrentUserService _currentUserService;
        IPhuCapCongDoanRepository _PhuCapCongDoanRepository;
        public DeletePhuCapCongDoanCommandHandler(ICurrentUserService currentUserService, IPhuCapCongDoanRepository PhuCapCongDoanRepository)
        {
            _currentUserService = currentUserService;
            _PhuCapCongDoanRepository = PhuCapCongDoanRepository;
        }
        public async Task<string> Handle(DeletePhuCapCongDoanCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _PhuCapCongDoanRepository.FindAsync(x => x.ID == command.ID && x.NguoiXoaID == null);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.NgayXoa = DateTime.UtcNow;
            existEntity.NguoiXoaID = _currentUserService.UserId;
            _PhuCapCongDoanRepository.Update(existEntity);
            return await _PhuCapCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Phụ Cấp Công Đoàn thành công" : "Xóa Phụ Cấp Công Đoàn thất bại";
        }
    }
}
