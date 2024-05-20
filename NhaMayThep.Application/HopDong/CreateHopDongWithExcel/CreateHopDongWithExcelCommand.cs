using MediatR;
using Microsoft.AspNetCore.Http;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HopDong.CreateHopDongWithExcel
{
    public class CreateHopDongWithExcelCommand : IRequest<string>, ICommand
    {

        public IFormFile[] Files { get; set; }

        public CreateHopDongWithExcelCommand(IFormFile[] files)
        {
            Files = files;
        }
    }
}
