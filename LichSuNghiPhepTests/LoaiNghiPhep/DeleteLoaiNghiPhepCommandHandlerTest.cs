using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep.Delete;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.UnitTest.LoaiNghiPhep
{
    [TestFixture]
    public class DeleteLoaiNghiPhepCommandHandlerTest
    {
        private Mock<ILoaiNghiPhepRepository> _repositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteLoaiNghiPhepHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ILoaiNghiPhepRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new DeleteLoaiNghiPhepHandler(_repositoryMock.Object, _currentUserServiceMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public async Task Handle_LoaiNghiPhepExists_ShouldSoftDeleteSuccessfully()
        {
            // Arrange
            var command = new DeleteLoaiNghiPhepCommand(1); // Assuming the ID is an int
            var loaiNghiPhep = new LoaiNghiPhepEntity
            {
                ID = command.Id,
                Name = "Some Name",
                NgayXoa = null
            };

            _repositoryMock.Setup(r => r.FindAsync(
                It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(loaiNghiPhep);

            _repositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa thành công", result);
            _repositoryMock.Verify(r => r.Update(It.Is<LoaiNghiPhepEntity>(e => e.NgayXoa != null)), Times.Once);
            _repositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public void Handle_GivenInvalidId_ShouldThrowNotFoundException()
        {
            var command = new DeleteLoaiNghiPhepCommand(id: 999); // Assuming an invalid ID
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync((LoaiNghiPhepEntity)null);

            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_GivenAlreadyDeletedId_ShouldThrowNotFoundExceptionWithMessage()
        {
            var command = new DeleteLoaiNghiPhepCommand(id: 2); // Assuming this ID is already deleted
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(new LoaiNghiPhepEntity
                           {
                               ID = command.Id,
                               Name = "Already Deleted Name",
                               NgayXoa = DateTime.UtcNow
                           });

            var ex = Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Id này đã bị xóa rồi"));
        }
    }
}
