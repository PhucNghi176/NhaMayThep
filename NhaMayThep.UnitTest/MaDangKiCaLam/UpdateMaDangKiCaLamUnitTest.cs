using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.Create;
using NhaMayThep.Application.MaDangKiCaLamViec.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.MaDangKiCaLam
{
    [TestFixture]
    public class UpdateMaDangKiCaLamUnitTest
    {
        private Mock<IMaDangKiCaLamRepository> _maDangKiCaLamRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateMaDangKiCaLamHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _maDangKiCaLamRepositoryMock = new Mock<IMaDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handlerMock = new UpdateMaDangKiCaLamHandler(_maDangKiCaLamRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)]
        public async Task MaDangKiCaLam_EntityValid_ReturnTrue(int id)
        {
            // Arrange
            var expectedResult = "Cập Nhật Thành Công";

            var existingData = new MaDangKiCaLamEntity
            {
                ID = id,
                Name = "OldData",
                ThoiGianCaLamBatDau = DateTime.Now,
                ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1),
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");
            var command = new UpdateMaDangKiCaLamCommand(existingData.ID, "NewData", existingData.ThoiGianCaLamBatDau, existingData.ThoiGianCaLamKetThuc);
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            _maDangKiCaLamRepositoryMock.Setup(repo => repo.Update(It.IsAny<MaDangKiCaLamEntity>()));
            _maDangKiCaLamRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
            _maDangKiCaLamRepositoryMock.Verify(x => x.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Once);
            _maDangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            // Verify that the properties are correctly updated
            Assert.That(existingData.Name, Is.EqualTo("NewData"));
            Assert.That(existingData.NguoiCapNhatID, Is.EqualTo("SomeUserId"));
            Assert.NotNull(existingData.NgayCapNhat);
        }

        [TestCase(2)]
        public async Task MaDangKiCaLam_EntityNotFound_ReturnFalse(int id)
        {
            // Arrange

            var command = new UpdateMaDangKiCaLamCommand(id, "NewData", DateTime.Now, DateTime.Now.AddDays(1) ); //Assume id = 2 is invalid
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MaDangKiCaLamEntity)null);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _maDangKiCaLamRepositoryMock.Verify(x => x.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Never);
            _maDangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }

        [TestCase(2)]
        public async Task MaDangKiCaLam_EntityAlreadyDeleted_ReturnFalse(int id)
        {
            // Arrange
            var existingData = new MaDangKiCaLamEntity
            {
                ID = id,
                Name = "OldData",
                ThoiGianCaLamBatDau = DateTime.Now,
                ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1),
                NgayXoa = DateTime.Now
            };

            var command = new UpdateMaDangKiCaLamCommand(id, "NewData", DateTime.Now, DateTime.Now.AddDays(1)); //Assume id = 2 is deleted
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _maDangKiCaLamRepositoryMock.Verify(x => x.Update(It.IsAny<MaDangKiCaLamEntity>()), Times.Never);
            _maDangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }
    }
}
