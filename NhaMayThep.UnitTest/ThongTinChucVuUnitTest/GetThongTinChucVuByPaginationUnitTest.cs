using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVu;
using NhaMayThep.Application.ThongTinChucVu.GetPaginationChucVu;
using NhaMayThep.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class GetThongTinChucVuByPaginationUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IPagedResult<ThongTinChucVuEntity>> _pagedResultEntityMock;
        private GetChucVuByPaginationQueryHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository>();
            _pagedResultEntityMock = new Mock<IPagedResult<ThongTinChucVuEntity>>();
            _mapperMock = new Mock<IMapper>();
            _handlerMock = new GetChucVuByPaginationQueryHandler(_chucVuRepositoryMock.Object, _mapperMock.Object);
        }

        [TestCase(1, 2, 2)]
        public async Task ThongTinChucVu_GetByPaginationValidQuery_ReturnTrue(int pageNo, int pageSize, int totalCount)
        {
            var query = new GetChucVuByPaginationQuery(pageNo, pageSize);

            var data = new List<ThongTinChucVuEntity>
            {
                new ThongTinChucVuEntity
                {
                    ID = 1,
                    Name = "TestData1",
                },

                new ThongTinChucVuEntity
                {
                    ID = 2,
                    Name = "TestData2"
                }
            };

            var dataDto = data.Select(entity => new ChucVuDto
            {
                Id = entity.ID,
                Name = entity.Name,
            });

            var expectedResult = new PagedResult<ChucVuDto>
            {
                TotalCount = 2,
                PageSize = pageSize,
                PageNumber = pageNo,
                PageCount = 2,
                Data = dataDto.ToList()
            };

            _pagedResultEntityMock.Setup(x => x.TotalCount).Returns(totalCount);
            _pagedResultEntityMock.Setup(x => x.PageNo).Returns(pageNo);
            _pagedResultEntityMock.Setup(x => x.PageCount).Returns(pageSize);
            _pagedResultEntityMock.Setup(x => x.GetEnumerator()).Returns(data.GetEnumerator());

            _mapperMock.Setup(x => x.Map<ChucVuDto>(It.IsAny<ThongTinChucVuEntity>()))
                .Returns<ThongTinChucVuEntity>(entity => dataDto.FirstOrDefault(x => x.Id == entity.ID));

            _chucVuRepositoryMock.Setup(x => x.FindAllAsync(
                It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(),
                It.IsAny<int>(),
                It.IsAny<int>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(_pagedResultEntityMock.Object);

            var actualResult = await _handlerMock.Handle(query, CancellationToken.None);

            Assert.AreEqual(expectedResult.TotalCount, actualResult.TotalCount);
            Assert.AreEqual(expectedResult.PageNumber, actualResult.PageNumber);
            Assert.AreEqual(expectedResult.PageCount, actualResult.PageCount);
            Assert.AreEqual(expectedResult.Data.Count(), actualResult.Data.Count());
        }
    }
}
