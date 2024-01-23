using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;


namespace NhaMayThep.Application.HoaDonCongTacNhanVien.Create
{
    public class CreateHoaDonCongTacNhanVienCommand :IRequest<string>, ICommand
    {
        public CreateHoaDonCongTacNhanVienCommand() 
        { }

        public CreateHoaDonCongTacNhanVienCommand(string lichSuCongTacID, int loaiHoaDonID, IFormFile formFile, string nameForFile)
        {
            LichSuCongTacID = lichSuCongTacID;
            LoaiHoaDonID = loaiHoaDonID;
            this.formFile = formFile;
            NameForFile = nameForFile;
        }

        public required string LichSuCongTacID { get; set; }
        public required int LoaiHoaDonID { get; set; }
        public IFormFile formFile { get; set; }
        public string  NameForFile { get; set; }
    }
}
