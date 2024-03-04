using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Update
{
    public class UpdateMaDangKiCaLamCommand : IRequest<string>, ICommand
    {
        public UpdateMaDangKiCaLamCommand(int id, string name, DateTime thoiGianCaLamBatDau, DateTime thoiGianCaLamKetThuc)
        {
            Id = id;
            Name = name;
            ThoiGianCaLamBatDau = thoiGianCaLamBatDau;
            ThoiGianCaLamKetThuc = thoiGianCaLamKetThuc;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ThoiGianCaLamBatDau {  get; set; }
        public DateTime ThoiGianCaLamKetThuc {  get; set; }
    }
}
