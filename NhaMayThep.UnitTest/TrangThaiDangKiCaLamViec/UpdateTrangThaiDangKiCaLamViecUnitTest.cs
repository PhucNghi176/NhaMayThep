using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.TrangThaiDangKiCaLamViec
{
    [TestFixture]
    public class UpdateTrangThaiDangKiCaLamViecUnitTest
    {
        private Mock<ITrangThaiDangKiCaLamViecRepository> _trangThaiDangKiCaLamViecMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateTrangThaiDangKiCaLamViecHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _trangThaiDangKiCaLamViecMock = new Mock<ITrangThaiDangKiCaLamViecRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handlerMock = new UpdateTrangThaiDangKiCaLamViecHandler(_trangThaiDangKiCaLamViecMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task TrangThaiDangKiCaLamViec_EntityValid_ReturnTrue(int id)
        {
            // Arrange
            var expectedResult = "Cập Nhật Thành Công";

            var existingData = new TrangThaiDangKiCaLamViecEntity
            {
                ID = id,
                Name = "OldData",
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");
            var command = new UpdateTrangThaiDangKiCaLamViecCommand(existingData.ID, "NewData");
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            _trangThaiDangKiCaLamViecMock.Setup(repo => repo.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()));
            _trangThaiDangKiCaLamViecMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            _trangThaiDangKiCaLamViecMock.Verify(x => x.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Once);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.That(existingData.Name, Is.EqualTo("NewData"));
            Assert.That(existingData.NguoiCapNhatID, Is.EqualTo("SomeUserId"));
            Assert.NotNull(existingData.NgayCapNhat);
        }

        [TestCase(2)]
        public async Task TrangThaiDangKiCaLamViec_EntityNotFound_ReturnFalse(int id)
        {
            // Arrange

            var command = new UpdateTrangThaiDangKiCaLamViecCommand(id, "NewData"); //Assume id = 2 is invalid
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrangThaiDangKiCaLamViecEntity)null);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _trangThaiDangKiCaLamViecMock.Verify(x => x.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Never);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }

        [TestCase(2)]
        public async Task TrangThaiDangKiCaLamViec_EntityAlreadyDeleted_ReturnFalse(int id)
        {
            // Arrange
            var existingData = new TrangThaiDangKiCaLamViecEntity
            {
                ID = id,
                Name = "OldData",
                NgayXoa = DateTime.Now
            };

            var command = new UpdateTrangThaiDangKiCaLamViecCommand(id, "NewData"); //Assume id = 2 is deleted
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _trangThaiDangKiCaLamViecMock.Verify(x => x.Update(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Never);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }
    }
}
