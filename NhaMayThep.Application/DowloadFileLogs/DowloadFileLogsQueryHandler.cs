using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using NhaMapThep.Domain.Common.Exceptions;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DowloadFileLogs
{
    public class DowloadFileLogsQueryHandler : IRequestHandler<DowloadFileLogsQuery, FileContentResult>
    {
        public async Task<FileContentResult> Handle(DowloadFileLogsQuery request, CancellationToken cancellationToken)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            try
            {
                string newestFilePath = GetNewestFilePath(folderPath);

                if (!string.IsNullOrEmpty(newestFilePath))
                {
                    return await ServeFile(newestFilePath);
                }
                else
                {
                    throw new NotFoundException("Không tìm thấy file cần tải");
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                throw new Exception($"Lỗi xử lý tệp tin: {ex.Message}");
            }
        }

        private string GetNewestFilePath(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                // Thư mục không tồn tại
                throw new NotFoundException("Thư mục không tồn tại");
            }

            string[] files = Directory.GetFiles(folderPath);

            if (files.Length == 0)
            {
                // Không có tệp tin trong thư mục
                throw new NotFoundException("Không có tệp tin trong thư mục");
            }

            string newestFilePath = files.OrderByDescending(f => File.GetLastWriteTime(f)).First();

            // Thử sao chép tệp tin để tránh xung đột khi đang ghi log
            string copiedFilePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(newestFilePath));
            File.Copy(newestFilePath, copiedFilePath);

            return copiedFilePath;
        }

        private async Task<FileContentResult> ServeFile(string filePath)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;

            if (!provider.TryGetContentType(filePath, out contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);

            // Xóa bản sao sau khi tải về
            File.Delete(filePath);

            // Lấy tên file gốc
            string originalFileName = Path.GetFileName(filePath);

            // Đặt tên cho file trả về giống với file gốc nhưng có thêm chữ "copy"
            string downloadFileName = $"copy_{originalFileName}";

            return new FileContentResult(bytes, contentType)
            {
                FileDownloadName = downloadFileName
            };
        }
    }
}