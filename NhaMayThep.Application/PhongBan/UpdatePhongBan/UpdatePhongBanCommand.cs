using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.UpdatePhongBan
{
    public class UpdatePhongBanCommand : IRequest<string>, ICommand
    {
        public UpdatePhongBanCommand(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public void NguoiCapNhat(string? value)
        {
            NguoiCapNhatID = value;
        }
        
        public string? NguoiCapNhatID {  get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
