using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NhaMayThep.Application.TrinhDoHocVan.GetAll;
using NhaMayThep.Application.TrinhDoHocVan;
using System.Linq.Expressions;

namespace TestProject1.TrinhDoHocVanTests
{
    [TestFixture]
    public class GetAllTrinhDoHocVanQueryHandlerTests
    {
        private GetAllTrinhDoHocVanQueryHandler _handler;
        private Mock<IMapper> _mapperMock;
        private Mock<ITrinhDoHocVanRepository> _repositoryMock;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<ITrinhDoHocVanRepository>();
            _handler = new GetAllTrinhDoHocVanQueryHandler(_mapperMock.Object, _repositoryMock.Object);
        }

        [Test]
        public async Task Handle_ReturnsListOfTrinhDoHocVanDto()
        {
            // Arrange
            var trinhDoHocVanEntities = new List<TrinhDoHocVanEntity>
    {
        new TrinhDoHocVanEntity { ID = 1, Name = "Trinh Do 1", NgayXoa = null },
        new TrinhDoHocVanEntity { ID = 2, Name = "Trinh Do 2", NgayXoa = null }
    };

            _repositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(trinhDoHocVanEntities);

            _mapperMock.Setup(m => m.Map<List<TrinhDoHocVanDto>>(It.IsAny<List<TrinhDoHocVanEntity>>()))
                       .Returns(new List<TrinhDoHocVanDto>
                       {
                   new TrinhDoHocVanDto { Id = 1, tenTrinhDo = "Trinh Do 1" },
                   new TrinhDoHocVanDto { Id = 2, tenTrinhDo = "Trinh Do 2" }
                       });

            var query = new GetAllQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.GreaterOrEqual(result.Count, 1);

            if (result[0] != null)
            {
                Assert.AreEqual("Trinh Do 1", result[0].tenTrinhDo);
            }
        }



        [Test]
        public void Handle_WithNoTrinhDoHocVan_ThrowsNotFoundException()
        {
            // Arrange
            _repositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<TrinhDoHocVanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(new List<TrinhDoHocVanEntity>());

            var query = new GetAllQuery();

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(query, CancellationToken.None));
            Assert.AreEqual("Không có Trình Độ Học Vấn nào!", ex.Message);
        }
    }
}
