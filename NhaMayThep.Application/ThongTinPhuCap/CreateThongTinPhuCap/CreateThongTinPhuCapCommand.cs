using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.CreateThongTinPhuCap
{
    public class CreateThongTinPhuCapCommand : IRequest<ThongTinPhuCapDTO>,ICommand
    {
        public int id {  get; set; }
        public string name { get; set; }
        public decimal SoTienPhuCap { get; set; }
        public CreateThongTinPhuCapCommand(int id, string name, decimal SoTienPhuCap)
        {
            this.id = id;
            this.name = name;
            this.SoTienPhuCap = SoTienPhuCap;
        }

    }
}
