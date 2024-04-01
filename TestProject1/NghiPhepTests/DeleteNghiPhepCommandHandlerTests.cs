using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Delete;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.NghiPhepTests
{
    [TestFixture]
    public class DeleteNghiPhepCommandHandlerTests
    {
        private DeleteNghiPhepCommandHandler _handler;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INghiPhepRepository> _nghiPhepRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nghiPhepRepositoryMock = new Mock<INghiPhepRepository>();
            _handler = new DeleteNghiPhepCommandHandler(_currentUserServiceMock.Object, _nghiPhepRepositoryMock.Object);
            _nghiPhepRepositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());

        }

        [Test]
        public async Task Handle_WithValidId_DeletesNghiPhepAndReturnsSuccessMessage()
        {
            // Arrange
            var nghiPhepId = "1";
            var nghiPhep = new NghiPhepEntity { ID = nghiPhepId, NgayXoa = null, LoaiNghiPhepID = 1, MaSoNhanVien = "ExampleMaSoNhanVien" };

            // Thiết lập hành vi cho mock repository
            _nghiPhepRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(nghiPhep);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("userId");

            // Act
            var result = await _handler.Handle(new DeleteNghiPhepCommand(nghiPhepId), CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công!", result);
        }


        [Test]
        public async Task Handle_WithInvalidId_ReturnsFailureMessage()
        {
            // Arrange
            var invalidNghiPhepId = "999";
            _nghiPhepRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                   .ReturnsAsync((NghiPhepEntity)null);

            // Act
            var result = await _handler.Handle(new DeleteNghiPhepCommand(invalidNghiPhepId), CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại! Không tìm thấy hoặc bản ghi đã bị xóa trước đó.", result);
            _nghiPhepRepositoryMock.Verify(x => x.Update(It.IsAny<NghiPhepEntity>()), Times.Never);
            _nghiPhepRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
