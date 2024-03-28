using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.LichSuNghiPhep.Create;
using NhaMayThep.Application.LichSuNghiPhep.GetByID;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.LichSuNghiPhep;

namespace NhaMayThep.UnitTest
{
    [TestFixture]
    public class LichSuNghiPhepTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ILichSuNghiPhepRepository> _lichSuNghiPhepRepositoryMock;
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _lichSuNghiPhepRepositoryMock = new Mock<ILichSuNghiPhepRepository>();
            _mediatorMock = new Mock<IMediator>();
        }

        #region GetByIdTests

        [Test]
        public async Task GetByIdQueryHandler_ValidId_ReturnsLichSuNghiPhepDto()
        {
            // Arrange
            var query = new GetByIdQuery("validId");
            var expectedLsnp = new LichSuNghiPhepNhanVienEntity { ID = "validId" };
            var expectedDto = new LichSuNghiPhepDto();

            _lichSuNghiPhepRepositoryMock.Setup(x => x.FindAsync(It.IsAny<System.Func<LichSuNghiPhepNhanVienEntity, bool>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedLsnp);

            _mapperMock.Setup(m => m.Map<LichSuNghiPhepDto>(expectedLsnp)).Returns(expectedDto);

            var handler = new GetByIdQueryHandler(_lichSuNghiPhepRepositoryMock.Object, _mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }

        [Test]
        public void GetByIdQueryHandler_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var query = new GetByIdQuery("invalidId");

            _lichSuNghiPhepRepositoryMock.Setup(x => x.FindAsync(It.IsAny<System.Func<LichSuNghiPhepNhanVienEntity, bool>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((LichSuNghiPhepNhanVienEntity)null);

            var handler = new GetByIdQueryHandler(_lichSuNghiPhepRepositoryMock.Object, _mapperMock.Object);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None));
        }

        #endregion

        // You can add more regions for Create, Update, Delete tests here

    }
}
