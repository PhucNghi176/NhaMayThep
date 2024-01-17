using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommad : IRequest<string>
    {
        public DeleteLoaiCongTacCommad(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
