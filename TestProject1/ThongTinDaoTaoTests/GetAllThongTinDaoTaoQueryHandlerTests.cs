using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinDaoTao;
using NhaMayThep.Application.ThongTinDaoTao.GetAll;
using NhaMayThep.Domain.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TestProject1.ThongTinDaoTaoTests
{
    [TestFixture]
    public class GetAllQueryHandlerTests
    {
        private GetAllQueryHandler _handler;
        private Mock<IThongTinDaoTaoRepository> _thongTinDaoTaoRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _thongTinDaoTaoRepositoryMock = new Mock<IThongTinDaoTaoRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new GetAllQueryHandler(_mapperMock.Object, _thongTinDaoTaoRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_NoThongTinDaoTao_ReturnsEmptyList()
        {
            // Arrange
            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<ThongTinDaoTaoEntity>());

            var query = new GetAllQuery();

            // Act
            var result =  _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task Handle_ThongTinDaoTaoExists_ReturnsThongTinDaoTaoDtos()
        {
            // Arrange
            var thongTinDaoTaoEntities = new List<ThongTinDaoTaoEntity>
        {
            new ThongTinDaoTaoEntity { ID = "1", TenTruong = "Truong A", ChuyenNganh = "CNTT", NamTotNghiep = new DateTime(2022, 1, 1) },
            new ThongTinDaoTaoEntity { ID = "2", TenTruong = "Truong B", ChuyenNganh = "Kinh Te", NamTotNghiep = new DateTime(2021, 1, 1) }
        };

            _thongTinDaoTaoRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinDaoTaoEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(thongTinDaoTaoEntities);

            var thongTinDaoTaoDtos = thongTinDaoTaoEntities.Select(x => new ThongTinDaoTaoDto
            {
                ID = x.ID,
                TenTruong = x.TenTruong,
                ChuyenNganh = x.ChuyenNganh,
                NamTotNghiep = x.NamTotNghiep
            }).ToList();

            _mapperMock.Setup(m => m.Map<List<ThongTinDaoTaoDto>>(It.IsAny<List<ThongTinDaoTaoEntity>>()))
                .Returns(thongTinDaoTaoDtos);

            var query = new GetAllQuery();

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<List<ThongTinDaoTaoDto>>(result);
            Assert.That(result.Count, Is.EqualTo(thongTinDaoTaoEntities.Count));
        }
    }
}
