using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.GetPhuCapById
{
    public class GetPhuCapByIdQuery : IRequest<PhuCapDto>, IQuery
    {
        public int ID;
        public GetPhuCapByIdQuery(int id)
        {
            ID = id;
        }
    }
}
