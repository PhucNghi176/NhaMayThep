using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.DangKiCaLam.CheckOut;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.UnitTest.DangKiCaLam
{
    [TestFixture]
    public class CheckOutTest
    {
        private Mock<IDangKiCaLamRepository> _repositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private CheckOutCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new CheckOutCommandHandler(_repositoryMock.Object, null, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidCheckOut_ShouldReturnSuccessMessage()
        {
            // Arrange
            var command = new CheckOutCommand { Id = "validId" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DangKiCaLamEntity
                {
                    ID = "validId",
                    ThoiGianCaLamKetThuc = DateTime.UtcNow.AddHours(-1), // Assuming the shift ended an hour ago
                    ThoiGianChamCongKetThuc = null // Not checked out yet
                });
            _repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1); // Simulate successful save

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Check-out thành công", result);
            _repositoryMock.Verify(x => x.Update(It.IsAny<DangKiCaLamEntity>()), Times.Once);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

      

        [Test]
        public void Handle_NonExistentDangKiCaLam_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new CheckOutCommand { Id = "nonexistentId" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync((DangKiCaLamEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
