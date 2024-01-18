using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinQuaTrinhNhanSu.GetSingleThongTinQuaTrinhNhanSu
{
    public class GetSingleThongTinQuaTrinhNhanSuQuery : IRequest<ThongTinQuaTrinhNhanSuDto>, IQuery
    {
        public GetSingleThongTinQuaTrinhNhanSuQuery(int id)
        {
            ID = id;
        }
        public int ID {  get; set; }
    }
}
