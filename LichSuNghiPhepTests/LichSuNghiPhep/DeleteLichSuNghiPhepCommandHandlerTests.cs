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
                NguoiDuyet = "validNguoiDuyetId"
            };

            var expectedDto = new LichSuNghiPhepDto { Id = command.Id };

            _lichSuNghiPhepRepositoryMock.Setup(r => r.FindAsync(
                It.Is<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(expr => expr.Compile()(lichSuNghiPhep)),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(lichSuNghiPhep);

            _mapperMock.Setup(m => m.Map<LichSuNghiPhepDto>(lichSuNghiPhep)).Returns(expectedDto);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
            _lichSuNghiPhepRepositoryMock.Verify(r => r.Update(lichSuNghiPhep), Times.Once);
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
