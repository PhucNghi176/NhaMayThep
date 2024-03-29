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
using System.Linq.Expressions;

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


        [Test]
        public async Task GetByIdQueryHandler_ValidId_ReturnsLichSuNghiPhepDto()
        {
            // Arrange
            var query = new GetByIdQuery("validId");
            var expectedLsnp = new LichSuNghiPhepNhanVienEntity
            {
                ID = "validId",
                MaSoNhanVien = "validMaSoNhanVien",
                LoaiNghiPhepID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(1),
                LyDo = "Test reason",
                NguoiDuyet = "validNguoiDuyetId"
            };
            var expectedDto = new LichSuNghiPhepDto();

            _lichSuNghiPhepRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedLsnp);

            _mapperMock.Setup(m => m.Map<LichSuNghiPhepDto>(expectedLsnp)).Returns(expectedDto);

            var handler = new GetByIdQueryHandler(_lichSuNghiPhepRepositoryMock.Object, _mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }


     


    }
}
