using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiHoaDon.GetAll;
using NhaMayThep.Application.LoaiHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TestProject1.LoaiHoaDonTest
{
    public class GetAllLoaiHoaDonQueryHandlerTests
    {
        private Mock<ILoaiHoaDonRepository> _loaiHoaDonRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetAllLoaiHoaDonQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            _loaiHoaDonRepositoryMock = new Mock<ILoaiHoaDonRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetAllLoaiHoaDonQueryHandler(_loaiHoaDonRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsLoaiHoaDonDtoList()
        {
            // Arrange
            var expectedLoaiHoaDonList = new List<LoaiHoaDonEntity>
    {
        new LoaiHoaDonEntity { ID = 1, Name = "LoaiHoaDon1" },
        new LoaiHoaDonEntity { ID = 2, Name = "LoaiHoaDon2" },
    };
            var expectedDtoList = expectedLoaiHoaDonList
                .Select(loaiHoaDon => new LoaiHoaDonDto { Id = loaiHoaDon.ID, Name = loaiHoaDon.Name })
                .ToList();

            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(expectedLoaiHoaDonList);

            _mapperMock.Setup(mapper => mapper.Map<List<LoaiHoaDonDto>>(expectedLoaiHoaDonList))
                .Returns(expectedDtoList);

            var request = new GetAllLoaiHoaDonQuerry();

            // Giả định lưu thành công
            _loaiHoaDonRepositoryMock.Setup(repo => repo.Add(It.IsAny<LoaiHoaDonEntity>()))
                .Callback<LoaiHoaDonEntity>(entity =>
                {
                    // Kiểm tra xem phương thức Add đã được gọi với tham số là một đối tượng LoaiHoaDonEntity hay không
                    Assert.IsNotNull(entity);
                    // Thêm các kiểm tra khác nếu cần
                });
            _loaiHoaDonRepositoryMock.Setup(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1); // Giả định lưu thành công

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedDtoList, result);
        }



        [Test]
        public async Task Handle_EmptyList_ReturnsNotFoundException()
        {
            // Arrange
            _loaiHoaDonRepositoryMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((List<LoaiHoaDonEntity>)null);

            var request = new GetAllLoaiHoaDonQuerry();

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(request, CancellationToken.None));
            Assert.AreEqual("Danh Sách Rỗng", ex.Message);
        }
    }

}
