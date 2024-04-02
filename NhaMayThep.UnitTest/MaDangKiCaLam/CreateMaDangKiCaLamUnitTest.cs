using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.Create;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.MaDangKiCaLam
{
    [TestFixture]
    public class CreateMaDangKiCaLamUnitTest
    {
        private Mock<IMaDangKiCaLamRepository> _maDangKiCaLamRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private CreateMaDangKiCaLamHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _maDangKiCaLamRepositoryMock = new Mock<IMaDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handlerMock = new CreateMaDangKiCaLamHandler(_maDangKiCaLamRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task MaDangKiCaLam_CreateValidEntity_ReturnTrue()
        {
            // Arrange
            var expectedResult = "Tạo Mới Thành Công";

            var data = new MaDangKiCaLamEntity
            {
                Name = "Test",
                ThoiGianCaLamBatDau = DateTime.Now,
                ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1),
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");
            var command = new CreateMaDangKiCaLamCommand(data.Name, data.ThoiGianCaLamBatDau, data.ThoiGianCaLamKetThuc);
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((MaDangKiCaLamEntity)null);

            _maDangKiCaLamRepositoryMock.Setup(repo => repo.Add(It.IsAny<MaDangKiCaLamEntity>()));
            _maDangKiCaLamRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            _maDangKiCaLamRepositoryMock.Verify(x => x.Add(It.IsAny<MaDangKiCaLamEntity>()), Times.Once);
            _maDangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public async Task MaDangKiCaLam_CreateDuplicateEntity_ThrowsException()
        {
            //Arrange
            var expected = "Loại Đăng Kí trên đã tồn tại!";
            var data = new MaDangKiCaLamEntity
            {
                Name = "Test",
                ThoiGianCaLamBatDau = DateTime.Now,
                ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1),
            };

            var command = new CreateMaDangKiCaLamCommand(data.Name, data.ThoiGianCaLamBatDau, data.ThoiGianCaLamKetThuc);
            _maDangKiCaLamRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            //Assert
            Assert.AreEqual(expected, result);
            _maDangKiCaLamRepositoryMock.Verify(x => x.Add(It.IsAny<MaDangKiCaLamEntity>()), Times.Never);
            _maDangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
