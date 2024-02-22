using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
