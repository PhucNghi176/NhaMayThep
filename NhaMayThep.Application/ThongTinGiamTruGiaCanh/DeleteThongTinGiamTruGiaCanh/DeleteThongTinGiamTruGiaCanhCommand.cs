using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommand: IRequest<string>, ICommand
    {
        public DeleteThongTinGiamTruGiaCanhCommand(string id) 
        {
            this.Id = id;   
        }
        public void NguoiXoa(string value)
        {
            NguoiXoaId = value;
        }
        public string? NguoiXoaid
        {
            get { return NguoiXoaId; }
        }
        private string? NguoiXoaId;
        public string Id { get;set; }
    }
}
