using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CanCuocCongDan.DeleteCanCuocCongDan
{
    public class DeleteCanCuocCongDanCommandHandler : IRequestHandler<DeleteCanCuocCongDanCommand, string>
    {
        private readonly ICanCuocCongDanRepository _canCuocCongDanRepository;

        public DeleteCanCuocCongDanCommandHandler(ICanCuocCongDanRepository canCuocCongDanRepository)
        {
            _canCuocCongDanRepository = canCuocCongDanRepository;
        }

        public async Task<string> Handle(DeleteCanCuocCongDanCommand request, CancellationToken cancellationToken)
        {
            var CanCuocCongDan = await _canCuocCongDanRepository.FindAsync(x => x.CanCuocCongDan == request.CanCuocCongDan, cancellationToken);
            if (CanCuocCongDan is not null)
            {
                if (CanCuocCongDan.NgayXoa != null)
                {
                    CanCuocCongDan.NgayXoa = DateTime.Now;
                    _canCuocCongDanRepository.Update(CanCuocCongDan);
                    return await 
                        _canCuocCongDanRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? 
                        "Xoa Thanh Cong" : "Xoa That Bai";
                }
            }
            throw new NotFoundException($"Khong Tim Thay CanCuocCongDan {request.CanCuocCongDan}");
        }
    }
}
