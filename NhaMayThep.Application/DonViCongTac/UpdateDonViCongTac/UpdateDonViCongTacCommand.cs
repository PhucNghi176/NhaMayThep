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
        public UpdateDonViCongTacCommand(int id, string name, string? nguoiCapNhatID)
        {
            ID = id;
            Name = name;
            NguoiCapNhatID = nguoiCapNhatID;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string? NguoiCapNhatID { get; set; }
    }
}
