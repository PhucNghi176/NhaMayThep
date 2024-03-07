using MediatR;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
