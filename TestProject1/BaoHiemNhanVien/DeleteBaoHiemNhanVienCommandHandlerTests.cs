using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.BaoHiemNhanVien.Delete;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.Tests
{
    [TestFixture]
    public class DeleteBaoHiemNhanVienCommandHandlerTests
    {
        private DeleteBaoHiemNhanVienCommandHandler _handler;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IBaoHiemNhanVienRepository> _baoHiemNhanVienRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _baoHiemNhanVienRepositoryMock = new Mock<IBaoHiemNhanVienRepository>();
            _handler = new DeleteBaoHiemNhanVienCommandHandler(
                _currentUserServiceMock.Object,
                _baoHiemNhanVienRepositoryMock.Object);
            _baoHiemNhanVienRepositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());

        }

        [Test]
        public async Task Handle_ValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new DeleteBaoHiemNhanVienCommand("your_id");

            var baoHiemNhanVienEntity = new BaoHiemNhanVienEntity()
            {
                ID = "your_id",
                MaSoNhanVien = "your_ma_so_nhan_vien",
                BaoHiem = 1,
                NgayXoa = null // Not deleted yet
            };

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(baoHiemNhanVienEntity); // Assuming baoHiemNhanVienEntity is the instance you want to return

            _currentUserServiceMock.Setup(x => x.UserId).Returns("your_user_id");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công!", result);
            Assert.AreEqual(DateTime.Now.Date, baoHiemNhanVienEntity.NgayXoa?.Date); // Check if the deletion date is set to today
            Assert.AreEqual("your_user_id", baoHiemNhanVienEntity.NguoiXoaID); // Check if the user ID is set correctly
            _baoHiemNhanVienRepositoryMock.Verify(x => x.Update(baoHiemNhanVienEntity), Times.Once); // Ensure Update method is called
            _baoHiemNhanVienRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once); // Ensure SaveChangesAsync is called
        }

        [Test]
        public async Task Handle_NonExistingEntity_ReturnsFailureMessage()
        {
            // Arrange
            var command = new DeleteBaoHiemNhanVienCommand("non_existing_id");

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((BaoHiemNhanVienEntity)null!); // Simulate not finding the entity

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại! Không tìm thấy hoặc bản ghi đã bị xóa trước đó.", result);
            _baoHiemNhanVienRepositoryMock.Verify(x => x.Update(It.IsAny<BaoHiemNhanVienEntity>()), Times.Never); // Ensure Update method is not called
            _baoHiemNhanVienRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never); // Ensure SaveChangesAsync is not called
        }
    }
}
