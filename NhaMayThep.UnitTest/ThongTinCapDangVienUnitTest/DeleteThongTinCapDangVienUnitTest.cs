using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCapDangVien.DeleteThongTinCapDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinCapDangVienUnitTest
{
    [TestFixture]
    public class DeleteThongTinCapDangVienUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinCapDangVienRepository> _thongTinCapDangVienRepositoryMock;
        private DeleteThongTinCapDangVienCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinCapDangVienRepositoryMock = new Mock<IThongTinCapDangVienRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new DeleteThongTinCapDangVienCommandHandler(_thongTinCapDangVienRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task ThongTinCapDangVien_DeleteThongTinCapDangVien_ReturnTrue(int id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new ThongTinCapDangVienEntity
            {
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new DeleteThongTinCapDangVienCommand(id);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1)]
        public async Task ThongTinCapDangVien_DeleteThongTinCapDangVien_ReturnFalse(int id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new ThongTinCapDangVienEntity
            {
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new DeleteThongTinCapDangVienCommand(id);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<int>());

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0)]
        public async Task ThongTinCapDangVien_DeleteThongTinCapDangVien_NotFoundException(int id)
        {
            // Arrange
            var command = new DeleteThongTinCapDangVienCommand(id);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCapDangVienEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
