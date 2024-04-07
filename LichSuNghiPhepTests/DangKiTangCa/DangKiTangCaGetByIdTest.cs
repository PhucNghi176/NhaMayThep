using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.DangKiTangCa.Queries.GetDangKiTangCaById;
using NhaMayThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.DangKiTangCa;
using NhaMayThep.Application.DangKiTangCa.GetId;

namespace NhaMayThep.UnitTest.DangKiTangCa
{
    [TestFixture]
    public class DangKiTangCaGetByIdTest
    {
        private Mock<IDangKiTangCaRepository> _dangKiTangCaRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private GetDangKiTangCaByIdQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _dangKiTangCaRepositoryMock = new Mock<IDangKiTangCaRepository>();
            _mapperMock = new Mock<IMapper>();
            _handler = new GetDangKiTangCaByIdQueryHandler(_dangKiTangCaRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_GivenValidId_ReturnsDangKiTangCaDto()
        {
            // Arrange
            var validId = "validId";
            var query = new GetDangKiTangCaByIdQuery { Id = validId };
            var expectedEntity = new DangKiTangCaEntity
            {
                ID = validId,
                MaSoNhanVien = "validMaSoNhanVien",
                NgayLamTangCa = new DateTime(2023, 1, 1),
                CaDangKi = 1, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 18, 0, 0), // 6 PM start for overtime
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 22, 0, 0), // 10 PM end for overtime
                LiDoTangCa = "Extra project work",
                SoGioTangCa = new TimeSpan(4, 0, 0), // 4 hours of overtime
                HeSoLuongTangCa = 1.5M, // Assuming 1.5 times the regular pay
                NguoiDuyet = "validNguoiDuyetId"

            };
            var expectedDto = new DangKiTangCaDto
            {
                Id = validId,
                MaSoNhanVien = "validMaSoNhanVien",
                NgayLamTangCa = new DateTime(2023, 1, 1),
                CaDangKi = 1, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 18, 0, 0), // 6 PM start for overtime
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 22, 0, 0), // 10 PM end for overtime
                LiDoTangCa = "Extra project work",
                SoGioTangCa = new TimeSpan(4, 0, 0), // 4 hours of overtime
                HeSoLuongTangCa = 1.5M, // Assuming 1.5 times the regular pay
                NguoiDuyet = "validNguoiDuyetId"
            };

            _dangKiTangCaRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<DangKiTangCaEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedEntity);

            _mapperMock.Setup(mapper => mapper.Map<DangKiTangCaDto>(expectedEntity))
                .Returns(expectedDto);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
            _mapperMock.Verify(mapper => mapper.Map<DangKiTangCaDto>(expectedEntity), Times.Once);
        }

        [Test]
        public void Handle_GivenInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var invalidId = "invalidId";
            var query = new GetDangKiTangCaByIdQuery { Id = invalidId };

            _dangKiTangCaRepositoryMock.Setup(repo => repo.FindAsync(It.IsAny<System.Linq.Expressions.Expression<System.Func<DangKiTangCaEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((DangKiTangCaEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
