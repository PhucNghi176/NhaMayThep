using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiNghiPhep.GetById;
using NhaMayThep.Application.LoaiNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.LoaiNghiPhep
{
    [TestFixture]
    public class LoaiNghiPhepGetByIdQueryHandlerTest
    {
        private Mock<ILoaiNghiPhepRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ILoaiNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
        }

        [Test]
        public async Task Handle_ValidId_ReturnsLoaiNghiPhepDto()
        {
            // Arrange
            var query = new GetLoaiNghiPhepByIdQuery(id: 1);
            var expectedEntity = new LoaiNghiPhepEntity
            {
                ID = 1,
                Name = "Annual Leave",
                
            };
            var expectedDto = new LoaiNghiPhepDto
            {
                ID = 1,
                Name = "Annual Leave",
            };

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(expectedEntity);

            _mapperMock.Setup(m => m.Map<LoaiNghiPhepDto>(expectedEntity)).Returns(expectedDto);

            var handler = new GetLoaiNghiPhepByIdQueryHandler(_repositoryMock.Object, _mapperMock.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }

        [Test]
        public void Handle_NonexistentId_ThrowsNotFoundException()
        {
            // Arrange
            var query = new GetLoaiNghiPhepByIdQuery(id: 999); // Assuming 999 is a nonexistent ID
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync((LoaiNghiPhepEntity)null); // No LoaiNghiPhep found

            var handler = new GetLoaiNghiPhepByIdQueryHandler(_repositoryMock.Object, _mapperMock.Object);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(query, CancellationToken.None), "LoaiNghiPhep Không tồn tại");
        }

       
    }
}
