using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhiCongDoan.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhiCongDoan.Delete
{
    public class DeletePhiCongDoanCommandHandler : IRequestHandler<DeletePhiCongDoanCommand, string>
    {
        private IPhiCongDoanRepository _PhiCongDoanRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeletePhiCongDoanCommandHandler(IPhiCongDoanRepository PhiCongDoanRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _PhiCongDoanRepository = PhiCongDoanRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeletePhiCongDoanCommand request, CancellationToken cancellationToken)
        {

            var PhiCongDoan = await _PhiCongDoanRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (PhiCongDoan == null)
                throw new NotFoundException($"Không tìm thấy Phí Công Đoàn với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            PhiCongDoan.NguoiXoaID = _currentUserService.UserId;
            PhiCongDoan.NgayXoa = DateTime.Now;

            _PhiCongDoanRepository.Update(PhiCongDoan);
            return await _PhiCongDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Phí Công Đoàn thành công" : "Xóa Phí Công Đoàn thất bại";
        }
    }
}
