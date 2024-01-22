using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommandHandler : IRequestHandler<DeleteThongTinCongTyCommand, string>
    {
        private readonly IThongTinCongTyRepository _thongTinCongTyRepository;

        public DeleteThongTinCongTyCommandHandler(IThongTinCongTyRepository thongTinCongTyRepository)
        {
            _thongTinCongTyRepository = thongTinCongTyRepository;
        }

        public async Task<string> Handle(DeleteThongTinCongTyCommand request, CancellationToken cancellationToken)
        {
            var thongTinCongTy = await _thongTinCongTyRepository.FindAsync(t => t.MaDoanhNghiep == request.MaDoanhNghiep, cancellationToken);

            if (thongTinCongTy is null)
                throw new NotFoundException($"Khong tim thay MaDoanhNghiep {request.MaDoanhNghiep}");

            _thongTinCongTyRepository.Remove(thongTinCongTy);

            return await _thongTinCongTyRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xoa thanh cong" : "Xoa that bai";
        }
    }
}