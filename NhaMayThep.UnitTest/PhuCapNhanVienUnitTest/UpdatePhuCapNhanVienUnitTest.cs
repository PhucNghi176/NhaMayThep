using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhuCapNhanVien.UpdatePhuCapNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.PhuCapNhanVienUnitTest
{
    [TestFixture]
    public class UpdatePhuCapNhanVienUnitTest
    {
        private Mock<IPhuCapNhanVienRepository> _phuCapNhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserService;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private UpdatePhuCapNhanVienCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _phuCapNhanVienRepositoryMock = new Mock<IPhuCapNhanVienRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handlerMock = new UpdatePhuCapNhanVienCommandHandler(_phuCapNhanVienRepositoryMock.Object, _nhanVienRepositoryMock.Object, _currentUserService.Object);
        }
        [Test]
        public async Task PhuCapNhanVien_UpdateValid_ReturnTrue()
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

            var data = new PhuCapNhanVienEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new UpdatePhuCapNhanVienCommand(
                data.ID,
                data.MaSoNhanVien,
                data.PhuCap);
            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _phuCapNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task PhuCapNhanVien_UpdateValid_ReturnFalse()
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
            var data = new PhuCapNhanVienEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new UpdatePhuCapNhanVienCommand(
                data.ID,
                data.MaSoNhanVien,
                data.PhuCap);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _phuCapNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task PhuCapNhanVien_UpdateInvalid_NotFoundException()
        {
            //Arrange
            var data = new PhuCapNhanVienEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new UpdatePhuCapNhanVienCommand(
                data.ID,
                data.MaSoNhanVien,
                data.PhuCap);

            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((PhuCapNhanVienEntity)null);
            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task PhuCapNhanVien_UpdateInvalid_MaSoNhanVienNotFoundException()
        {
            //Arrange
            var data = new PhuCapNhanVienEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new UpdatePhuCapNhanVienCommand(
                data.ID,
                data.MaSoNhanVien,
                data.PhuCap);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task PhuCapNhanVien_UpdateInvalid_ThrowsDuplicatedException()
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
            var data = new PhuCapNhanVienEntity
            {
                ID = "1",
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new UpdatePhuCapNhanVienCommand(
                data.ID,
                data.MaSoNhanVien,
                data.PhuCap);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVien);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _phuCapNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
