using ExcelDataReader;
using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.NhanVien.CreateNewNhanVienByExcel
{
    public class CreateNewNhanVienByExcelCommandHandler : IRequestHandler<CreateNewNhanVienByExcelCommand, string>
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ITinhTrangLamViecRepository _tinhTrangLamViecRepository;
        private readonly IChucVuRepository _chucVuRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateNewNhanVienByExcelCommandHandler(INhanVienRepository nhanVienRepository, ITinhTrangLamViecRepository tinhTrangLamViecRepository, IChucVuRepository chucVuRepository, ICurrentUserService currentUserService)
        {
            _nhanVienRepository = nhanVienRepository;
            _tinhTrangLamViecRepository = tinhTrangLamViecRepository;
            _chucVuRepository = chucVuRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateNewNhanVienByExcelCommand command, CancellationToken cancellationToken)
        {
            var count = 0;

            foreach (var item in command.InputFiles)
            {
                var flag = false;
                var memoryStream = new MemoryStream();
                await item.CopyToAsync(memoryStream, cancellationToken);
                memoryStream.Position = 0;
                var reader = item.FileName.EndsWith(".xls") ? ExcelReaderFactory.CreateBinaryReader(memoryStream) : ExcelReaderFactory.CreateOpenXmlReader(memoryStream);
                var dataset = reader.AsDataSet();
                var dataTable = dataset.Tables[0];

                //check enough row
                if (dataTable.Rows.Count < 11)
                    continue;

                //check null row
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (i == 10)
                        continue;

                    if (Convert.ToString(dataTable.Rows[i][1]) == "")
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                    continue;

                //check Nhan Vien is duplicated or not
                var nhanVien = await _nhanVienRepository.FindAsync(x => x.HoVaTen.Equals(dataTable.Rows[1][1]) && x.NgayXoa == null, cancellationToken);
                if (nhanVien != null)
                    continue;

                //check Chuc Vu is right name or not
                var chucVu = await _chucVuRepository.FindAsync(x => x.Name.Equals(dataTable.Rows[2][1]) && x.NgayXoa == null, cancellationToken);
                if (chucVu == null)
                    continue;

                //check Tinh Trang Lam Viec is right name or not
                var tinhTrangLamViec = await _tinhTrangLamViecRepository.FindAsync(x => x.Name.Equals(dataTable.Rows[3][1]) && x.NgayXoa == null, cancellationToken);
                if (tinhTrangLamViec == null)
                    continue;

                var ngayVaoCongTy = Convert.ToDateTime(dataTable.Rows[4][1]);

                string pass = _nhanVienRepository.GeneratePassword();

                var create = new NhanVienEntity()
                {
                    Email = Convert.ToString(dataTable.Rows[0][1]),
                    HoVaTen = Convert.ToString(dataTable.Rows[1][1]),
                    PasswordHash = _nhanVienRepository.HashPassword(pass),
                    ChucVuID = chucVu.ID,
                    TinhTrangLamViecID = tinhTrangLamViec.ID,
                    NgayVaoCongTy = ngayVaoCongTy,
                    DiaChiLienLac = Convert.ToString(dataTable.Rows[5][1]),
                    SoDienThoaiLienLac = Convert.ToString(dataTable.Rows[6][1]),
                    MaSoThue = Convert.ToString(dataTable.Rows[7][1]),
                    TenNganHang = Convert.ToString(dataTable.Rows[8][1]),
                    SoTaiKhoan = Convert.ToString(dataTable.Rows[9][1]),
                    SoNguoiPhuThuoc = Convert.ToInt32(dataTable.Rows[10][1]),
                    DaCoHopDong = false,
                    NguoiTaoID = _currentUserService.UserId,
                    NgayTao = DateTime.Now
                };
                _nhanVienRepository.Add(create);
                count++;
            }

            if (await _nhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return $"Đã thêm được {count} trên số {command.InputFiles.Length} nhân viên";
            else
                return "Thêm thất bại";
        }
    }
}
