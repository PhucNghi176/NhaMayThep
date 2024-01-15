using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommand: IRequest<bool>, ICommand
    {
        public DeleteThongTinGiamTruGiaCanhCommand(string id) 
        {
            this.Id = id;   
        }    
        public string Id { get;set; }
    }
}
