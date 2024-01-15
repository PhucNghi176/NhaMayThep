using AutoMapper;
using NhaMapThep.Application.Common.Mappings;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac
{
    public class LoaiCongTacDto : IMapFrom<LoaiCongTacEntity>
    {

        public LoaiCongTacDto() { }

        public static LoaiCongTacDto Create(string name, int id)
        {
            return new LoaiCongTacDto() {  Name = name, Id = id };
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LoaiCongTacEntity,LoaiCongTacDto>();
        }
    }
}
