using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac
{
    public class UpdateDonViCongTacCommand : IRequest<DonViCongTacDto>, ICommand
    {
        public UpdateDonViCongTacCommand( string name )
        { 
            Name = name;
        }

        public void RouteId(int value)
        {
            ID = value;
        }

        public int Id { get { return ID; } }
        private int ID;
        public string Name { get; set; }


    }
}
