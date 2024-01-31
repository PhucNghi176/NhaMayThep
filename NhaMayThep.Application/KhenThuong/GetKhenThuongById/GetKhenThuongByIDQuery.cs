using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.GetKhenThuongById
{
    public class GetKhenThuongByIDQuery : IRequest<KhenThuongDTO>, ICommand
    {
        public string ID {  get; set; }
        public GetKhenThuongByIDQuery(string iD)
        {
            ID = iD;
        }
        public GetKhenThuongByIDQuery() { }
    }
}
