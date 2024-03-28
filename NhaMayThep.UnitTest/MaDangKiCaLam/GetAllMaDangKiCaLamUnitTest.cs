using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.MaDangKiCaLamViec;
using NhaMayThep.Application.MaDangKiCaLamViec.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.MaDangKiCaLam
{
    [TestFixture]
    public class GetAllMaDangKiCaLamUnitTest
    {
        private Mock<IMaDangKiCaLamRepository> _maDangKiCaLamRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetAllMaDangKiCaLamHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _maDangKiCaLamRepositoryMock = new Mock<IMaDangKiCaLamRepository>();
            _mapperMock = new Mock<IMapper>();
            _handlerMock = new GetAllMaDangKiCaLamHandler(_maDangKiCaLamRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task MaDangKiCaLam_ValidRequest_ReturnDtoList()
        {
            // Arrange

            var expectedMaDangKiList = new List<MaDangKiCaLamEntity>
            {
                new MaDangKiCaLamEntity { ID = 1, Name = "Test1", ThoiGianCaLamBatDau = DateTime.Now, ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1)},
                new MaDangKiCaLamEntity { ID = 2, Name = "Test2", ThoiGianCaLamBatDau = DateTime.Now, ThoiGianCaLamKetThuc = DateTime.Now.AddDays(1)},
            };
            var expectedDtoList = expectedMaDangKiList
                .Select(x => new MaDangKiCaLamViecDTO { Id = x.ID, Name = x.Name, ThoiGianCaLamBatDau = x.ThoiGianCaLamBatDau, ThoiGianCaLamKetThuc = x.ThoiGianCaLamKetThuc })
                .ToList();

            _maDangKiCaLamRepositoryMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(expectedMaDangKiList);

            _mapperMock.Setup(mapper => mapper.Map<List<MaDangKiCaLamViecDTO>>(expectedMaDangKiList))
                .Returns(expectedDtoList);

            // Act
            var request = new GetAllMaDangKiCaLamQuery();
            var result = await _handlerMock.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            _maDangKiCaLamRepositoryMock.Verify(repo => repo.FindAllAsync(It.IsAny<Expression<Func<MaDangKiCaLamEntity, bool>>>(), CancellationToken.None));
            Assert.That(result, Is.EqualTo(expectedDtoList));
        }
    }
}
