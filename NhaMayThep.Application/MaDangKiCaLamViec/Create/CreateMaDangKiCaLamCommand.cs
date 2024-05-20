using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Create
{
    public class CreateMaDangKiCaLamCommand : IRequest<string>, ICommand
    {
        public CreateMaDangKiCaLamCommand(string name, DateTime thoiGianCaLamBatDau, DateTime thoiGianCaLamKetThuc)
        {
            Name = name;
            ThoiGianCaLamBatDau = thoiGianCaLamBatDau;
            ThoiGianCaLamKetThuc = thoiGianCaLamKetThuc;
        }

        public string Name { get; set; }
        public DateTime ThoiGianCaLamBatDau { get; set; }
        public DateTime ThoiGianCaLamKetThuc { get; set; }
    }
}
