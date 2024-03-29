using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Common.Interfaces;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.CapBacLuong;
using NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.CapBacLuongUnitTest
{
    [TestFixture]
    public class DeleteCapBacLuongUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ICapBacLuongRepository> _capBacLuongRepositoryMock;
        private DeleteCapBacLuongCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _capBacLuongRepositoryMock = new Mock<ICapBacLuongRepository>();
            
            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new DeleteCapBacLuongCommandHandler(_capBacLuongRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task CapBacLuong_DeleteCapBacLuong_ReturnTrue(int id)
        {
            // Arrange
            var expected = "Xóa thành công";

            var expectedLsnp = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };

            var command = new DeleteCapBacLuongCommand(id);
            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedLsnp);

            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(1)]
        public async Task CapBacLuong_DeleteCapBacLuong_ReturnFalse(int id)
        {
            // Arrange
            var expected = "Xóa thất bại";

            var expectedLsnp = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };

            var command = new DeleteCapBacLuongCommand(id);
            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedLsnp);

            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<int>());

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(0)]
        public async Task CapBacLuong_DeleteCapBacLuong_ThrowException(int id)
        {
            // Arrange
            var command = new DeleteCapBacLuongCommand(id);
            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CapBacLuongEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
