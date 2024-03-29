using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LichSuCongTacNhanVien.GetByMaSoNhanVien;
using NhaMayThep.Application.LichSuCongTacNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace TestProject1.LichSuCongTacNhanVienTest
{
    [TestFixture]
    public class GetByMaSoNhanVienQueryHandlerTests
    {
        private GetByMaSoNhanVienQueryHandler _handler;
        private Mock<ILichSuCongTacNhanVienRepository> _lichSuCongTacNhanVienRepositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _lichSuCongTacNhanVienRepositoryMock = new Mock<ILichSuCongTacNhanVienRepository>();
            _mapperMock = new Mock<IMapper>();

            _handler = new GetByMaSoNhanVienQueryHandler(
                _lichSuCongTacNhanVienRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsList()
        {
            // Arrange
            var query = new GetByMaSoNhanVienQuery { MaSoNhanVien = "123" };
            var lichSuCongTacNhanVienList = new List<LichSuCongTacNhanVienEntity>
            {
                    new LichSuCongTacNhanVienEntity
                {
                    MaSoNhanVien = "123", // Provide a valid maSoNhanVien here
                    LoaiCongTacID = 1,
                    NgayBatDau = DateTime.Now,
                    NgayKetThuc = DateTime.Now.AddDays(1),
                    NoiCongTac = "TestLocation",
                    LyDo = "TestReason"
                },
                new LichSuCongTacNhanVienEntity
                {
                    MaSoNhanVien = "123", // Provide a valid maSoNhanVien here
                    LoaiCongTacID = 1,
                    NgayBatDau = DateTime.Now,
                    NgayKetThuc = DateTime.Now.AddDays(1),
                    NoiCongTac = "TestLocation",
                    LyDo = "TestReason"
                }
        };
            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAllAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync(lichSuCongTacNhanVienList);

            _mapperMock.Setup(mapper => mapper.Map<List<LichSuCongTacNhanVienDto>>(lichSuCongTacNhanVienList))
                .Returns(new List<LichSuCongTacNhanVienDto>());

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); // Assuming two entities are returned
        }

        [Test]
        public void Handle_EmptyList_ThrowsNotFoundException()
        {
            // Arrange
            var query = new GetByMaSoNhanVienQuery { MaSoNhanVien = "123" };

            _lichSuCongTacNhanVienRepositoryMock.Setup(repo => repo.FindAllAsync(
                It.IsAny<Expression<Func<LichSuCongTacNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((List<LichSuCongTacNhanVienEntity>)null); // Simulate empty list

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
