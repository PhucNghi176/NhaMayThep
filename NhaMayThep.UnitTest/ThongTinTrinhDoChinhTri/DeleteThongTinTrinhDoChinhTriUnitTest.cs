using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.DeleteThongTinTrinhDoChinhTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinTrinhDoChinhTri
{
    [TestFixture]
    public class DeleteThongTinTrinhDoChinhTriUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinTrinhDoChinhTriRepository> _thongTinTrinhDoChinhTriRepositoryMock;
        private DeleteThongTinTrinhDoChinhTriCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinTrinhDoChinhTriRepositoryMock = new Mock<IThongTinTrinhDoChinhTriRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new DeleteThongTinTrinhDoChinhTriCommandHandler(_thongTinTrinhDoChinhTriRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task ThongTinTrinhDoChinhTri_DeleteThongTinTrinhDoChinhTri_ReturnTrue(int id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new DeleteThongTinTrinhDoChinhTriCommand(id);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1)]
        public async Task ThongTinTrinhDoChinhTri_DeleteThongTinTrinhDoChinhTri_ReturnFalse(int id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new DeleteThongTinTrinhDoChinhTriCommand(id);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(It.IsAny<int>());

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(0)]
        public async Task ThongTinTrinhDoChinhTri_DeleteThongTinTrinhDoChinhTri_NotFoundException(int id)
        {
            // Arrange
            var command = new DeleteThongTinTrinhDoChinhTriCommand(id);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinTrinhDoChinhTriEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
