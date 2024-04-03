using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinChucVuDang.DeleteThongTinChucVuDang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuDangUnitTest
{
    [TestFixture]
    public class DeleteThongTinChucVuDangUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinChucVuDangRepository> _thongTinChucVuDangRepositoryMock;
        private DeleteThongTinChucVuDangCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinChucVuDangRepositoryMock = new Mock<IThongTinChucVuDangRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new DeleteThongTinChucVuDangCommandHandler(_thongTinChucVuDangRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task ThongTinChucVuDang_DeleteThongTinChucVuDang_ReturnTrue(int id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new ThongTinChucVuDangEntity
            {
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new DeleteThongTinChucVuDangCommand(id);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1)]
        public async Task ThongTinChucVuDang_DeleteThongTinChucVuDang_ReturnFalse(int id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new ThongTinChucVuDangEntity
            {
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new DeleteThongTinChucVuDangCommand(id);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<int>());

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0)]
        public async Task ThongTinChucVuDang_DeleteThongTinChucVuDang_NotFoundException(int id)
        {
            // Arrange
            var command = new DeleteThongTinChucVuDangCommand(id);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinChucVuDangEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
