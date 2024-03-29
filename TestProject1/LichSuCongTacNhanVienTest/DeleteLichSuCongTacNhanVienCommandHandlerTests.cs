using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuCongTacNhanVien.Delete;
using NUnit.Framework;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.LichSuCongTacNhanVienTest
{
    [TestFixture]
    public class DeleteLichSuCongTacNhanVienCommandHandlerTests
    {
        private DeleteLichSuCongTacNhanVienCommandHandler _handler;
        private Mock<ILichSuCongTacNhanVienRepository> _lichSuCongTacNhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        [SetUp]
        public void SetUp()
        {
            _lichSuCongTacNhanVienRepositoryMock = new Mock<ILichSuCongTacNhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handler = new DeleteLichSuCongTacNhanVienCommandHandler(
                _lichSuCongTacNhanVienRepositoryMock.Object,
                Mock.Of<IMapper>(),
                _currentUserServiceMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_DeletesLichSuCongTacNhanVien()
        {
            // Arrange
            var command = new DeleteLichSuCongTacNhanVienCommand("1"); // Provide a valid ID here
            var lichSuCongTacNhanVien = new LichSuCongTacNhanVienEntity
            {
                MaSoNhanVien = "123", // Provide a valid maSoNhanVien here
                LoaiCongTacID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                NoiCongTac = "TestLocation",
                LyDo = "TestReason"
            };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTacNhanVien);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("TestUserId");

            // Setup mock for Update method
            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.Update(It.IsAny<LichSuCongTacNhanVienEntity>()));

            // Setup mock for SaveChangesAsync method to return 1 indicating success
            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công", result);

            // Verify repository interactions
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.Update(It.IsAny<LichSuCongTacNhanVienEntity>()), Times.Once);
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.AreEqual("TestUserId", lichSuCongTacNhanVien.NguoiXoaID);
            Assert.NotNull(lichSuCongTacNhanVien.NgayXoa);
        }




        [Test]
        public async Task Handle_InvalidRequest_ReturnsFailedMessage()
        {
            // Arrange
            var command = new DeleteLichSuCongTacNhanVienCommand("1"); // Provide a valid ID here
            LichSuCongTacNhanVienEntity lichSuCongTacNhanVien = null;

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTacNhanVien);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại", result);

            // Verify repository interactions
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.Update(It.IsAny<LichSuCongTacNhanVienEntity>()), Times.Never);
            _lichSuCongTacNhanVienRepositoryMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
