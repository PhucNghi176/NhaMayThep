using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMayThep.Domain.Repositories;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Delete;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChiTietNgayNghiPhep;

namespace NhaMayThep.Application.UnitTests.ChiTietNgayNghiPhep.Delete
{
    [TestFixture]
    public class DeleteChiTietNgayNghiPhepCommandHandlerTests
    {
        private Mock<IChiTietNgayNghiPhepRepository> _repoMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteChiTietNgayNghiPhepCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repoMock = new Mock<IChiTietNgayNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("userId");

            _mapperMock.Setup(m => m.Map<ChiTietNgayNghiPhepDto>(It.IsAny<ChiTietNgayNghiPhepEntity>()))
                .Returns(new ChiTietNgayNghiPhepDto
                {
                    MaSoNhanVien = "NV123",
                    LoaiNghiPhepID = 1,
                    TongSoGio = 100,
                    SoGioDaNghiPhep = 50,
                    SoGioConLai = 50,
                    NamHieuLuc = 2023
                });

            _handler = new DeleteChiTietNgayNghiPhepCommandHandler(_repoMock.Object, _mapperMock.Object, _currentUserServiceMock.Object);
        }
        [Test]
        public async Task Handle_EntityExists_ShouldMarkAsDeleted()
        {
            // Arrange
            var command = new DeleteChiTietNgayNghiPhepCommand("validId");
            var chiTietNgayNghiPhep = new ChiTietNgayNghiPhepEntity
            {
                ID = command.Id,
                TongSoGio = 100,
                SoGioDaNghiPhep = 50,
                SoGioConLai = 50,
                NamHieuLuc = 2023,
                NgayXoa = null
            };

            _repoMock.Setup(r => r.FindAsync(
                It.IsAny<Expression<Func<ChiTietNgayNghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(chiTietNgayNghiPhep);

            _repoMock.Setup(r => r.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                     .ReturnsAsync(1); // Correctly returns a Task<int>

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(chiTietNgayNghiPhep.NgayXoa, Is.Not.Null, "NgayXoa should be set to the current date/time.");
            _repoMock.Verify(r => r.Update(It.Is<ChiTietNgayNghiPhepEntity>(e => e.ID == command.Id)), Times.Once, "Entity should be updated exactly once.");
            _repoMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once, "Changes should be saved exactly once.");
        }

    }
}
