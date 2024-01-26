using MediatR;
using Microsoft.AspNetCore.Http;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.HoaDonCongTacNhanVien.Create
{
    public class CreateHoaDonCongTacNhanVienCommandHandler : IRequestHandler<CreateHoaDonCongTacNhanVienCommand, string>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly ILoaiHoaDonRepository _loaiHoaDonRepository;
        private readonly IHoaDonCongTacNhanVienRepository _hoaDonCongTacNhanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateHoaDonCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, 
            ILoaiHoaDonRepository loaiHoaDonRepository, IHoaDonCongTacNhanVienRepository hoaDonCongTacNhanVienRepository,
            ICurrentUserService currentUserService)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _loaiHoaDonRepository = loaiHoaDonRepository;
            _hoaDonCongTacNhanVienRepository = hoaDonCongTacNhanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateHoaDonCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichsucongtac = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.LichSuCongTacID, cancellationToken);
            if(lichsucongtac == null || lichsucongtac.NgayXoa.HasValue) 
            {
                throw new NotFoundException("lich sử công tác trên không tồn tại");
            }
            var loaihoadon = await _loaiHoaDonRepository.FindAsync(x => x.ID == request.LoaiHoaDonID, cancellationToken);
            if(loaihoadon == null || loaihoadon.NgayXoa.HasValue) 
            {
                throw new NotFoundException("Loại Hóa Đơn không tồn tại");
            }
            // Kiểm tra loại tệp tin, chỉ chấp nhận PDF
            if (request.formFile.ContentType != "application/pdf")
            {
                throw new NotFoundException("Chỉ chấp nhận tệp tin PDF.");
            }
            var hoaDon = new HoaDonCongTacNhanVienEntity() {
                LichSuCongTacID = request.LichSuCongTacID,
                LoaiHoaDonID = request.LoaiHoaDonID,
                NguoiTaoID = _currentUserService.UserId,
                DuongDanFile = await WriteFile(request.formFile, request.NameForFile, loaihoadon.Name),
            };
            var exist = await _hoaDonCongTacNhanVienRepository.AnyAsync(x => x.DuongDanFile == hoaDon.DuongDanFile, cancellationToken);
            if (exist)
            {
                return "Filepath đã tồn tại"; 
            }
            _hoaDonCongTacNhanVienRepository.Add(hoaDon);
            await _hoaDonCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "tạo mới thành công";


        }

        private async Task<string> WriteFile(IFormFile file, string userEnteredFileName, string savePlace)
        {
            try
            {
                // Lấy phần mở rộng (extension) từ tên file gốc nếu có
                string extension = Path.GetExtension(file.FileName);
                //lấy năm hiện tại
                string currentYear = DateTime.Now.Year.ToString();
                //Lấy tháng hiện tại
                string currentMonth = DateTime.Now.Month.ToString();    
                // Lấy ngày và tháng từ thời điểm hiện tại
                string currentDate = DateTime.Now.ToString("yyyyMMdd");

                // Tạo tên file mới bao gồm tên người dùng nhập, ngày và thời điểm hiện tại
                string filename = $"{userEnteredFileName}_{currentDate}{extension}";

                // Đường dẫn đến thư mục lưu trữ tệp tin
                string directoryPath = Path.Combine(Directory.GetCurrentDirectory(), $"app/uploads/{savePlace}/{currentYear}/{currentMonth}");
                
                // Kiểm tra xem thư mục lưu trữ có tồn tại hay không, nếu không thì tạo mới
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Tạo đường dẫn đầy đủ đến tệp tin
                string filePath = Path.Combine(directoryPath, filename);

                // Lưu tệp tin vào đường dẫn đã tạo
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Trả về đường dẫn của tệp tin đã được sửa tên
                return filePath;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine($"Error: {ex.Message}");
                return "tạo mới thất bại";
            }
        }
    }
}
