using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommand : IRequest<string>, ICommand
    {
        public UpdateChinhSachNhanSuCommand(int id, string name, string mucDo, DateTime ngayHieuLuc, string noiDung)
        {
            ID = id;
            Name = name;
            MucDo = mucDo;
            NgayHieuLuc = ngayHieuLuc;
            NoiDung = noiDung;
        }
        public int ID {  get; set; }
        public string Name {  get; set; }
        public string MucDo {  get; set; }
        public DateTime NgayHieuLuc {  get; set; }
        public string? NoiDung {  get; set; }
    }
}
