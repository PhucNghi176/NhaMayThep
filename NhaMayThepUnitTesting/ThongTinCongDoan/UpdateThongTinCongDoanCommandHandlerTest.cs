using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThepUnitTesting.ThongTinCongDoan
{
    public class UpdateThongTinCongDoanCommandHandlerTest
    {
        private  Mock<IThongTinCongDoanRepository> _thongtinCongDoanRepositoryMock;
        private Mock<INhanVienRepository> _nhanvienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateThongTinCongDoanCommandHandler _handler;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongtinCongDoanRepositoryMock = new Mock<IThongTinCongDoanRepository>();
            _nhanvienRepositoryMock = new Mock<INhanVienRepository>();
            _handler = new UpdateThongTinCongDoanCommandHandler(
                _thongtinCongDoanRepositoryMock.Object,
                _nhanvienRepositoryMock.Object,
                _currentUserServiceMock.Object);
        }
        [Test]
        public async Task Handler_Should_Return_NhanVien_NotFound()
        {
            //Arrange
            var command = new UpdateThongTinCongDoanCommand("validId", "invalidId", false, null);

            _nhanvienRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((NhanVienEntity?)null);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
        }
        public async Task Handler_Should_Return_ThongTinCongDoan_NotFound()
        {
            //Arrange
            var command = new UpdateThongTinCongDoanCommand("invalid", "invalidId", false, null);

            _thongtinCongDoanRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCongDoanEntity?)null);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
        }
        public async Task Handler_Should_ReturnTrue_WhenUpdate_Success()
        {
            //Arrange
            var command = new UpdateThongTinCongDoanCommand("invalid", "valid", true, DateTime.Now);
            var nhanvien = new NhanVienEntity
            {
                ID = "someId",
                Email = "email@example.com",
                PasswordHash = "hashedPassword123",
                HoVaTen = "Nguyen Van A",
                ChucVuID = 1, // Assume this ID exists in your database
                TinhTrangLamViecID = 1, // Same here
                DaCoHopDong = true,
                NgayVaoCongTy = new DateTime(2020, 01, 01),
                DiaChiLienLac = "123 Main St",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "123456789",
                TenNganHang = "Bank ABC",
                SoTaiKhoan = "987654321"
            };
            var congdoan = new ThongTinCongDoanEntity
            {
                ID = "validId",
                NhanVienID = "validNhanVien",
                NhanVien = null,
                ThuKiCongDoan = false,
                NgayGiaNhap = DateTime.Now
            };

            _nhanvienRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanvien);
            _thongtinCongDoanRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(congdoan);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
            _thongtinCongDoanRepositoryMock.Verify(x => x.Update(It.IsAny<ThongTinCongDoanEntity>()), Times.Once);
            _thongtinCongDoanRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
