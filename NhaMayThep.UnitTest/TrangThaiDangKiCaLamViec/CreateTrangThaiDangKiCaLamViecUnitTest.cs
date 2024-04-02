using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.TrangThaiDangKiCaLamViec
{
    [TestFixture]
    public class CreateTrangThaiDangKiCaLamViecUnitTest
    {
        private Mock<ITrangThaiDangKiCaLamViecRepository> _trangThaiDangKiCaLamViecMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private CreateTrangThaiDangKiCaLamViecHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _trangThaiDangKiCaLamViecMock = new Mock<ITrangThaiDangKiCaLamViecRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handlerMock = new CreateTrangThaiDangKiCaLamViecHandler(_trangThaiDangKiCaLamViecMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_CreateValidEntity_ReturnTrue()
        {
            // Arrange
            var expectedResult = "Tạo Mới Thành Công";

            var data = new TrangThaiDangKiCaLamViecEntity
            {
                Name = "Test"
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");
            var command = new CreateTrangThaiDangKiCaLamViecCommand(data.Name);
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((TrangThaiDangKiCaLamViecEntity)null);

            _trangThaiDangKiCaLamViecMock.Setup(repo => repo.Add(It.IsAny<TrangThaiDangKiCaLamViecEntity>()));
            _trangThaiDangKiCaLamViecMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.Add(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Once);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task Handle_CreateDuplicateEntity_ThrowsException()
        {
            //Arrange
            var expected = "Loại Trạng Thái trên đã tồn tại!";
            var data = new TrangThaiDangKiCaLamViecEntity
            {
                Name = "Test"
            };

            var command = new CreateTrangThaiDangKiCaLamViecCommand(data.Name);
            _trangThaiDangKiCaLamViecMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            //Assert
            Assert.AreEqual(expected, result);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.Add(It.IsAny<TrangThaiDangKiCaLamViecEntity>()), Times.Never);
            _trangThaiDangKiCaLamViecMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
