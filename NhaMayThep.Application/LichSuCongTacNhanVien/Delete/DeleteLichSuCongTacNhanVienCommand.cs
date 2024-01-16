using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Delete
{
    public class DeleteLichSuCongTacNhanVienCommand: IRequest<string>
    {
        public DeleteLichSuCongTacNhanVienCommand(string id) 
        {
            Id = id;
        }
        public string Id { get; set; }

    }
}
