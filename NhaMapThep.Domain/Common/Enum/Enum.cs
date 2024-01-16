using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Common.Enum
{
    public enum Loai
    {
        TangLuong,
        GiamLuong
    }

    public enum LoaiHinhThuc
    {
        KhenThuong,
        KiLuat
    }

    public enum KhenThuong
    {
        TienThuong,
        GiayKhen,
        ThangTien,
        NgayNghi,
        QuaTang
    }

    public enum KiLuat
    {
        KhienTrach,
        CanhCao,
        HaLuong,
        PhatTien,
        GiangChuc,
        CachChuc,
        BuocThoiViec
    }
}
