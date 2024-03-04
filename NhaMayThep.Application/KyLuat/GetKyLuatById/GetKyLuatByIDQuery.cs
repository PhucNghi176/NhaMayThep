using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.GetKyLuatById
{
    public class GetKyLuatByIDQuery : IRequest<KyLuatDTO>
    {
        public string Id {  get; set; }
        public GetKyLuatByIDQuery(string id)
        {
            Id = id;
        }
        public GetKyLuatByIDQuery() { }
    }
}
