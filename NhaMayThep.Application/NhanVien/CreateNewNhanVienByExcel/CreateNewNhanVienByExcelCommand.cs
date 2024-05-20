using MediatR;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienByExcel
{
    public class CreateNewNhanVienByExcelCommand : IRequest<string>, ICommand
    {
        public IFormFile[] InputFiles { get; set; }

        public CreateNewNhanVienByExcelCommand(IFormFile[] inputFiles)
        {
            InputFiles = inputFiles;
        }

        public CreateNewNhanVienByExcelCommand() { }
    }
}
