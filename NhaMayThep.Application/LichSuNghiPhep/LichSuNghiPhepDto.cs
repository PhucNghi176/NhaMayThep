using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;

public class LichSuNghiPhepDto : IMapFrom<LichSuNghiPhepNhanVienEntity>
{
    public string MaSoNhanVien { get; set; }
    public int LoaiNghiPhepID { get; set; } 
    public DateTime NgayBatDau { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public string LyDo { get; set; }
    public string NguoiDuyet { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepDto>();
    }
}
