using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMapThep.Application.TrinhDoHocVan.Commands;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.TrinhDoHocVanTests
{
    [TestFixture]
    public class UpdateTrinhDoHocVanCommandHandlerTests
    {
        private UpdateTrinhDoHocVanCommandHandler _handler;
        private Mock<ITrinhDoHocVanRepository> _repositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ITrinhDoHocVanRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new UpdateTrinhDoHocVanCommandHandler(_currentUserServiceMock.Object, _repositoryMock.Object);
            _repositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());
        }

        [Test]
        public async Task Handle_WithValidCommand_UpdatesTrinhDoHocVanAndSavesChanges()
        {
            // Arrange
            var command = new UpdateTrinhDoHocVanCommand { Id = 1, TenTrinhDo = "Updated Trinh Do" };
            var existingEntity = new TrinhDoHocVanEntity { ID = 1, Name = "Old Trinh Do", NgayXoa = null };

            _repositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(false);
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(existingEntity);
            _currentUserServiceMock.Setup(x => x.UserId).Returns("user123");

            // Act
            _handler.Handle(command, CancellationToken.None);

            // Assert
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.AreEqual("Updated Trinh Do", existingEntity.Name);
            Assert.AreEqual("user123", existingEntity.NguoiCapNhatID);
            Assert.NotNull(existingEntity.NgayCapNhat);
        }

        [Test]
        public void Handle_WithExistingTrinhDoHocVan_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateTrinhDoHocVanCommand { Id = 1, TenTrinhDo = "Updated Trinh Do" };
            _repositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(command, CancellationToken.None));
            StringAssert.Contains("Trình Độ Học Vấn đã tồn tại.", ex.Message);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public void Handle_WithNonExistingTrinhDoHocVan_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateTrinhDoHocVanCommand { Id = 1, TenTrinhDo = "Updated Trinh Do" };
            _repositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrinhDoHocVanEntity)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(command, CancellationToken.None));
            StringAssert.Contains("Trình Độ Học Vấn Không Tồn Tại", ex.Message);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
