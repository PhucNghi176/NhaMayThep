using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiHoaDon.Update;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.LoaiHoaDonTest
{
    public class UpdateLoaiHoaDonCommandHandlerTests
    {
        private UpdateLoaiHoaDonCommandHandler _handler;
        private Mock<ILoaiHoaDonRepository> _loaiHoaDonRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _loaiHoaDonRepositoryMock = new Mock<ILoaiHoaDonRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new UpdateLoaiHoaDonCommandHandler(
                _loaiHoaDonRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new UpdateLoaiHoaDonCommand(1, "NewName");

            var existingLoaiHoaDon = new LoaiHoaDonEntity
            {
                ID = 1,
                Name = "OldName",
                NgayXoa = null // assuming it's not deleted
            };

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                                     .ReturnsAsync(existingLoaiHoaDon);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Giả định update thành công
            _loaiHoaDonRepositoryMock.Setup(repo => repo.Update(It.IsAny<LoaiHoaDonEntity>()));
            _loaiHoaDonRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                                     .ReturnsAsync(1); // Số bản ghi đã được cập nhật

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Cập Nhật Thành Công"));

            // Verify repository interactions
            _loaiHoaDonRepositoryMock.Verify(repo => repo.Update(It.IsAny<LoaiHoaDonEntity>()), Times.Once);
            _loaiHoaDonRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.That(existingLoaiHoaDon.Name, Is.EqualTo("NewName"));
            Assert.That(existingLoaiHoaDon.NguoiCapNhatID, Is.EqualTo("TestUserId"));
            Assert.NotNull(existingLoaiHoaDon.NgayCapNhat);
        }


        [Test]
        public void Handle_InvalidRequest_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateLoaiHoaDonCommand(1, "NewName");

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                                     .ReturnsAsync((LoaiHoaDonEntity)null); // Simulate not found

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_DuplicateName_ThrowsDuplicationException()
        {
            // Arrange
            var command = new UpdateLoaiHoaDonCommand(1, "NewName");

            var existingLoaiHoaDon = new LoaiHoaDonEntity
            {
                ID = 1,
                Name = "NewName", // Same name as the updated one
                NgayXoa = null // assuming it's not deleted
            };

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                                     .ReturnsAsync(existingLoaiHoaDon);

            // Act & Assert
            Assert.ThrowsAsync<DuplicationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
