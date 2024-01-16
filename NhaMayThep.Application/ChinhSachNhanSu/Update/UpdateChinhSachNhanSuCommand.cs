using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommand : IRequest<ChinhSachNhanSuDto>, ICommand
    {
        public int Id { get; set; }
        public string LoaiHinhThuc {  get; set; }
        public string MucDo {  get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string? NoiDung {  get; set; }

        public UpdateChinhSachNhanSuCommand(int id, string loaiHinhThuc, string mucDo, DateTime ngayHieuLuc, string? noiDung)
        {
            Id = id;
            LoaiHinhThuc = loaiHinhThuc;
            MucDo = mucDo;
            NgayHieuLuc = ngayHieuLuc;
            NoiDung = noiDung;
        }
    }
}
