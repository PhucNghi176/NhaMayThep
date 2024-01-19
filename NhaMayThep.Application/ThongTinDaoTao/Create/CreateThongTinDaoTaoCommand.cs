using MediatR;
using System;
using NhaMayThep.Application.Common.Interfaces;


namespace NhaMayThep.Application.ThongTinDaoTao.Create
{
    public class CreateThongTinDaoTaoCommand : IRequest<string>, ICommand
    {
        public CreateThongTinDaoTaoCommand(string nhanVienId, int maTrinhDoHocVanId, string tenTruong, string chuyenNganh, DateTime namTotNghiep, int trinhDoVanHoa)
        {
            NhanVienId = nhanVienId;
            MaTrinhDoHocVanId = maTrinhDoHocVanId;
            TenTruong = tenTruong;
            ChuyenNganh = chuyenNganh;
            NamTotNghiep = namTotNghiep;
            TrinhDoVanHoa = trinhDoVanHoa;
        }

        public string NhanVienId { get; set; }
        public int MaTrinhDoHocVanId { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }
    }
}
