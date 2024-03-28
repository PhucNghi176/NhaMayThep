using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVu;
using NhaMayThep.Application.ThongTinChucVu.GetAllChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class GetAllThongTinChucVuUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetAllChucVuQueryHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository> ();
            _mapperMock = new Mock<IMapper>();

            _handlerMock = new GetAllChucVuQueryHandler(_chucVuRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task ThongTinChucVu_GetAllValidQuery_ReturnTrue()
        {
            var expectedData = new List<ThongTinChucVuEntity>
            {
                new() {
                    ID = 1,
                    Name = "Test1"
                },
                new() {
                    ID = 2,
                    Name = "Test2"
                }
            };

            var expectedResult = expectedData.Select(entity => new ChucVuDto
            {
                Id = entity.ID,
                Name = entity.Name
            }).ToList();


            _chucVuRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedData);

            _mapperMock.Setup(m => m.Map<ChucVuDto>(It.IsAny<ThongTinChucVuEntity>()))
                .Returns<ThongTinChucVuEntity>(entity => expectedResult.FirstOrDefault(dto => dto.Id == entity.ID));

            var actualResult = await _handlerMock.Handle(new GetAllChucVuQuery(), CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinChucVu_GetAll_ThrowsException()
        {
            var query = new GetAllChucVuQuery();

            _chucVuRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync((List<ThongTinChucVuEntity>)null);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(query, CancellationToken.None));
        }
    }
}
