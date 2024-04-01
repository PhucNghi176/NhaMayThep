using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.NghiPhep;
using NhaMayThep.Application.NghiPhep.GetAll;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.NghiPhepTests
{
    [TestFixture]
    public class GetAllQueryHandlerTests
    {
        private GetAllQueryHandler _handler;
        private Mock<IMapper> _mapperMock;
        private Mock<INghiPhepRepository> _nghiPhepRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _nghiPhepRepositoryMock = new Mock<INghiPhepRepository>();
            _handler = new GetAllQueryHandler(_mapperMock.Object, _nghiPhepRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfNghiPhepDto()
        {
            // Arrange
            var nghiPhepEntities = new List<NghiPhepEntity>
            {
                new NghiPhepEntity { ID = "ExampleNghiPhepId1", NgayXoa = null, LoaiNghiPhepID = 1, MaSoNhanVien = "ExampleMaSoNhanVien1" },
                new NghiPhepEntity { ID = "ExampleNghiPhepId2", NgayXoa = null, LoaiNghiPhepID = 2, MaSoNhanVien = "ExampleMaSoNhanVien2" }
            };

            _nghiPhepRepositoryMock.Setup(x => x.FindAllAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(nghiPhepEntities);

            _mapperMock.Setup(m => m.Map<List<NghiPhepDto>>(
                It.IsAny<List<NghiPhepEntity>>()))
                .Returns(new List<NghiPhepDto>
                {
                    new NghiPhepDto { ID = "ExampleNghiPhepId1", MaSoNhanVien = "ExampleMaSoNhanVien1" },
                    new NghiPhepDto { ID = "ExampleNghiPhepId2", MaSoNhanVien = "ExampleMaSoNhanVien2" }
                });

            var query = new GetAllQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);

            if (result[0] != null)
            {
                Assert.AreEqual("ExampleMaSoNhanVien1", result[0].MaSoNhanVien);
            }
        }

        [Test]
        public void Handle_WithNoNghiPhep_ThrowsNotFoundException()
        {
            // Arrange
            _nghiPhepRepositoryMock.Setup(x => x.FindAllAsync(
                It.IsAny<Expression<Func<NghiPhepEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<NghiPhepEntity>());

            var query = new GetAllQuery();

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.AreEqual("Không có Nghỉ Phép nào!", ex.Message);
        }
    }
}
