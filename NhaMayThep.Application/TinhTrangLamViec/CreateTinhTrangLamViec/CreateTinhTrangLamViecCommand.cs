using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.CreateTinhTrangLamViec
{
    public class CreateTinhTrangLamViecCommand : IRequest<TinhTrangLamViecDTO>,ICommand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NguoiTaoID { get; set; }
        public CreateTinhTrangLamViecCommand(int iD, string name, string nguoiTaoID)
        {
            ID = iD;
            Name = name;
            NguoiTaoID = nguoiTaoID;
        }
    }
}
