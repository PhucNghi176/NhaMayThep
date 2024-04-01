using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Update;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace TestProject1.NghiPhepTests
{
    [TestFixture]
    public class UpdateNghiPhepCommandHandlerTests
    {
        private UpdateNghiPhepCommandHandler _handler;
        private Mock<INghiPhepRepository> _nghiPhepRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _nghiPhepRepositoryMock = new Mock<INghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _loaiNghiPhepRepositoryMock = new Mock<ILoaiNghiPhepRepository>();

            _handler = new UpdateNghiPhepCommandHandler(
                _nghiPhepRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object,
                _loaiNghiPhepRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidUpdate_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new UpdateNghiPhepCommand("1", 8.0m, 10.0m, 2.5, 1);
            var existingNghiPhep = new NghiPhepEntity
            {
                ID = "1",
                NgayXoa = null,
                LuongNghiPhep = 5.0m,
                KhoanTruLuong = 6.0m,
                SoGioNghiPhep = 1.5,
                LoaiNghiPhepID = 1,
                MaSoNhanVien = "ExampleMaSoNhanVien",
                NguoiCapNhatID = "userId",
                NgayCapNhatCuoi = DateTime.Now.AddDays(-1)
            };

            _nghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingNghiPhep);

            _loaiNghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new LoaiNghiPhepEntity { ID = 1, Name = "Test" });

            _currentUserServiceMock.Setup(x => x.UserId).Returns("userId");

            _nghiPhepRepositoryMock.Setup(x => x.Update(It.IsAny<NghiPhepEntity>()));

            _nghiPhepRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Cập nhật thành công!", result);
        }

        [Test]
        public void Handle_NonExistingNghiPhep_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateNghiPhepCommand("1", 8.0m, 10.0m, 2.5, 1);

            _nghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((NghiPhepEntity)null!);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_NonExistingLoaiNghiPhep_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateNghiPhepCommand("1", 8.0m, 10.0m, 2.5, 1);
            var existingNghiPhep = new NghiPhepEntity
            {
                ID = "1",
                NgayXoa = null,
                LuongNghiPhep = 5.0m,
                KhoanTruLuong = 6.0m,
                SoGioNghiPhep = 1.5,
                LoaiNghiPhepID = 1,
                MaSoNhanVien = "ExampleMaSoNhanVien",
                NguoiCapNhatID = "userId",
                NgayCapNhatCuoi = DateTime.Now.AddDays(-1)
            };

            _nghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingNghiPhep);

            _loaiNghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((LoaiNghiPhepEntity)null!); 

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
