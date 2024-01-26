using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.UpdateKyLuat
{
    public class UpdateKyLuatCommand : IRequest<KyLuatDTO>,ICommand
    {
        public string ID {  get; set; }
        public string MaNhanVien {  get; set; }
        public int ChinhSachNhanSuID {  get; set; }
        public string TenDotKyLuat {  get; set; }
        public decimal TongPhat {  get; set; }
        public UpdateKyLuatCommand(string Id, string maNhanVien, int chinhSachNhanSuID, string tenDotKyLuat, decimal tongPhat)
        {
            ID = Id;
            MaNhanVien = maNhanVien;
            ChinhSachNhanSuID = chinhSachNhanSuID;
            TenDotKyLuat = tenDotKyLuat;
            TongPhat = tongPhat;
        }
        public UpdateKyLuatCommand() { }

    }
}
