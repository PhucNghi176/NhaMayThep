using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommand : IRequest<ChiTietNgayNghiPhepDto>, ICommand
    {
        public string Id { get; set; } // This should be the GUID ID, not MaSoNhanVien
        public string NguoiXoaID { get; set; }
    }
}
