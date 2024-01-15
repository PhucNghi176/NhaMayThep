using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommand : IRequest<QuaTrinhNhanSuDto>, ICommand
    {
        public CreateQuaTrinhNhanSuCommand(string maSoNhanVien
            , int LoaiQuaTrinhID
            , DateTime ngayBatDau
            , DateTime? ngayKetThuc
            , int phongBanID
            , int chucVuId
            , int chucDanhID
            , string? ghiChu)
        {
            
        }
        public string MaSoNhanVien { get; set; }
        public int LoaiQuaTrinhID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public int PhongBanID { get; set; }
        public int ChucVuID { get; set; }
        public int ChucDanhID { get; set; }
        public string? GhiChu { get; set; }
    }
}
