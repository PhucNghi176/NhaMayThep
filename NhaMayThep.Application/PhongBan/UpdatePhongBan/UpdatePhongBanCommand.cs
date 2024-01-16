using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommand : IRequest<PhongBanDto>, ICommand
    {
        public UpdatePhongBanCommand(int id, string name, string? nguoiCapNhatID)
        {
            ID = id;
            Name = name;
            NguoiCapNhatID = nguoiCapNhatID;
        }
        public int ID { get; set; }
        public string Name {  get; set; }
        public string? NguoiCapNhatID {  get; set; }
    }
}
