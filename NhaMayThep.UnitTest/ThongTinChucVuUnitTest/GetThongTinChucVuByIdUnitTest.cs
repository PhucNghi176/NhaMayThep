using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVu;
using NhaMayThep.Application.ThongTinChucVu.GetChucVuById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class GetThongTinChucVuByIdUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetChucVuByIdQueryHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository>();
            _mapperMock = new Mock<IMapper>();
            _handlerMock = new GetChucVuByIdQueryHandler(_chucVuRepositoryMock.Object, _mapperMock.Object);
        }

        [TestCase(1)]
        public async Task ThongTinChucVu_GetByValidId_ReturnTrue(int id)
        {
            var query = new GetChucVuByIdQuery(id);
            var data = new ThongTinChucVuEntity
            {
                ID = 1,
                Name = "Test1"
            };

            var expectedResult = new ChucVuDto
            {
                Id = data.ID,
                Name = data.Name
            };

            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _mapperMock.Setup(x => x.Map<ChucVuDto>(It.IsAny<ThongTinChucVuEntity>()))
              .Returns(expectedResult);

            var actualResult = await _handlerMock.Handle(query, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2)]
        public async Task ThongTinChucVu_GetByInvalidId_ThrowsException(int id)
        {
            var query = new GetChucVuByIdQuery(id);
          
            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinChucVuEntity)null);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(query, CancellationToken.None));
        }
    }
}
