﻿using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan
{
    public class DeleteCanCuocCongDanCommandHandler : IRequestHandler<DeleteCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository, ICurrentUserService currentUserService)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan && x.NgayXoa == null, cancellationToken);
            if (CanCuocCongDan is not null)
            {
                CanCuocCongDan.NgayXoa = DateTime.Now;
                CanCuocCongDan.NguoiXoaID = _currentUserService.UserId;
                _canCuocCongDanRepository.Update(CanCuocCongDan);
                return await
                    _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ?
                    "Xoa Thanh Cong" : "Xoa That Bai";
            }
            else
                throw new NotFoundException($"Khong Tim Thay CanCuocCongDan {request.CanCuocCongDan}");
        }
    }
}
