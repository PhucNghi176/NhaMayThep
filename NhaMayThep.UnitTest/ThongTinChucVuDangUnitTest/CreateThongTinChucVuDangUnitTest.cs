using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVuDang.CreateThongTinChucVuDang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuDangUnitTest
{
    [TestFixture]
    public class CreateThongTinChucVuDangUnitTest
    {
        private Mock<IThongTinChucVuDangRepository> _thongTinChucVuDangRepositoryMock;
        private CreateThongTinChucVuDangCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _thongTinChucVuDangRepositoryMock = new Mock<IThongTinChucVuDangRepository>();
            _handlerMock = new CreateThongTinChucVuDangCommandHandler(_thongTinChucVuDangRepositoryMock.Object);
        }

        [Test]
        public async Task ThongTinChucVuDang_CreateValidEntity_ReturnTrue()
        {
            var expectedResult = "Tạo thành công";

            var data = new ThongTinChucVuDangEntity
            {
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new CreateThongTinChucVuDangCommand(data.Name);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinChucVuDang_CreateValidEntity_ReturnFalse()
        {
            var expectedResult = "Tạo thất bại";

            var data = new ThongTinChucVuDangEntity
            {
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new CreateThongTinChucVuDangCommand(data.Name);

            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinChucVuDang_CreateDuplicatedEntity_ThrowsDuplicatedException()
        {
            var data = new ThongTinChucVuDangEntity
            {
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new CreateThongTinChucVuDangCommand(data.Name);

            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

    }
}
