using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommand : IRequest<ChinhSachNhanSuDto>, ICommand
    {
        public CreateChinhSachNhanSuCommand(string LoaiHinhThuc, string MucDo, DateTime NgayHieuLuc, string NoiDung)
        {
            this.LoaiHinhThuc = LoaiHinhThuc;
            this.MucDo = MucDo;
            this.NgayHieuLuc = NgayHieuLuc;
            this.NoiDung = NoiDung;
        }

        public string LoaiHinhThuc {  get; set; }
        public string MucDo {  get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung {  get; set; }
    }
}
