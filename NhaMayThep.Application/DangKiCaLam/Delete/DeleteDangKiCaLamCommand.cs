using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiCaLam.Delete
{
    public class DeleteDangKiCaLamCommand : IRequest<DangKiCaLamDto>,ICommand
    {
        public int MaCaLamViec { get; set; }

        public DeleteDangKiCaLamCommand(int maCaLamViec)
        {
            MaCaLamViec = maCaLamViec;
        }
    }
}
