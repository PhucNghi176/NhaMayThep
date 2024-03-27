
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
using NhaMayThep.Application.CapBacLuong.GetAll;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.CapBacLuong;

namespace NhaMayThep.UnitTest.CapBacLuongUnitTest
{
    [TestFixture]
    public class LichSuNghiPhepTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ICapBacLuongRepository> _capBacLuongRepositoryMock;
        private GetAllCapBacLuongQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _capBacLuongRepositoryMock = new Mock<ICapBacLuongRepository>();
            _handlerMock = new GetAllCapBacLuongQueryHandler(_capBacLuongRepositoryMock.Object, _mapperMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsCapBacLuongDto()
        {
            // Arrange
            var query = new GetAllCapBacLuongQuery();
            var expectedLsnp = new List<CapBacLuongEntity>
            {
                new CapBacLuongEntity
                {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
                }
            };

            var expectedDto = expectedLsnp.Select(entity => new CapBacLuongDto
            {
                Id = entity.ID,
                HeSoLuong = entity.HeSoLuong,
                TrinhDo = entity.TrinhDo,
                Name = entity.Name
            }).ToList();


            _capBacLuongRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedLsnp);

            _mapperMock.Setup(m => m.Map<CapBacLuongDto>(It.IsAny<CapBacLuongEntity>()))
                .Returns<CapBacLuongEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}