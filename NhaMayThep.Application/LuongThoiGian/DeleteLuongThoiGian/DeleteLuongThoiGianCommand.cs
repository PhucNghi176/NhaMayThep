using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LuongThoiGian.DeleteLuongThoiGian
{
    public class DeleteLuongThoiGianCommand : IRequest<string>, ICommand
    {
        public string Id { get; set; }
        public DeleteLuongThoiGianCommand(string id)
        {
            Id = id;
        }
    }
}
