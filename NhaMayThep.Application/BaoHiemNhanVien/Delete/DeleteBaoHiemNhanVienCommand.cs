using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;


namespace NhaMayThep.Application.BaoHiemNhanVien.Delete
{
    public class DeleteBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public DeleteBaoHiemNhanVienCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
