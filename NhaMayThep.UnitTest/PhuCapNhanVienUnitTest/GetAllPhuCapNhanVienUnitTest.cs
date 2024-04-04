using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.PhuCapNhanVien.GetAll;
using NhaMayThep.Application.PhuCapNhanVien;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.PhuCapNhanVienUnitTest
{
    [TestFixture]
    public class GetAllPhuCapNhanVienUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IPhuCapNhanVienRepository> _phuCapNhanVienRepositoryMock;
        private GetAllPhuCapNhanVienQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _phuCapNhanVienRepositoryMock = new Mock<IPhuCapNhanVienRepository>();
            _handlerMock = new GetAllPhuCapNhanVienQueryHandler(_mapperMock.Object, _phuCapNhanVienRepositoryMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsPhuCapNhanVienDto()
        {
            // Arrange
            var query = new GetAllPhuCapNhanVienQuery();
            var expectedResult = new List<PhuCapNhanVienEntity>
            {
                new PhuCapNhanVienEntity
                {
                    MaSoNhanVien = "1",
                    PhuCap = 100000
                }
            };

            var expectedDto = expectedResult.Select(entity => new PhuCapNhanVienDto
            {
                Id = entity.ID,
                MaSoNhanVien = entity.MaSoNhanVien,
                PhuCap = entity.PhuCap
            }).ToList();


            _phuCapNhanVienRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<PhuCapNhanVienDto>(It.IsAny<PhuCapNhanVienEntity>()))
                .Returns<PhuCapNhanVienEntity>(entity => expectedDto.FirstOrDefault(dto => dto.Id == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
