using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh
{
    public class UpdateChucDanhCommand : IRequest<ChucDanhDto>, ICommand
    {
        public UpdateChucDanhCommand() { }
        public UpdateChucDanhCommand(int id, string tenChucDanh)
        {
            Id = id;
            Name = tenChucDanh;
        }

        public int Id { get; set; }
        public string Name {  get; set; }
    }
}
