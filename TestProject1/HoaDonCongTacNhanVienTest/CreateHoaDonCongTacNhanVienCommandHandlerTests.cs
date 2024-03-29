using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.HoaDonCongTacNhanVien.Create;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace TestProject1.HoaDonCongTacNhanVienTest
{
    [TestFixture]
    public class CreateHoaDonCongTacNhanVienCommandHandlerTests
    {
        private CreateHoaDonCongTacNhanVienCommandHandler _handler;
        private Mock<ILichSuCongTacNhanVienRepository> _lichSuCongTacNhanVienRepositoryMock;
        private Mock<ILoaiHoaDonRepository> _loaiHoaDonRepositoryMock;
        private Mock<IHoaDonCongTacNhanVienRepository> _hoaDonCongTacNhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _lichSuCongTacNhanVienRepositoryMock = new Mock<ILichSuCongTacNhanVienRepository>();
            _loaiHoaDonRepositoryMock = new Mock<ILoaiHoaDonRepository>();
            _hoaDonCongTacNhanVienRepositoryMock = new Mock<IHoaDonCongTacNhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handler = new CreateHoaDonCongTacNhanVienCommandHandler(
                _lichSuCongTacNhanVienRepositoryMock.Object,
                _loaiHoaDonRepositoryMock.Object,
                _hoaDonCongTacNhanVienRepositoryMock.Object,
                _currentUserServiceMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_CreatesHoaDonCongTacNhanVien_Successfully()
        {
            // Arrange
            var command = new CreateHoaDonCongTacNhanVienCommand
            {
                LichSuCongTacID = "1",
                LoaiHoaDonID = 1,
                formFile = Mock.Of<IFormFile>(f => f.ContentType == "application/pdf"),
                NameForFile = "TestFileName"
            };

            var lichSuCongTac = new LichSuCongTacNhanVienEntity
            {
                MaSoNhanVien = "123",
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };

            var loaiHoaDon = new LoaiHoaDonEntity { ID = 1, NgayXoa = null, Name = "TestLoaiHoaDon" };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTac);

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(loaiHoaDon);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            _hoaDonCongTacNhanVienRepositoryMock.SetupSequence(repo => repo.AnyAsync(
                It.IsAny<Expression<Func<HoaDonCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(false) // Simulate no existing record
                .ReturnsAsync(true); // Simulate existing record after addition

            _hoaDonCongTacNhanVienRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1); // Simulate successful save

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("tạo mới thành công", result);
            _hoaDonCongTacNhanVienRepositoryMock.Verify(repo => repo.Add(It.IsAny<HoaDonCongTacNhanVienEntity>()), Times.Once);
            _hoaDonCongTacNhanVienRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


        [Test]
        public void Handle_InvalidLichSuCongTac_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateHoaDonCongTacNhanVienCommand { LichSuCongTacID = "1", LoaiHoaDonID = 1 };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((LichSuCongTacNhanVienEntity)null); // Simulate not found

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_InvalidLoaiHoaDon_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateHoaDonCongTacNhanVienCommand { LichSuCongTacID = "1", LoaiHoaDonID = 1 };

            var lichSuCongTac = new LichSuCongTacNhanVienEntity
            {
                MaSoNhanVien = "123",
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTac); // Simulate existing LichSuCongTac

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((LoaiHoaDonEntity)null); // Simulate not found

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_InvalidFileType_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateHoaDonCongTacNhanVienCommand
            {
                LichSuCongTacID = "1",
                LoaiHoaDonID = 1,
                formFile = Mock.Of<IFormFile>(f => f.ContentType == "image/png")
            };
            var lichSuCongTac = new LichSuCongTacNhanVienEntity
            {
                MaSoNhanVien = "123",
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };
            var loaiHoaDonExisting = new LoaiHoaDonEntity { ID = 1, Name = "LoaiHoaDon1" };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTac); // Simulate existing LichSuCongTac

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(loaiHoaDonExisting); // Simulate existing LoaiHoaDon

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
