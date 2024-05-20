using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNgayNghiPhepCommand : IRequest<ChiTietNgayNghiPhepDto>, ICommand
    {
        public string Id { get; set; } // Use this as the primary key

        public int LoaiNghiPhepID { get; set; }
        public double TongSoGio { get; set; }
        public double SoGioDaNghiPhep { get; set; }
        public double SoGioConLai { get; set; }
        public int NamHieuLuc { get; set; }

    }
}
