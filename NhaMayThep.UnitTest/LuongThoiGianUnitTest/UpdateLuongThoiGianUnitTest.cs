using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongThoiGian.CreateLuongThoiGian;
using NhaMayThep.Application.LuongThoiGian.UpdateLuongThoiGian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.LuongThoiGianUnitTest
{
    [TestFixture]
    public class UpdateLuongThoiGianUnitTest
    {
        private Mock<ILuongThoiGianRepository> _luongThoiGianRepositoryMock;
        private Mock<ICurrentUserService> _currentUserService;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private UpdateLuongThoiGianCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _luongThoiGianRepositoryMock = new Mock<ILuongThoiGianRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handlerMock = new UpdateLuongThoiGianCommandHandler(_luongThoiGianRepositoryMock.Object, _nhanVienRepositoryMock.Object, _currentUserService.Object);
        }
        [Test]
        public async Task LuongThoiGian_UpdateValid_ReturnTrue()
        {
            //Arrange
            var expectedResult = "Cập nhật thành công";

            var nhanVien = new NhanVienEntity
            {
                Email = "nhanvien@gmail.com",
                PasswordHash = "nhanvien123",
                HoVaTen = "Tuấn Kiệt",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                NgayVaoCongTy = DateTime.Now,
                DiaChiLienLac = "Địa chỉ liên lạc",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "1201",
                TenNganHang = "TPBANK",
                SoTaiKhoan = "0123456789",
                DaCoHopDong = true
            };

            var data = new LuongThoiGianEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new UpdateLuongThoiGianCommand(
                data.ID,
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);
            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _luongThoiGianRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task LuongThoiGian_UpdateValid_ReturnFalse()
        {
            //Arrange
            var expectedResult = "Cập nhật thất bại";
            var nhanVien = new NhanVienEntity
            {
                Email = "nhanvien@gmail.com",
                PasswordHash = "nhanvien123",
                HoVaTen = "Tuấn Kiệt",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                NgayVaoCongTy = DateTime.Now,
                DiaChiLienLac = "Địa chỉ liên lạc",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "1201",
                TenNganHang = "TPBANK",
                SoTaiKhoan = "0123456789",
                DaCoHopDong = true
            };
            var data = new LuongThoiGianEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new UpdateLuongThoiGianCommand(
                data.ID,
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _luongThoiGianRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task LuongThoiGian_UpdateInvalid_NotFoundException()
        {
            //Arrange
            var data = new LuongThoiGianEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new UpdateLuongThoiGianCommand(
                data.ID,
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);

            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((LuongThoiGianEntity)null);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task LuongThoiGian_UpdateInvalid_MaSoNhanVienNotFoundException()
        {
            //Arrange
            var data = new LuongThoiGianEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new UpdateLuongThoiGianCommand(
                data.ID,
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task LuongThoiGian_UpdateInvalid_ThrowsDuplicatedException()
        {
            //Arrange
            var nhanVien = new NhanVienEntity
            {
                Email = "nhanvien@gmail.com",
                PasswordHash = "nhanvien123",
                HoVaTen = "Tuấn Kiệt",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                NgayVaoCongTy = DateTime.Now,
                DiaChiLienLac = "Địa chỉ liên lạc",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "1201",
                TenNganHang = "TPBANK",
                SoTaiKhoan = "0123456789",
                DaCoHopDong = true
            };
            var data = new LuongThoiGianEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new UpdateLuongThoiGianCommand(
                data.ID,
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _luongThoiGianRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
