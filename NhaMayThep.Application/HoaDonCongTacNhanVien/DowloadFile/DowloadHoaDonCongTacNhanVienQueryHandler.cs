using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NhaMapThep.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.DowloadFile
{
    public class DowloadHoaDonCongTacNhanVienQueryHandler : IRequestHandler<DowloadHoaDonCongTacNhanVienQuery, FileContentResult>
    {
        public async Task<FileContentResult> Handle(DowloadHoaDonCongTacNhanVienQuery request, CancellationToken cancellationToken)
        {
            
                var filenpath = Path.Combine(Directory.GetCurrentDirectory(), "UploadFile\\File", request.filepath);

                if (System.IO.File.Exists(filenpath))
                {
                    var provider = new FileExtensionContentTypeProvider();
                    if (!provider.TryGetContentType(filenpath, out var contentType))
                    {
                        contentType = "application/octet-stream";
                    }
                    var bytes = await System.IO.File.ReadAllBytesAsync(filenpath);

                    return new FileContentResult(bytes, contentType)
                    {
                        FileDownloadName = Path.GetFileName(filenpath)
                    };
                }
                else
                {
                    // File không tồn tại, ném một NotFoundException
                    throw new NotFoundException("Không tìm thấy file cần tải");
                }
           

        }
    }
}
