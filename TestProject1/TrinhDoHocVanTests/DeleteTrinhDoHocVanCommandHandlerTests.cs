using NUnit.Framework;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.TrinhDoHocVan.Delete;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using AutoMapper;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.TrinhDoHocVanTests
{
    [TestFixture]
    public class DeleteTrinhDoHocVanCommandHandlerTests
    {
        private DeleteTrinhDoHocVanCommandHandler _handler;
        private Mock<ITrinhDoHocVanRepository> _repositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ITrinhDoHocVanRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _mapperMock = new Mock<IMapper>();
            _handler = new DeleteTrinhDoHocVanCommandHandler(_currentUserServiceMock.Object, _repositoryMock.Object, _mapperMock.Object);
            _repositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());
        }

        [Test]
        public async Task Handle_WithValidId_DeletesTrinhDoHocVanAndReturnsSuccessMessage()
        {
            // Arrange
            var command = new DeleteTrinhDoHocVanCommand(1);
            var trinhDoHocVanEntity = new TrinhDoHocVanEntity { ID = 1, NgayXoa = null, Name = "Test Delete Trinh Do" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(trinhDoHocVanEntity);
            _currentUserServiceMock.Setup(x => x.UserId).Returns("user123");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công!", result);
            _repositoryMock.Verify(x => x.Update(It.IsAny<TrinhDoHocVanEntity>()), Times.Once);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public async Task Handle_WithInvalidId_ReturnsFailureMessage()
        {
            // Arrange
            var command = new DeleteTrinhDoHocVanCommand(1);
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrinhDoHocVanEntity)null);
            _currentUserServiceMock.Setup(x => x.UserId).Returns("user123");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại!", result);
            _repositoryMock.Verify(x => x.Update(It.IsAny<TrinhDoHocVanEntity>()), Times.Never);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }

}
