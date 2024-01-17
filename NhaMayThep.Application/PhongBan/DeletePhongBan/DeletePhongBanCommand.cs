using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommand : IRequest<bool>, ICommand
    {
        public DeletePhongBanCommand(int id, string nguoiXoaID)
        {
            NguoiXoaID = nguoiXoaID;
            ID = id;
        }
        public string? NguoiXoaID { get; set; }

        public int ID { get; set; }
    }
}
