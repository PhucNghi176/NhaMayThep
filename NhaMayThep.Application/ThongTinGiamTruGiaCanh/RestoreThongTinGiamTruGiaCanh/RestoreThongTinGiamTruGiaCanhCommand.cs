using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.RestoreThongTinGiamTruGiaCanh
{
    public class RestoreThongTinGiamTruGiaCanhCommand: IRequest<string>, ICommand
    {
        public RestoreThongTinGiamTruGiaCanhCommand(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
    }
}
