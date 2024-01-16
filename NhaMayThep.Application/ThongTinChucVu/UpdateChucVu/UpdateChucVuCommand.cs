using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.UpdateChucVu
{
    public class UpdateChucVuCommand : IRequest<ChucVuDto>, ICommand
    {
        public UpdateChucVuCommand() { }
        public UpdateChucVuCommand(int id, string tenChucVu)
        {
            Id = id;
            Name = tenChucVu;
        }

        public int Id { get; set; }
        public string Name {  get; set; }
    }
}
