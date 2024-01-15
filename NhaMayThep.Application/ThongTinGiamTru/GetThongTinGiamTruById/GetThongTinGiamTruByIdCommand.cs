using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdCommand : IRequest<ThongTinGiamTruDTO>
    {
        public int Id { get; set; }
        public GetThongTinGiamTruByIdCommand(int id)
        {
            Id = id;
        }
    }
}
