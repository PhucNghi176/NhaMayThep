using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuCongTacNhanVien.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TestProject1.LichSuCongTacNhanVienTest
{
    [TestFixture]
    public class UpdateLichSuCongTacNhanVienCommandHandlerTests
    {
        private UpdateLichSuCongTacNhanVienCommandHandler _handler;
        private Mock<ILichSuCongTacNhanVienRepository> _lichSuCongTacNhanVienRepositoryMock;
        private Mock<ILoaiCongTacRepository> _loaiCongTacRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _lichSuCongTacNhanVienRepositoryMock = new Mock<ILichSuCongTacNhanVienRepository>();
            _loaiCongTacRepositoryMock = new Mock<ILoaiCongTacRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handler = new UpdateLichSuCongTacNhanVienCommandHandler(
                _lichSuCongTacNhanVienRepositoryMock.Object,
                _loaiCongTacRepositoryMock.Object,
                _currentUserServiceMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new UpdateLichSuCongTacNhanVienCommand
            {
                ID = "1",
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };

            var loaiCongTac = new LoaiCongTacEntity { ID = 1, Name = "Test Loai Cong Tac" };
            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(loaiCongTac);

            var lichSuCongTacNhanVien = new LichSuCongTacNhanVienEntity
            {
                MaSoNhanVien = "123", // Provide a valid maSoNhanVien here
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTacNhanVien);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Cập Nhật Thành Công", result);
        }

        [Test]
        public void Handle_Invalid_LoaiCongTac_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateLichSuCongTacNhanVienCommand { LoaiCongTacID = 999 }; // Invalid LoaiCongTacID

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((LoaiCongTacEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_Invalid_LichSuCongTacNhanVien_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateLichSuCongTacNhanVienCommand { ID = "999" }; // Invalid LichSuCongTacNhanVien ID

            var loaiCongTac = new LoaiCongTacEntity { ID = 1, Name = "Test Loai Cong Tac" };
            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(loaiCongTac);

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((LichSuCongTacNhanVienEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
