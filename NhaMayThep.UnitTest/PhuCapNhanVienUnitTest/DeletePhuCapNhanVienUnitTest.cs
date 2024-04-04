using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhuCapNhanVien.DeletePhuCapNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.PhuCapNhanVienUnitTest
{
    [TestFixture]
    public class DeletePhuCapNhanVienUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IPhuCapNhanVienRepository> _phuCapNhanVienRepositoryMock;
        private DeletePhuCapNhanVienCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _phuCapNhanVienRepositoryMock = new Mock<IPhuCapNhanVienRepository>();
            _handlerMock = new DeletePhuCapNhanVienCommandHandler(_phuCapNhanVienRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase("1")]
        public async Task PhuCapNhanVien_DeletePhuCapNhanVien_ReturnTrue(string id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new PhuCapNhanVienEntity
            {
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new DeletePhuCapNhanVienCommand(id);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("1")]
        public async Task PhuCapNhanVien_DeletePhuCapNhanVien_ReturnFalse(string id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new PhuCapNhanVienEntity
            {
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new DeletePhuCapNhanVienCommand(id);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _phuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("0")]
        public async Task PhuCapNhanVien_DeletePhuCapNhanVien_NotFoundException(string id)
        {
            // Arrange
            var command = new DeletePhuCapNhanVienCommand(id);
            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((PhuCapNhanVienEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
