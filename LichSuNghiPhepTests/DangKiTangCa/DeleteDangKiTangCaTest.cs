using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiCaLam.Delete;
using NhaMayThep.Application.DangKiTangCa.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NhaMayThep.UnitTest.DangKiTangCa
{
    [TestFixture]
    public class DeleteDangKiTangCaTest
    {
        private Mock<IDangKiTangCaRepository> _dangKiTangCaRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteDangKiTangCaHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _dangKiTangCaRepositoryMock = new Mock<IDangKiTangCaRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new DeleteDangKiTangCaHandler(_dangKiTangCaRepositoryMock.Object, _mapperMock.Object, _currentUserServiceMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }


        [Test]
        public async Task Handle_DangKiTangCaExists_ShouldSoftDeleteSuccessfully()
        {
            // Arrange
            var validId = "validId";
             var command = new DeleteDangKiTangCaCommand(validId);

            var existingDangKiTangCa = new DangKiTangCaEntity
            {
                ID = validId,
                MaSoNhanVien = "validMaSoNhanVien",
                NgayLamTangCa = DateTime.Now.AddDays(-1),
                // Other properties as necessary
                NguoiDuyet = "validNguoiDuyet",
                NgayXoa = null // Ensure it's initially not deleted
            };

            _dangKiTangCaRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiTangCaEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingDangKiTangCa);

            _dangKiTangCaRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Đăng Kí Tăng Ca thành công", result);
            Assert.IsNotNull(existingDangKiTangCa.NgayXoa, "NgayXoa should be set to indicate soft deletion.");
            _dangKiTangCaRepositoryMock.Verify(x => x.Update(It.Is<DangKiTangCaEntity>(e => e.ID == validId && e.NgayXoa.HasValue)), Times.Once);
            _dangKiTangCaRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


    }
}
