using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.GetAll;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinTrinhDoChinhTriUnitTest
{
    [TestFixture]
    public class GetAllThongTinTrinhDoChinhTriUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IThongTinTrinhDoChinhTriRepository> _thongTinTrinhDoChinhTriRepositoryMock;
        private GetAllThongTinTrinhDoChinhTriQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _thongTinTrinhDoChinhTriRepositoryMock = new Mock<IThongTinTrinhDoChinhTriRepository>();
            _handlerMock = new GetAllThongTinTrinhDoChinhTriQueryHandler(_thongTinTrinhDoChinhTriRepositoryMock.Object, _mapperMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsThongTinTrinhDoChinhTriDto()
        {
            // Arrange
            var query = new GetAllThongTinTrinhDoChinhTriQuery();
            var expectedResult = new List<ThongTinTrinhDoChinhTriEntity>
            {
                new ThongTinTrinhDoChinhTriEntity
                {
                    Name = "Tên Trình Độ Chính Trị"
                }
            };

            var expectedDto = expectedResult.Select(entity => new ThongTinTrinhDoChinhTriDto
            {
                Name = entity.Name
            }).ToList();


            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<ThongTinTrinhDoChinhTriDto>(It.IsAny<ThongTinTrinhDoChinhTriEntity>()))
                .Returns<ThongTinTrinhDoChinhTriEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
