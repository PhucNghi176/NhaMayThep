using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinDaoTao.Create;
using NhaMayThep.Application.ThongTinDaoTao.CreateThongTinDaoTao;
using NhaMayThep.Domain.Repositories;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.ThongTinDaoTaoTests
{
    [TestFixture]
    public class CreateThongTinDaoTaoCommandHandlerTests
    {
        private CreateThongTinDaoTaoCommandHandler _handler;
        private Mock<IThongTinDaoTaoRepository> _thongTinDaoTaoRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<ITrinhDoHocVanRepository> _trinhDoHocVanRepositoryMock;
        private CreateThongTinDaoTaoCommand _validCommand;
        private CreateThongTinDaoTaoCommand _invalidCommand;

        [SetUp]
        public void SetUp()
        {
            _thongTinDaoTaoRepositoryMock = new Mock<IThongTinDaoTaoRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _trinhDoHocVanRepositoryMock = new Mock<ITrinhDoHocVanRepository>();
            var mapperMock = new Mock<IMapper>();

            _handler = new CreateThongTinDaoTaoCommandHandler(
                _currentUserServiceMock.Object,
                mapperMock.Object,
                _thongTinDaoTaoRepositoryMock.Object,
                _trinhDoHocVanRepositoryMock.Object,
                _nhanVienRepositoryMock.Object);

            _validCommand = new CreateThongTinDaoTaoCommand(
                "validNhanVienId",
                1,
                "Valid School",
                "Valid Major",
                DateTime.Now,
                2
            );

            _invalidCommand = new CreateThongTinDaoTaoCommand(
                "invalidEmployeeId",
                1,
                "Invalid School",
                "Invalid Major",
                DateTime.Now,
                2
            );
        }

        [Test]
        public async Task Handle_WithValidCommand_ReturnsSuccessMessage()
        {
            // Arrange
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _trinhDoHocVanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _thongTinDaoTaoRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);
            _thongTinDaoTaoRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(_validCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Thành Công!"));
        }

        [Test]
        public async Task Handle_WithInvalidEmployeeId_ReturnsFailureMessage()
        {
            // Arrange
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(_invalidCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Thất Bại! Nhân viên ID không tồn tại."));
        }

        [Test]
        public async Task Handle_WithInvalidEducationLevelId_ReturnsFailureMessage()
        {
            // Arrange
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _trinhDoHocVanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(_invalidCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Thất Bại! MaTrinhDoHocVanID không hợp lệ."));
        }

        [Test]
        public async Task Handle_WithExistingTrainingInfo_ReturnsFailureMessage()
        {
            // Arrange
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _trinhDoHocVanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _thongTinDaoTaoRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

            // Act
            var result = await _handler.Handle(_invalidCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Thất Bại! Nhân viên đã có trình độ đào tạo."));
        }
    }
}
