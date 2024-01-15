using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac
{
    public class DonViCongTacDto : IMapFrom<DonViCongTacEntity>
    {
        public DonViCongTacDto()
        {
        }

        public int ID { get; set; }
        public string Name { get; set; }

        public static DonViCongTacDto Create(int id, string name)
        {
            return new DonViCongTacDto
            {
                ID = id,
                Name = name
            };
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DonViCongTacEntity, DonViCongTacDto>();
        }
    }
}
