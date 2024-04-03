using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVuDang.GetAll;
using NhaMayThep.Application.ThongTinChucVuDang;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinChucVuDangUnitTest
{
    [TestFixture]
    public class GetAllThongTinChucVuDangUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IThongTinChucVuDangRepository> _thongTinChucVuDangRepositoryMock;
        private GetAllThongTinChucVuDangQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _thongTinChucVuDangRepositoryMock = new Mock<IThongTinChucVuDangRepository>();
            _handlerMock = new GetAllThongTinChucVuDangQueryHandler(_thongTinChucVuDangRepositoryMock.Object, _mapperMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsThongTinChucVuDangDto()
        {
            // Arrange
            var query = new GetAllThongTinChucVuDangQuery();
            var expectedResult = new List<ThongTinChucVuDangEntity>
            {
                new ThongTinChucVuDangEntity
                {
                    Name = "Tên Chức Vụ Đảng"
                }
            };

            var expectedDto = expectedResult.Select(entity => new ThongTinChucVuDangDto
            {
                Name = entity.Name
            }).ToList();


            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<ThongTinChucVuDangDto>(It.IsAny<ThongTinChucVuDangEntity>()))
                .Returns<ThongTinChucVuDangEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
