using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiCaLam.Delete;
using NhaMayThep.Application.LichSuNghiPhep.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.DangKiCaLam
{
    [TestFixture]
    public class DeleteDangKiCaLamTest
    {
        private Mock<IDangKiCaLamRepository> _dangKiCaLamRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteDangKiCaLamCommandHandler _handler;


        [SetUp]
        public void SetUp()
        {
            _dangKiCaLamRepositoryMock = new Mock<IDangKiCaLamRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new DeleteDangKiCaLamCommandHandler(_dangKiCaLamRepositoryMock.Object, _mapperMock.Object, _currentUserServiceMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }
        [Test]
        public async Task Handle_DangKiCaLamExists_ShouldSoftDeleteSuccessfully()
        {
            // Arrange
            var command = new DeleteDangKiCaLamCommand("validId");
            var lichSuNghiPhep = new DangKiCaLamEntity
            {
                ID = command.Id,
                MaSoNhanVien = "someMaSoNhanVien",
                NgayXoa = null
            };
            _dangKiCaLamRepositoryMock.Setup(r => r.FindAsync(
               It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(),
               It.IsAny<CancellationToken>()
           )).ReturnsAsync(lichSuNghiPhep);

            _dangKiCaLamRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Đăng Kí Ca Làm thành công", result); // Corrected to match the expected string message
            _dangKiCaLamRepositoryMock.Verify(r => r.Update(It.Is<DangKiCaLamEntity>(e => e.NgayXoa != null)), Times.Once);
            _dangKiCaLamRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


        [Test]
        public void HandleDangKiCaLamDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new DeleteDangKiCaLamCommand("invalidId");

            _dangKiCaLamRepositoryMock.Setup(r => r.FindAsync(
                It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync((DangKiCaLamEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command,CancellationToken.None));
        }
    }
}