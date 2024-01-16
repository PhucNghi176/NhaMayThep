using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommand: IRequest<int> , ICommand
    {
        public DeleteThongTinCongDoanCommand(string id)
        {
            Id = id;
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
        public string Id { get; set; }
    }
}
