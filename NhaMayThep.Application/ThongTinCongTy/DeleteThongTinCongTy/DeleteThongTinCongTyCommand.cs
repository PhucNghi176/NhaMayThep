using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy
{
    public class DeleteThongTinCongTyCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinCongTyCommand(int maDoanhNghiep)
        {
            MaDoanhNghiep = maDoanhNghiep;
        }

        public int MaDoanhNghiep { get; set; }
    }
}