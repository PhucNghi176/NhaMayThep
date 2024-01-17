using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.CreateNewChucDanh
{
    public class CreateNewChucDanhCommand : IRequest<int>, ICommand
    {
        public CreateNewChucDanhCommand(string tenChucDanh)
        {
            TenChucDanh = tenChucDanh;
        }
        public string TenChucDanh {  get; set; }
    }
}
