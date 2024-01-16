using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac
{
    public class DeleteDonViCongTacCommand : IRequest<string>
    {
        public DeleteDonViCongTacCommand(int id, string? nguoiXoaID)
        {
            ID = id;
            NguoiXoaID = nguoiXoaID;
        }

        public int ID { get; set; }
        public string? NguoiXoaID { get; set; }
    }
}
