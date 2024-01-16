using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommand : IRequest<ThongTinGiamTruDTO>,ICommand
    {
        public int Id { get; set; } 
        public string idUser { get; set; }
        public string Name { get; set; }
        public decimal SoTienGiamTru { get; set; }
        public CreateThongTinGiamTruCommand(string idUser,int id, string name, decimal soTienGiamTru)
        {
            this.idUser = idUser;
            this.Id = id;
            this.Name = name;
            this.SoTienGiamTru = soTienGiamTru;
        }
    }
}
