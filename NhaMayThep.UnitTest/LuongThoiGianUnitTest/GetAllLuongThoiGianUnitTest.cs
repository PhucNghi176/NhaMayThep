using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.LuongThoiGian.GetAll;
using NhaMayThep.Application.LuongThoiGian;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.LuongThoiGianUnitTest
{
    [TestFixture]
    public class GetAllLuongThoiGianUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ILuongThoiGianRepository> _luongThoiGianRepositoryMock;
        private GetAllLuongThoiGianQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _luongThoiGianRepositoryMock = new Mock<ILuongThoiGianRepository>();
            _handlerMock = new GetAllLuongThoiGianQueryHandler(_mapperMock.Object, _luongThoiGianRepositoryMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsLuongThoiGianDto()
        {
            // Arrange
            var query = new GetAllLuongThoiGianQuery();
            var expectedResult = new List<LuongThoiGianEntity>
            {
                new LuongThoiGianEntity
                {
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
                }
            };

            var expectedDto = expectedResult.Select(entity => new LuongThoiGianDto
            {
                Id = entity.ID,
                MaSoNhanVien = entity.MaSoNhanVien,
                MaLuongThoiGian = entity.MaLuongThoiGian,
                LuongNam = entity.LuongNam,
                LuongThang = entity.LuongThang,
                LuongNgay = entity.LuongNgay,
                LuongTuan = entity.LuongTuan,
                LuongGio = entity.LuongGio,
                NgayApDung = entity.NgayApDung
            }).ToList();


            _luongThoiGianRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<LuongThoiGianDto>(It.IsAny<LuongThoiGianEntity>()))
                .Returns<LuongThoiGianEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
