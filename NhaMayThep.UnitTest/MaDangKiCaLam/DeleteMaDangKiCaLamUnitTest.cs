using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.MaDangKiCaLam
{
    [TestFixture]
    public class DeleteMaDangKiCaLamUnitTest
    {
        private Mock<IMaDangKiCaLamRepository> _maDangKiCaLamRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteMaDangKiCaLamHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _maDangKiCaLamRepositoryMock = new Mock<IMaDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handlerMock = new DeleteMaDangKiCaLamHandler(_maDangKiCaLamRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task MaDangKiCaLam_EntityValid_ReturnTrue(int id)
        {
            // Arrange
            var expected = "Xóa Thành Công";

            var data = new MaDangKiCaLamEntity
            {
                ID = id,
                Name = "Test",
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(user => user.UserId).Returns("SomeUserId");
            var command = new DeleteMaDangKiCaLamCommand(id); // Assume id = 1 is valid
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _maDangKiCaLamRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Once);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.That(data.NguoiXoaID, Is.EqualTo("SomeUserId")); // Ensuring correct user ID set
            Assert.NotNull(data.NgayXoa); 
        }

        [TestCase(2)]
        public async Task MaDangKiCaLam_EntityNotFound_ReturnFalse(int id)
        {
            // Arrange
            var expected = "Xóa Thất Bại";

            var command = new DeleteMaDangKiCaLamCommand(id); // Assume id = 2 is invalid
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MaDangKiCaLamEntity)null);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Never);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestCase(2)]
        public async Task MaDangKiCaLam_EntityAlreadyDeleted_ReturnFalse(int id)
        {
            // Arrange
            var expected = "Xóa Thất Bại";

            var data = new MaDangKiCaLamEntity
            {
                ID = id,
                Name = "Test",
                NgayXoa = DateTime.Now,
            };

            var command = new DeleteMaDangKiCaLamCommand(id); // Assume id = 2 is deleted
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expected, result);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Never);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
