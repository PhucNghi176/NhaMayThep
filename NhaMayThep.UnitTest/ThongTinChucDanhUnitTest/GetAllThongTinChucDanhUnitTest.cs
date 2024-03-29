using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucDanh.GetAllChucDanh;
using NhaMayThep.Application.ThongTinChucDanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinChucDanhUnitTest
{
    [TestFixture]
    public class GetAllThongTinChucDanhUnitTest
    {
        private Mock<IChucDanhRepository> _chucDanhRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetAllChucDanhQueryHandler _handlerMock;

        [SetUp] 
        public void Setup()
        {
            _chucDanhRepositoryMock = new Mock<IChucDanhRepository> ();
            _mapperMock = new Mock<IMapper> ();

            _handlerMock = new GetAllChucDanhQueryHandler(_chucDanhRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task ThongTinChucDanh_ValidQuery_ReturnTrue()
        {
            var query = new GetAllChucDanhQuery();

            var expectedData = new List<ThongTinChucDanhEntity>
            {
                new()
                {
                    ID = 1,
                    Name = "DataTest1"
                },
                new()
                {
                    ID = 2,
                    Name = "DataTest2"
                }
            };

            var expectedResult = expectedData.Select(entity => new ChucDanhDto()
            {
                Id = entity.ID,
                Name = entity.Name,
            }).ToList();


            _chucDanhRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedData);

            _mapperMock.Setup(m => m.Map<ChucDanhDto>(It.IsAny<ThongTinChucDanhEntity>()))
                .Returns<ThongTinChucDanhEntity>(entity => expectedResult.FirstOrDefault(dto => dto.Id == entity.ID));

            var actualResult = await _handlerMock.Handle(query, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
