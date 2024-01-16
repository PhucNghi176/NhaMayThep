using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommand : IRequest, ICommand
    {
        public DeletePhongBanCommand(int id, string? nguoiXoaID)
        {
            ID = id;
            NguoiXoaID = nguoiXoaID;
        }
        public int ID { get; set; }
        public string? NguoiXoaID { get; set; }

    }
}
