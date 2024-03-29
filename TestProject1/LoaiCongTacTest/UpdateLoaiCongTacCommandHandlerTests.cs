using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiCongTac.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.LoaiCongTacTest
{
    public class UpdateLoaiCongTacCommandHandlerTests
    {
        private UpdateLoaiCongTacCommandHandler _handler;
        private Mock<ILoaiCongTacRepository> _loaiCongTacRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _loaiCongTacRepositoryMock = new Mock<ILoaiCongTacRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new UpdateLoaiCongTacCommandHandler(
            _loaiCongTacRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new UpdateLoaiCongTacCommad(1, "NewName");

            var existingLoaiCongTac = new LoaiCongTacEntity
            {
                ID = 1,
                Name = "OldName",
                NgayXoa = null // assuming it's not deleted
            };

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(),
                CancellationToken.None))
                .ReturnsAsync(existingLoaiCongTac);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Giả định lưu thành công
            _loaiCongTacRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1); // Giả định lưu thành công

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Cập Nhật Thành Công", result);

            // Verify repository interactions
            _loaiCongTacRepositoryMock.Verify(repo => repo.Update(It.IsAny<LoaiCongTacEntity>()), Times.Once);
            _loaiCongTacRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.AreEqual("NewName", existingLoaiCongTac.Name);
            Assert.AreEqual("TestUserId", existingLoaiCongTac.NguoiCapNhatID);
            Assert.NotNull(existingLoaiCongTac.NgayCapNhat);
        }


        [Test]
        public async Task Handle_NonExistentLoaiCongTac_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateLoaiCongTacCommad(1, "NewName");

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                                     .ReturnsAsync((LoaiCongTacEntity)null); // Simulate not found

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task Handle_DuplicateName_ThrowsDuplicationException()
        {
            // Arrange
            var command = new UpdateLoaiCongTacCommad(1, "NewName");

            var existingLoaiCongTac = new LoaiCongTacEntity
            {
                ID = 1,
                Name = "NewName", // Same name as the updated one
                NgayXoa = null // assuming it's not deleted
            };

            _loaiCongTacRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiCongTacEntity, bool>>>(), CancellationToken.None))
                                     .ReturnsAsync(existingLoaiCongTac);

            // Act & Assert
            Assert.ThrowsAsync<DuplicationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
