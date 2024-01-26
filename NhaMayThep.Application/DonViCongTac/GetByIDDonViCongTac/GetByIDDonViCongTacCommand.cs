using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.GetByIDDonViCongTac
{
    public class GetByIDDonViCongTacCommand : IRequest<DonViCongTacDto>
    {
        public GetByIDDonViCongTacCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    
    }
}
