using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;


namespace NhaMayThep.Application.BaoHiemNhanVien.Delete
{
    public class DeleteBaoHiemNhanVienCommand : IRequest<string>, ICommand
    {
        public DeleteBaoHiemNhanVienCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
