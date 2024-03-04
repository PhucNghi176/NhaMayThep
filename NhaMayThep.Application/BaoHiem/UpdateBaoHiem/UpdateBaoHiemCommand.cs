using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BaoHiem.UpdateBaoHiem
{
    public class UpdateBaoHiemCommand : IRequest<string>
    {
        public int Id { get; set; }
        public string TenLoaiBaoHiem {  get; set; }
        public double PhanTramKhauTru { get; set; }
        public UpdateBaoHiemCommand() { }
        public UpdateBaoHiemCommand(int id, string tenLoaiBaoHiem, double phanTramKhauTru)
        {
            Id = id;
            TenLoaiBaoHiem = tenLoaiBaoHiem;
            PhanTramKhauTru = phanTramKhauTru;
        }
    }
}
