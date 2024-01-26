using ExcelDataReader;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.HopDong.CreateHopDongWithExcel
{
    public class CreateHopDongWithExcelCommandHandler : IRequestHandler<CreateHopDongWithExcelCommand, string>
    {
        private readonly IHopDongRepository _hopDongRepository;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateHopDongWithExcelCommandHandler(IHopDongRepository hopDongRepository, INhanVienRepository nhanVienRepository,
                                              ICurrentUserService currentUserService)
        {
            _hopDongRepository = hopDongRepository;
            _nhanVienRepository = nhanVienRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateHopDongWithExcelCommand command, CancellationToken cancellationToken)
        {
            var reader = command.FileName.EndsWith(".xls") ? ExcelReaderFactory.CreateBinaryReader(command.FileStream) : ExcelReaderFactory.CreateOpenXmlReader(command.FileStream);
            var dataset = reader.AsDataSet();
            var dataTable = dataset.Tables[0];
            for (int i = 1; i < dataTable.Rows.Count; i++)
            {
                var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == Convert.ToString(dataTable.Rows[i][0]) && x.NgayXoa == null, cancellationToken);
                if (nhanVien.DaCoHopDong)
                    throw new NotFoundException("Nhân viên đã có hợp đồng");
                var add = new HopDongEntity()
                {
                    NhanVienID = Convert.ToString(dataTable.Rows[i][0]),
                    LoaiHopDongID = Convert.ToInt32(dataTable.Rows[i][1]),
                    NgayKy = Convert.ToDateTime(dataTable.Rows[i][2]),
                    NgayKetThuc = Convert.ToDateTime(dataTable.Rows[i][3]),
                    ThoiHanHopDong = Convert.ToInt32(dataTable.Rows[i][4]),
                    DiaDiemLamViec = Convert.ToString(dataTable.Rows[i][5]),
                    BoPhanLamViec = Convert.ToString(dataTable.Rows[i][6]),
                    ChucVuID = Convert.ToInt32(dataTable.Rows[i][7]),
                    ChucDanhID = Convert.ToInt32(dataTable.Rows[i][8]),
                    LuongCoBan = Convert.ToDecimal(dataTable.Rows[i][9]),
                    HeSoLuongID = Convert.ToInt32(dataTable.Rows[i][10]),
                    PhuCapID = Convert.ToString(dataTable.Rows[i][11]),
                    GhiChu = Convert.ToString(dataTable.Rows[i][12]),
                    NguoiTaoID = _currentUserService.UserId,
                    NgayTao = DateTime.Now
                };
                _hopDongRepository.Add(add);
                nhanVien.DaCoHopDong = true;
                _nhanVienRepository.Update(nhanVien);
            }
            if (await _hopDongRepository.UnitOfWork.SaveChangesAsync() > 0)
            {

                return "Thêm thành công";
            }
            else
                return "Thêm thất bại";
        }
    }
}
