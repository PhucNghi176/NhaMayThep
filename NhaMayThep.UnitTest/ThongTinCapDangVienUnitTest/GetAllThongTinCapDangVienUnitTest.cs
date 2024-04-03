using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinCapDangVien.GetAll;
using NhaMayThep.Application.ThongTinCapDangVien;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinCapDangVienUnitTest
{
    [TestFixture]
    public class GetAllThongTinCapDangVienUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IThongTinCapDangVienRepository> _thongTinCapDangVienRepositoryMock;
        private GetAllThongTinCapDangVienQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _thongTinCapDangVienRepositoryMock = new Mock<IThongTinCapDangVienRepository>();
            _handlerMock = new GetAllThongTinCapDangVienQueryHandler(_thongTinCapDangVienRepositoryMock.Object, _mapperMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsThongTinCapDangVienDto()
        {
            // Arrange
            var query = new GetAllThongTinCapDangVienQuery();
            var expectedResult = new List<ThongTinCapDangVienEntity>
            {
                new ThongTinCapDangVienEntity
                {
                    Name = "Tên Cấp Đảng Viên"
                }
            };

            var expectedDto = expectedResult.Select(entity => new ThongTinCapDangVienDto
            {
                Name = entity.Name
            }).ToList();


            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<ThongTinCapDangVienDto>(It.IsAny<ThongTinCapDangVienEntity>()))
                .Returns<ThongTinCapDangVienEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
