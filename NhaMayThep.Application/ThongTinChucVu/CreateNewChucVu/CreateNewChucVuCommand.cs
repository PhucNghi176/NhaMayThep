using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu
{
    public class CreateNewChucVuCommand : IRequest<string>, ICommand
    {
        public CreateNewChucVuCommand(string tenChucVu)
        {
            TenChucVu = tenChucVu;
        }
        public string TenChucVu {  get; set; }
    }
}
