using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMapThep.Application.TrinhDoHocVan.Commands;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.TrinhDoHocVanTests
{
    [TestFixture]
    public class CreateTrinhDoHocVanCommandHandlerTests
    {
        private CreateTrinhDoHocVanCommandHandler _handler;
        private Mock<ITrinhDoHocVanRepository> _repositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ITrinhDoHocVanRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new CreateTrinhDoHocVanCommandHandler(_currentUserServiceMock.Object, _repositoryMock.Object);
            _repositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());
        }

        [Test]
        public async Task Handle_WithNonExistingTrinhDoHocVan_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateTrinhDoHocVanCommand { TenTrinhDo = "Test Trinh Do" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrinhDoHocVanEntity)null!);
            _currentUserServiceMock.Setup(x => x.UserId).Returns("user123");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Console.WriteLine($"Result: {result}");
            _repositoryMock.Verify(x => x.Add(It.IsAny<TrinhDoHocVanEntity>()), Times.Once);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once); // Ensure SaveChangesAsync is called at least once
        }

        [Test]
        public async Task Handle_WithExistingTrinhDoHocVan_ReturnsAlreadyExistsMessage()
        {
            // Arrange
            var command = new CreateTrinhDoHocVanCommand { TenTrinhDo = "Test Trinh Do" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new TrinhDoHocVanEntity { Name = "Trinh do hoc van test" });


            _currentUserServiceMock.Setup(x => x.UserId).Returns("user123");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Đã tồn tại Trình Độ Học Vấn này!", result);
            _repositoryMock.Verify(x => x.Add(It.IsAny<TrinhDoHocVanEntity>()), Times.Never);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }

}
