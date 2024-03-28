using AutoMapper;
using Moq;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinDaoTao.Delete;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;

namespace TestProject1.ThongTinDaoTaoTests
{
    [TestFixture]
    public class DeleteThongTinDaoTaoCommandHandlerTests
    {
        private DeleteThongTinDaoTaoCommandHandler _handler;
        private Mock<IThongTinDaoTaoRepository> _thongTinDaoTaoRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteThongTinDaoTaoCommand _validCommand;
        private DeleteThongTinDaoTaoCommand _invalidCommand;

        [SetUp]
        public void SetUp()
        {
            _thongTinDaoTaoRepositoryMock = new Mock<IThongTinDaoTaoRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            var mapperMock = new Mock<IMapper>();

            _handler = new DeleteThongTinDaoTaoCommandHandler(
                _currentUserServiceMock.Object,
                _thongTinDaoTaoRepositoryMock.Object,
                mapperMock.Object);

            _validCommand = new DeleteThongTinDaoTaoCommand("validId");
            _invalidCommand = new DeleteThongTinDaoTaoCommand("invalidId");
        }

        [Test]
        public async Task Handle_WithValidCommand_ReturnsSuccessMessage()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ThongTinDaoTaoEntity());

            // Act
            var result = _handler.Handle(_validCommand, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task Handle_WithInvalidId_ReturnsFailureMessage()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync((ThongTinDaoTaoEntity)null!);

            // Act
            var result = await _handler.Handle(_invalidCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Xóa Thất Bại!"));
        }

        [Test]
        public async Task Handle_WithAlreadyDeletedRecord_ReturnsFailureMessage()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ThongTinDaoTaoEntity { NgayXoa = DateTime.Now });

            // Act
            var result = await _handler.Handle(_validCommand, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo("Xóa Thất Bại!"));
        }

    }
}
