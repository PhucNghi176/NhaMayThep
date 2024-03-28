using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Exceptions;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinDaoTao;
using NhaMayThep.Application.ThongTinDaoTao.Update;
using NhaMayThep.Domain.Repositories;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.ThongTinDaoTaoTests
{
    [TestFixture]
    public class UpdateThongTinDaoTaoCommandHandlerTests
    {
        private UpdateThongTinDaoTaoCommandHandler _handler;
        private Mock<IThongTinDaoTaoRepository> _thongTinDaoTaoRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ITrinhDoHocVanRepository> _trinhDoHocVanRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _thongTinDaoTaoRepositoryMock = new Mock<IThongTinDaoTaoRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _trinhDoHocVanRepositoryMock = new Mock<ITrinhDoHocVanRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new UpdateThongTinDaoTaoCommandHandler(
                _currentUserServiceMock.Object,
                _thongTinDaoTaoRepositoryMock.Object,
                _mapperMock.Object,
                _trinhDoHocVanRepositoryMock.Object);

            // Thiết lập một UserId mẫu cho _currentUserService
            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public void Handle_ThongTinDaoTaoNotFound_ThrowsNotFoundException()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinDaoTaoEntity)null!);
            var command = new UpdateThongTinDaoTaoCommand("TenTruong", "ChuyenNganh", DateTime.Now, 1, 1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_InvalidTrinhDoHocVanId_ThrowsNotFoundException()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ThongTinDaoTaoEntity());
            _trinhDoHocVanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            var command = new UpdateThongTinDaoTaoCommand("TenTruong", "ChuyenNganh", DateTime.Now, 1, 1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task Handle_ValidCommand_ReturnsDto()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ThongTinDaoTaoEntity());
            _trinhDoHocVanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _mapperMock.Setup(m => m.Map<ThongTinDaoTaoDto>(It.IsAny<ThongTinDaoTaoEntity>()))
                .Returns(new ThongTinDaoTaoDto());
            var command = new UpdateThongTinDaoTaoCommand("TenTruong", "ChuyenNganh", DateTime.Now, 1, 1);

            // Act
            var result = _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }
    }
}
