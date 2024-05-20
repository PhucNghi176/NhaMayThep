using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LichSuNghiPhep.Create
{
    public class CreateLichSuNghiPhepCommand : IRequest<LichSuNghiPhepDto>, ICommand
    {
        public string MaSoNhanVien { get; set; }
        public int LoaiNghiPhepID { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string LyDo { get; set; }
        public string NguoiDuyet { get; set; }

    }
}
