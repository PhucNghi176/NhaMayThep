using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Mappings;

namespace NhaMayThep.Application.PhuCapCongDoan
{
    public class PhuCapCongDoanDto : IMapFrom<PhuCapCongDoanEntity>
    {
        public PhuCapCongDoanDto()
        {

        }
        public string ID { get; set; }
        public int SoLuongDoanVien { get; set; }
        public float HeSoPhuCap { get; set; }
        public string DonVi { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhuCapCongDoanEntity, PhuCapCongDoanDto>();
        }
    }
}
