using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ThongTinGiamTruGiaCanh.DeleteThongTinGiamTruGiaCanh
{
    public class DeleteThongTinGiamTruGiaCanhCommand : IRequest<string>, ICommand
    {
        public DeleteThongTinGiamTruGiaCanhCommand(string id)
        {
            this.Id = id;
        }
<<<<<<< HEAD
        public string Id { get;set; }
=======
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
>>>>>>> origin/main
    }
}
