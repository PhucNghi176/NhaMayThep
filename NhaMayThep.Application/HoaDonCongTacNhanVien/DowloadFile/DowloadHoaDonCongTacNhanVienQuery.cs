using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.Common.Interfaces;


namespace NhaMayThep.Application.HoaDonCongTacNhanVien.DowloadFile
{
    public class DowloadHoaDonCongTacNhanVienQuery : IRequest<FileContentResult>, IQuery
    {
        public DowloadHoaDonCongTacNhanVienQuery(string filepath)
        {
            this.filepath = filepath;
        }

        public string filepath { get; set; }

    }
}
