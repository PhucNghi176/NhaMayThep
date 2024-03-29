using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using System.Linq.Expressions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LichSuNghiPhep;

namespace NhaMayThep.Application.UnitTests.LichSuNghiPhep
{
    [TestFixture]
    public class DeleteLichSuNghiPhepCommandHandlerTests
    {
        private Mock<ILichSuNghiPhepRepository> _lichSuNghiPhepRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteLichSuNghiPhepCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _lichSuNghiPhepRepositoryMock = new Mock<ILichSuNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new DeleteLichSuNghiPhepCommandHandler(_lichSuNghiPhepRepositoryMock.Object, _mapperMock.Object, _currentUserServiceMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public async Task Handle_LichSuNghiPhepExists_ShouldSoftDeleteSuccessfully()
        {
            // Arrange
            var command = new DeleteLichSuNghiPhepCommand("validId");
            var lichSuNghiPhep = new LichSuNghiPhepNhanVienEntity
            {
                ID = command.Id,
                MaSoNhanVien = "someMaSoNhanVien",
                LoaiNghiPhepID = 1,
                NgayBatDau = DateTime.Now.AddDays(-10),
                NgayKetThuc = DateTime.Now.AddDays(-5),
                LyDo = "Valid reason for leave",
                NguoiDuyet = "validNguoiDuyetId",
                NgayXoa = null // Ensure this is initially null to simulate an entity that hasn't been deleted yet
            };

            var expectedDto = new LichSuNghiPhepDto { Id = command.Id };

            // Ensure the FindAsync method is correctly mocked to return the entity when the provided condition matches
            _lichSuNghiPhepRepositoryMock.Setup(r => r.FindAsync(
                It.IsAny<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(lichSuNghiPhep);

            // Mock the behavior of the mapper to return the expected DTO
            _mapperMock.Setup(m => m.Map<LichSuNghiPhepDto>(lichSuNghiPhep)).Returns(expectedDto);

            // Mock the UnitOfWork.SaveChangesAsync to simulate the saving changes behavior
            // Since it's returning Task<int>, let's simulate a successful operation by returning 1
            _lichSuNghiPhepRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
            // Verify that the entity was updated (soft deleted) by checking if NgayXoa is set
            _lichSuNghiPhepRepositoryMock.Verify(r => r.Update(It.Is<LichSuNghiPhepNhanVienEntity>(e => e.NgayXoa != null)), Times.Once);
            // Verify that changes were indeed saved
            _lichSuNghiPhepRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


        [Test]
        public void Handle_LichSuNghiPhepDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new DeleteLichSuNghiPhepCommand("invalidId");

            _lichSuNghiPhepRepositoryMock.Setup(r => r.FindAsync(
                It.IsAny<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync((LichSuNghiPhepNhanVienEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
