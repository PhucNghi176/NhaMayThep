using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiCongTac.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.LoaiCongTacTest
{
    [TestFixture]
    public class DeleteLoaiCongTacCommandHandlerTests
    {
        private DeleteLoaiCongTacCommadHandler _handler;
        private Mock<ILoaiCongTacRepository> _loaiCongTacRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _loaiCongTacRepositoryMock = new Mock<ILoaiCongTacRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new DeleteLoaiCongTacCommadHandler(
                _loaiCongTacRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new DeleteLoaiCongTacCommad(1);

            var existingLoaiCongTac = new LoaiCongTacEntity
            {
                ID = 1,
                NgayXoa = null, // assuming it's not deleted
                Name = "Name",
            };

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(),
                CancellationToken.None))
                .ReturnsAsync(existingLoaiCongTac);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Giả định cập nhật và lưu thành công
            _loaiCongTacRepositoryMock.Setup(repo => repo.Update(It.IsAny<LoaiCongTacEntity>()));
            _loaiCongTacRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1); // Giả định lưu thành công

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công", result);

            // Verify repository interactions
            _loaiCongTacRepositoryMock.Verify(repo => repo.Update(It.IsAny<LoaiCongTacEntity>()), Times.Once);
            _loaiCongTacRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.AreEqual("TestUserId", existingLoaiCongTac.NguoiXoaID);
            Assert.NotNull(existingLoaiCongTac.NgayXoa);
        }

        [Test]
        public async Task Handle_InvalidRequest_ReturnsFailMessage()
        {
            // Arrange
            var command = new DeleteLoaiCongTacCommad(1);

            // Simulate not found
            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(),
                CancellationToken.None))
                .ReturnsAsync((LoaiCongTacEntity)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại", result);

            // Verify repository interactions
            _loaiCongTacRepositoryMock.Verify(repo => repo.Update(It.IsAny<LoaiCongTacEntity>()), Times.Never);
            _loaiCongTacRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }

        [Test]
        public async Task Handle_AlreadyDeleted_ReturnsFailMessage()
        {
            // Arrange
            var command = new DeleteLoaiCongTacCommad(1);

            var existingLoaiCongTac = new LoaiCongTacEntity
            {
                ID = 1,
                NgayXoa = DateTime.Now, // already deleted
                Name = "name"
            };

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(),
                CancellationToken.None))
                .ReturnsAsync(existingLoaiCongTac);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại", result);

            // Verify repository interactions
            _loaiCongTacRepositoryMock.Verify(repo => repo.Update(It.IsAny<LoaiCongTacEntity>()), Times.Never);
            _loaiCongTacRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }

}
