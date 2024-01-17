using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.UpdateHopDongCommand
{
    public class UpdateHopDongCommand : IRequest<HopDongDto>, ICommand
    {
        public UpdateHopDongCommand(string id, int loaiHopDongId, DateTime ngayKyHopDong, DateTime ngayKetThucHopDong
                                                        , int thoiHanHopDong, string diaDiemLamViec, string boPhanLamViec, int chucDanhId
                                                        , int chucVuId, decimal luongCoBan, int heSoLuongId, string phuCapId
                                                        , string ghiChu)
        {
            Id = id;
            LoaiHopDongId = loaiHopDongId;
            NgayKyHopDong = ngayKyHopDong;
            NgayKetThucHopDong = ngayKetThucHopDong;
            ThoiHanHopDong = thoiHanHopDong;
            DiaDiemLamViec = diaDiemLamViec;
            BoPhanLamViec = boPhanLamViec;
            ChucDanhId = chucDanhId;
            ChucVuId = chucVuId;
            LuongCoBan = luongCoBan;
            HeSoLuongId = heSoLuongId;
            PhuCapId = phuCapId;
            GhiChu = ghiChu;
        }

        public string Id { get; set; }
        public int LoaiHopDongId { get; set; }
        public DateTime NgayKyHopDong { get; set; }
        public DateTime NgayKetThucHopDong { get; set; }
        public int ThoiHanHopDong { get; set; }
        public string DiaDiemLamViec { get; set; }
        public string BoPhanLamViec { get; set; }
        public int ChucDanhId { get; set; }
        public int ChucVuId { get; set; }
        public decimal LuongCoBan { get; set; }
        public int HeSoLuongId { get; set; }
        public string PhuCapId { get; set; }
        public string GhiChu { get; set; }
    }
}
