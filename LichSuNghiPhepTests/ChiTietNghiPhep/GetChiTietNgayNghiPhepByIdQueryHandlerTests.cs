using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChiTietNgayNghiPhep.GetById;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;
using System.Threading;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Delete;
using NhaMayThep.Application.ChiTietNgayNghiPhep;

namespace NhaMayThep.UnitTests.ChiTietNgayNghiPhep.GetById
{
    [TestFixture]
    public class GetChiTietNgayNghiPhepByIdQueryHandlerTests
    {
        private Mock<IChiTietNgayNghiPhepRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetChiTietNgayNghiPhepByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IChiTietNgayNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetChiTietNgayNghiPhepByIdQueryHandler(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidId_ShouldReturnEntity()
        {
            // Arrange
            var validId = "validId";
            var query = new GetChiTietNgayNghiPhepByIdQuery(validId);
            var entity = new ChiTietNgayNghiPhepEntity
            {
                ID = "validId",
                MaSoNhanVien = "NV123456",
                LoaiNghiPhepID = 1, // Assuming 1 corresponds to a valid leave type in your context
                TongSoGio = 120, // Assuming total allocated leave hours
                SoGioDaNghiPhep = 40, // Assuming 40 hours have been taken
                SoGioConLai = 80, // Calculated remaining hours
                NamHieuLuc = 2023
            };

            var expectedDto = new ChiTietNgayNghiPhepDto
            {
                Id = validId,
                MaSoNhanVien = "NV123456",
                LoaiNghiPhepID = 1, // Assuming 1 corresponds to a specific type of leave in your system
                TongSoGio = 120, // Assuming this is the total allocated leave hours
                SoGioDaNghiPhep = 40, // Assuming this is how many hours have already been used
                SoGioConLai = 80, // Assuming this is the remaining leave hours
                NamHieuLuc = 2023
            };

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(entity);
            _mapperMock.Setup(m => m.Map<ChiTietNgayNghiPhepDto>(It.IsAny<ChiTietNgayNghiPhepEntity>()))
            .Returns(expectedDto);
            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            _repositoryMock.Verify(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Test]
        public void Handle_NotFound_ShouldThrowNotFoundException()
        {
            // Arrange
            var invalidId = "invalidId";
            var query = new GetChiTietNgayNghiPhepByIdQuery(invalidId);

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ChiTietNgayNghiPhepEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }







    }
}

