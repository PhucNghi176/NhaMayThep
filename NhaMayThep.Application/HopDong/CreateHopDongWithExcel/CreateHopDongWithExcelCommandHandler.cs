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
using System.IO.Pipelines;
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
            List<string> excepions = new();
            var count = 0;
            foreach (var item in command.Files)
            {
                var flag = false;
                var memoryStream = new MemoryStream();
                await item.CopyToAsync(memoryStream, cancellationToken);
                memoryStream.Position = 0;
                var reader = item.FileName.EndsWith(".xls") ? ExcelReaderFactory.CreateBinaryReader(memoryStream) : ExcelReaderFactory.CreateOpenXmlReader(memoryStream);
                var dataset = reader.AsDataSet();
                var dataTable = dataset.Tables[0];

                //check enough rows
                if (dataTable.Rows.Count < 12)
                    continue;

                //check null row
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (i == 3 || i == 11)
                        continue;
                    if (Convert.ToString(dataTable.Rows[i][1]) == "")
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    var checkDuplication = excepions.Any(x => x.Equals("Thiếu thông tin"));
                    if (checkDuplication == false)
                        excepions.Add("Thiếu thông tin");
                    continue;
                }

                //check this msnv is existance or not
                var id = Convert.ToString(dataTable.Rows[0][1]);
                var nhanVien = await _nhanVienRepository.FindAsync(x => x.ID == id && x.NgayXoa == null, cancellationToken);
                if (nhanVien == null)
                {
                    excepions.Add($"Không tìm thấy nhân viên với mã số: {id}");
                    continue;
                }
                if (nhanVien.DaCoHopDong)
                {
                    excepions.Add($"Nhân viên với mã số {id} đã có hợp đồng");
                    continue;
                }

                var ngayKy = Convert.ToDateTime(dataTable.Rows[2][1]);
                DateTime? ngayKetThuc = Convert.ToString(dataTable.Rows[3][1]) == "" ? null : Convert.ToDateTime(dataTable.Rows[3][1]);

                if (ngayKetThuc != null && ngayKy > ngayKetThuc)
                {
                    var checkDuplicate = excepions.Any(x => x.Equals("Ngày kết thúc không được trước ngày ký"));
                    if (checkDuplicate == false)
                        excepions.Add("Ngày kết thúc không được trước ngày ký");
                    continue;
                }

                int? thoiHan = 0;
                if (ngayKetThuc == null)
                    thoiHan = null;
                else
                    thoiHan = (int)((ngayKetThuc - ngayKy).Value.Days / 30.436875);

                //creating entity
                var add = new HopDongEntity()
                {
                    NhanVienID = id,
                    LoaiHopDongID = Convert.ToInt32(dataTable.Rows[1][1]),
                    NgayKy = ngayKy,
                    NgayKetThuc = ngayKetThuc,
                    ThoiHanHopDong = thoiHan,
                    DiaDiemLamViec = Convert.ToString(dataTable.Rows[4][1]),
                    BoPhanLamViec = Convert.ToString(dataTable.Rows[5][1]),
                    ChucVuID = Convert.ToInt32(dataTable.Rows[6][1]),
                    ChucDanhID = Convert.ToInt32(dataTable.Rows[7][1]),
                    LuongCoBan = Convert.ToDecimal(dataTable.Rows[8][1]),
                    HeSoLuongID = Convert.ToInt32(dataTable.Rows[9][1]),
                    PhuCapID = Convert.ToString(dataTable.Rows[10][1]),
                    GhiChu = Convert.ToString(dataTable.Rows[11][1]) == "" ? null : Convert.ToString(dataTable.Rows[11][1]),
                    NguoiTaoID = _currentUserService.UserId,
                    NgayTao = DateTime.Now
                };
                _hopDongRepository.Add(add);
                nhanVien.DaCoHopDong = true;
                _nhanVienRepository.Update(nhanVien);
                count++;
            }
            var errorMessage = string.Join(", ", excepions);
            if (await _hopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
            {

                return $"Thêm thành công {count} hợp đồng trên tổng số {command.Files.Length} hợp đồng";
            }
            else
                return $"Thêm thất bại {errorMessage}";
        }
    }
}
