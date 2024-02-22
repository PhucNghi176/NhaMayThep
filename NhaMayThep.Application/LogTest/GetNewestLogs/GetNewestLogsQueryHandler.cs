using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Logs.GetNewestLogs
{
    public class GetNewestLogsQueryHandler : IRequestHandler<GetNewestLogsQuery, List<string>>
    {
        public async Task<List<string>> Handle(GetNewestLogsQuery request, CancellationToken cancellationToken)
        {
            // Đường dẫn tới thư mục logs
            string logsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

            // Kiểm tra xem thư mục có tồn tại không
            if (!Directory.Exists(logsFolderPath))
            {
                // Xử lý trường hợp thư mục không tồn tại
                return new List<string> { "Thư mục logs không tồn tại" };
            }

            // Lấy danh sách các file trong thư mục logs và sắp xếp theo thời gian tạo giảm dần
            var files = new DirectoryInfo(logsFolderPath).GetFiles().OrderByDescending(f => f.CreationTime);

            // Lấy file mới nhất
            var newestLogFile = files.FirstOrDefault();

            // Kiểm tra xem có file nào trong thư mục không
            if (newestLogFile == null)
            {
                // Xử lý trường hợp không có file trong thư mục
                return new List<string> { "Không có file trong thư mục logs" };
            }

            int linesCount = request.lineCount; // Lấy số dòng từ yêu cầu

            var newestLogContent = new List<string>();

            try
            {
                // Mở file với quyền đọc và chia sẻ file với các tiến trình khác
                using (var fileStream = new FileStream(newestLogFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    // Tạo một danh sách để lưu trữ các dòng của file log
                    var lines = new List<string>();

                    // Đọc dữ liệu từ file log và sao chép vào danh sách
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        string line;
                        while ((line = await streamReader.ReadLineAsync()) != null)
                        {
                            lines.Add(line);
                        }
                    }

                    // Lấy số dòng từ dưới lên mà người dùng yêu cầu
                    int startIndex = Math.Max(0, lines.Count - linesCount);
                    int count = Math.Min(lines.Count, linesCount);

                    // Sao chép số dòng cần lấy vào danh sách mới
                    newestLogContent = lines.GetRange(startIndex, count);
                }

                // Trả về danh sách các dòng của file mới nhất
                return newestLogContent;
            }
            catch (IOException)
            {
                // Xử lý khi không thể đọc file do đang được sử dụng
                return new List<string> { "Không thể đọc được file do đang được sử dụng" };
            }
        }

    }
}
