using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinCapDangVien.CreateThongTinCapDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinCapDangVienUnitTest
{
    [TestFixture]
    public class CreateThongTinCapDangVienUnitTest
    {
        private Mock<IThongTinCapDangVienRepository> _thongTinCapDangVienRepositoryMock;
        private CreateThongTinCapDangVienCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _thongTinCapDangVienRepositoryMock = new Mock<IThongTinCapDangVienRepository>();
            _handlerMock = new CreateThongTinCapDangVienCommandHandler(_thongTinCapDangVienRepositoryMock.Object);
        }

        [Test]
        public async Task ThongTinCapDangVien_CreateValidEntity_ReturnTrue()
        {
            var expectedResult = "Tạo thành công";

            var data = new ThongTinCapDangVienEntity
            {
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new CreateThongTinCapDangVienCommand(data.Name);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinCapDangVien_CreateValidEntity_ReturnFalse()
        {
            var expectedResult = "Tạo thất bại";

            var data = new ThongTinCapDangVienEntity
            {
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new CreateThongTinCapDangVienCommand(data.Name);

            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinCapDangVien_CreateDuplicatedEntity_ThrowsDuplicatedException()
        {
            var data = new ThongTinCapDangVienEntity
            {
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new CreateThongTinCapDangVienCommand(data.Name);

            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

    }
}
