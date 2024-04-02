using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.TrangThaiDangKiCaLamViec
{
    public class DeleteTrangThaiDangKiCaLamViecUnitTest
    {
        private Mock<ITrangThaiDangKiCaLamViecRepository> _trangThaiDangKiCaLamViecMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteTrangThaiDangKiCaLamViecHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _trangThaiDangKiCaLamViecMock = new Mock<ITrangThaiDangKiCaLamViecRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handlerMock = new DeleteTrangThaiDangKiCaLamViecHandler(_trangThaiDangKiCaLamViecMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task TrangThaiDangKiCaLamViec_EntityValid_ReturnTrue(int id)
        {
            // Arrange
            var expected = "Xóa Thành Công";

            var data = new TrangThaiDangKiCaLamViecEntity
            {
                ID = id,
                Name = "Test",
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(user => user.UserId).Returns("SomeUserId");
            var command = new DeleteTrangThaiDangKiCaLamViecCommand(id); // Assume id = 1 is valid
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _trangThaiDangKiCaLamViecMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Once);
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.That(data.NguoiXoaID, Is.EqualTo("SomeUserId")); // Ensuring correct user ID set
            Assert.NotNull(data.NgayXoa);
        }

        [TestCase(2)]
        public async Task TrangThaiDangKiCaLamViec_EntityNotFound_ReturnFalse(int id)
        {
            // Arrange
            var expected = "Xóa Thất Bại";

            var command = new DeleteTrangThaiDangKiCaLamViecCommand(id); // Assume id = 2 is invalid
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrangThaiDangKiCaLamViecEntity)null);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Never);
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestCase(2)]
        public async Task TrangThaiDangKiCaLamViec_EntityAlreadyDeleted_ReturnFalse(int id)
        {
            // Arrange
            var expected = "Xóa Thất Bại";

            var data = new TrangThaiDangKiCaLamViecEntity
            {
                ID = id,
                Name = "Test",
                NgayXoa = DateTime.Now,
            };

            var command = new DeleteTrangThaiDangKiCaLamViecCommand(id); // Assume id = 2 is deleted
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Never);
            _trangThaiDangKiCaLamViecMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
