using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiHoaDon.Create;
using System.Linq.Expressions;

namespace TestProject1.LoaiHoaDonTest
{
    public class CreateLoaiHoaDonCommandHandlerTests
    {
        private Mock<ILoaiHoaDonRepository> _loaiHoaDonRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;
        private CreateLoaiHoaDonCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _loaiHoaDonRepositoryMock = new Mock<ILoaiHoaDonRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateLoaiHoaDonCommandHandler(
                _loaiHoaDonRepositoryMock.Object,
                _currentUserServiceMock.Object,
                _mapperMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateLoaiHoaDonCommand("TestName");
            var expectedMessage = "Tạo Mới Thành Công";

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");
            _loaiHoaDonRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                                      .ReturnsAsync((LoaiHoaDonEntity)null);

            // Giả định rằng lưu thành công bằng cách trả về một số lượng hàng ảo khác không
            _loaiHoaDonRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                                      .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expectedMessage));
            _loaiHoaDonRepositoryMock.Verify(x => x.Add(It.IsAny<LoaiHoaDonEntity>()), Times.Once);
            _loaiHoaDonRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public void Handle_ExistingName_ThrowsNotFoundException()
        {
            // Arrange
            var command = new CreateLoaiHoaDonCommand("TestName");
            var existingEntity = new LoaiHoaDonEntity { Name = "TestName" };

            _loaiHoaDonRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                                      .ReturnsAsync(existingEntity);

            // Act & Assert
            Assert.ThrowsAsync<DuplicationException>(() => _handler.Handle(command, CancellationToken.None));
            _loaiHoaDonRepositoryMock.Verify(x => x.Add(It.IsAny<LoaiHoaDonEntity>()), Times.Never);
            _loaiHoaDonRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
