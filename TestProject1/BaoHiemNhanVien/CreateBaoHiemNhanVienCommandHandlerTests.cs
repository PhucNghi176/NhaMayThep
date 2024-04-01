using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.BaoHiemNhanVien.Create;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.BaoHiemNhanVienTests
{
    [TestFixture]
    public class CreateBaoHiemNhanVienCommandHandlerTests
    {
        private CreateBaoHiemNhanVienCommandHandler _handler;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IBaoHiemNhanVienRepository> _baoHiemNhanVienRepositoryMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<IBaoHiemRepository> _baoHiemRepositoryMock;


        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _mapperMock = new Mock<IMapper>();
            _baoHiemNhanVienRepositoryMock = new Mock<IBaoHiemNhanVienRepository>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _baoHiemRepositoryMock = new Mock<IBaoHiemRepository>();

            _handler = new CreateBaoHiemNhanVienCommandHandler(
                _currentUserServiceMock.Object,
                _mapperMock.Object,
                _baoHiemNhanVienRepositoryMock.Object,
                _nhanVienRepositoryMock.Object,
                _baoHiemRepositoryMock.Object);
            _baoHiemNhanVienRepositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateBaoHiemNhanVienCommand("MSNV123", 1);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing NhanVien

            _baoHiemRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing BaoHiem

            _baoHiemNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false); // No existing BaoHiemNhanVien

            _currentUserServiceMock.Setup(x => x.UserId).Returns("userId");

            _baoHiemNhanVienRepositoryMock.Setup(x => x.Add(It.IsAny<BaoHiemNhanVienEntity>()));

            _baoHiemNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1); // Indicate success

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thành Công!", result);
        }

        [Test]
        public async Task Handle_NonExistingNhanVien_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateBaoHiemNhanVienCommand("NonExistingMSNV", 1);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false); // Non-existing NhanVien

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại! Nhân viên không tồn tại.", result);
        }

        [Test]
        public async Task Handle_NonExistingBaoHiem_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateBaoHiemNhanVienCommand("MSNV123", 999);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing NhanVien

            _baoHiemRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false); // Non-existing BaoHiem

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại! Bảo hiểm không tồn tại.", result);
        }

        [Test]
        public async Task Handle_ExistingBaoHiemNhanVien_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateBaoHiemNhanVienCommand("MSNV123", 1);

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing NhanVien

            _baoHiemRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing BaoHiem

            _baoHiemNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true); // Existing BaoHiemNhanVien

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại! Bảo hiểm đã tồn tại cho nhân viên này.", result);
        }
    }
}
