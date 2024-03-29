using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuCongTacNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Exceptions;

namespace TestProject1.LichSuCongTacNhanVienTest
{
    [TestFixture]
    public class CreateLichSuCongTacNhanVienCommandHandlerTests
    {
        private CreateLichSuCongTacNhanVienCommandHandler _handler;
        private Mock<ILichSuCongTacNhanVienRepository> _lichSuCongTacNhanVienRepositoryMock;
        private Mock<ILoaiCongTacRepository> _loaiCongTacRepositoryMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _lichSuCongTacNhanVienRepositoryMock = new Mock<ILichSuCongTacNhanVienRepository>();
            _loaiCongTacRepositoryMock = new Mock<ILoaiCongTacRepository>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateLichSuCongTacNhanVienCommandHandler(
                _lichSuCongTacNhanVienRepositoryMock.Object,
                _mapperMock.Object,
                _loaiCongTacRepositoryMock.Object,
                _nhanVienRepositoryMock.Object,
                _currentUserServiceMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateLichSuCongTacNhanVienCommand(
                maSoNhanVien: "123", // Provide a valid maSoNhanVien here
                loaiCongTacID: 1,
                ngayBatDau: DateTime.Now,
                ngayKetThuc: DateTime.Now.AddDays(1),
                noiCongTac: "TestLocation",
                lydo: "TestReason"
            );

            var existingNhanVien = new NhanVienEntity 
            {
                ID = "123",
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
            var existingLoaiCongTac = new LoaiCongTacEntity { ID = 1, Name = "TestLoaiCongTac" };

            _nhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(existingNhanVien);

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(existingLoaiCongTac);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Giả định lưu thành công
            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Tạo mới thành công", result);

            // Verify repository interactions
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.Add(It.IsAny<LichSuCongTacNhanVienEntity>()), Times.Once);
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
        [Test]
        public async Task Handle_Invalid_LoaiCongTac_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateLichSuCongTacNhanVienCommand(
                maSoNhanVien: "123", // Provide a valid maSoNhanVien here
                loaiCongTacID: 1,
                ngayBatDau: DateTime.Now,
                ngayKetThuc: DateTime.Now.AddDays(1),
                noiCongTac: "TestLocation",
                lydo: "TestReason"
            );

            var existingNhanVien = new NhanVienEntity
            {
                ID = "123",
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

            _nhanVienRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), CancellationToken.None))
                                   .ReturnsAsync(existingNhanVien); // Simulate existing employee

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                                       .ReturnsAsync((LoaiCongTacEntity)null); // Simulate LoaiCongTac not found

            // Act & Assert
            var exception =  Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.AreEqual("Loại Công Tác Không Tồn Tại", exception.Message);
        }

        [Test]
        public async Task Handle_Invalid_NhanVien_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateLichSuCongTacNhanVienCommand(
                maSoNhanVien: "123", // Provide a valid maSoNhanVien here
                loaiCongTacID: 1,
                ngayBatDau: DateTime.Now,
                ngayKetThuc: DateTime.Now.AddDays(1),
                noiCongTac: "TestLocation",
                lydo: "TestReason"
            );
            var existingLoaiCongTac = new LoaiCongTacEntity { ID = 1, Name = "TestLoaiCongTac" };

            _nhanVienRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), CancellationToken.None))
                                   .ReturnsAsync((NhanVienEntity)null); // Simulate NhanVien not found

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                                       .ReturnsAsync(existingLoaiCongTac); // Simulate existing LoaiCongTac

            // Act & Assert
            var exception =  Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.AreEqual("Nhân Viên Không Tồn Tại", exception.Message);
        }

    }

}
