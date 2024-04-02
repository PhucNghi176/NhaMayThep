using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.MaDangKiCaLamViec.GetAll;
using NhaMayThep.Application.MaDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.CreateTrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec;
using System.Linq.Expressions;
using NhaMayThep.Application.BaoHiemNhanVien;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinCongTy;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.UnitTest.TrangThaiDangKiCaLamViec
{
    public class GetAllTrangThaiDangKiCaLamViecUnitTest
    {
        private Mock<ITrangThaiDangKiCaLamViecRepository> _trangThaiDangKiCaLamViecMock;
        private GetAllTrangThaiDangKiCaLamViecHandler _handlerMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _trangThaiDangKiCaLamViecMock = new Mock<ITrangThaiDangKiCaLamViecRepository>();
            _mapperMock = new Mock<IMapper>();

            _handlerMock = new GetAllTrangThaiDangKiCaLamViecHandler(_trangThaiDangKiCaLamViecMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnDtoList()
        {
            // Arrange

            var expectedTrangThaiList = new List<TrangThaiDangKiCaLamViecEntity>
            {
                new TrangThaiDangKiCaLamViecEntity {ID = 1, Name = "Tot"},
                new TrangThaiDangKiCaLamViecEntity {ID = 2, Name = "Ko Tot"}
            };

            var expectedTrangThaiDtoList = expectedTrangThaiList
                .Select(entity => new TrangThaiDangKiCaLamViecDTO { Id = entity.ID, Name = entity.Name })
                .ToList();


            _trangThaiDangKiCaLamViecMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), CancellationToken.None))
            .ReturnsAsync(expectedTrangThaiList);

            _mapperMock.Setup(m => m.Map<TrangThaiDangKiCaLamViecDTO>(It.IsAny<TrangThaiDangKiCaLamViecEntity>()))
                .Returns<TrangThaiDangKiCaLamViecEntity>(entity => expectedTrangThaiDtoList.FirstOrDefault(dto => dto.Id == entity.ID));


            // Act
            var request = new GetAllTrangThaiDangKiCaLamViecQuery();
            var result = await _handlerMock.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedTrangThaiDtoList, result);
        }

        [Test]
        public async Task Handle_EmptyList_ReturnsNotFoundException()
        {
            // Arrange
            _trangThaiDangKiCaLamViecMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<TrangThaiDangKiCaLamViecEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((List<TrangThaiDangKiCaLamViecEntity>)null);

            var request = new GetAllTrangThaiDangKiCaLamViecQuery();

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(request, CancellationToken.None));
            Assert.AreEqual("Danh Sách Trống", ex.Message);
        }
    }
}
