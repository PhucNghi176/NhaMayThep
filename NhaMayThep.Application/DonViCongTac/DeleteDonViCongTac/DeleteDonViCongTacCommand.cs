using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac
{
    public class DeleteDonViCongTacCommand : IRequest<DonViCongTacDto>
    {
        public DeleteDonViCongTacCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
