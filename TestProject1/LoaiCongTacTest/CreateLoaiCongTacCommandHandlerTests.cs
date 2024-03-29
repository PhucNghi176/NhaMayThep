using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiCongTac.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.LoaiCongTacTest
{
    [TestFixture]
    public class CreateLoaiCongTacCommandHandlerTests
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ILoaiCongTacRepository> _loaiCongTacRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private CreateLoaiCongTacCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _loaiCongTacRepositoryMock = new Mock<ILoaiCongTacRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new CreateLoaiCongTacCommandHandler(
                _loaiCongTacRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateLoaiCongTacCommand("TestName");

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(),
                CancellationToken.None))
                .ReturnsAsync((LoaiCongTacEntity)null); // Simulate not found

            // Giả định lưu thành công
            _loaiCongTacRepositoryMock.Setup(repo => repo.Add(It.IsAny<LoaiCongTacEntity>()));
            _loaiCongTacRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1); // Giả định lưu thành công

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Tạo Mới Thành Công", result);

            // Verify repository interactions
            _loaiCongTacRepositoryMock.Verify(repo => repo.Add(It.IsAny<LoaiCongTacEntity>()), Times.Once);
            _loaiCongTacRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


        [Test]
        public void Handle_DuplicateName_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateLoaiCongTacCommand ("DuplicateName");

            var existingLoaiCongTac = new LoaiCongTacEntity
            {
                Name = "DuplicateName"
            };

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(existingLoaiCongTac); // LoaiCongTacEntity đã tồn tại với tên trùng

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
