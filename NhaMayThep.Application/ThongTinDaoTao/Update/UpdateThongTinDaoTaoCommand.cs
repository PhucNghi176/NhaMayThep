using NhaMayThep.Application.Common.Interfaces;
using MediatR;
using System;
using System.Text.Json.Serialization;

namespace NhaMayThep.Application.ThongTinDaoTao.Update
{
    public class UpdateThongTinDaoTaoCommand : IRequest<ThongTinDaoTaoDto>, ICommand
    {
        public UpdateThongTinDaoTaoCommand(string tenTruong, string chuyenNganh, DateTime namTotNghiep, int trinhDoVanHoa, int maTrinhDoHocVanId)
        {

            MaTrinhDoHocVanId = maTrinhDoHocVanId;
            TenTruong = tenTruong;
            ChuyenNganh = chuyenNganh;
            NamTotNghiep = namTotNghiep;
            TrinhDoVanHoa = trinhDoVanHoa;
        }

        public string Id { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }
        public int MaTrinhDoHocVanId { get; set; }

    }
}
