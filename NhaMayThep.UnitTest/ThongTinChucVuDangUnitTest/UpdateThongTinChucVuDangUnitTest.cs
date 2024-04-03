using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinChucVuDang.UpdateThongTinChucVuDang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuDangUnitTest
{
    [TestFixture]
    public class UpdateThongTinChucVuDangUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinChucVuDangRepository> _thongTinChucVuDangRepositoryMock;
        private UpdateThongTinChucVuDangCommandHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinChucVuDangRepositoryMock = new Mock<IThongTinChucVuDangRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new UpdateThongTinChucVuDangCommandHandler(_thongTinChucVuDangRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task ThongTinChucVuDang_UpdateValid_ReturnTrue()
        {
            var expectedResult = "Cập nhật thành công";

            var data = new ThongTinChucVuDangEntity
            {
                ID = 1,
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new UpdateThongTinChucVuDangCommand(data.ID, data.Name);


            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinChucVuDang_UpdateValid_ReturnFalse()
        {
            var expectedResult = "Cập nhật thất bại";

            var data = new ThongTinChucVuDangEntity
            {
                ID = 1,
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new UpdateThongTinChucVuDangCommand(data.ID, data.Name);


            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinChucVuDang_UpdateInvalid_ThrowsDuplicatedException()
        {
            var data = new ThongTinChucVuDangEntity
            {
                ID = 1,
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new UpdateThongTinChucVuDangCommand(data.ID, data.Name);


            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task ThongTinChucVuDang_UpdateInvalid_ThrowsNotFoundException()
        {
            var data = new ThongTinChucVuDangEntity
            {
                ID = 1,
                Name = "Tên Chức Vụ Đảng"
            };

            var command = new UpdateThongTinChucVuDangCommand(data.ID, data.Name);


            _thongTinChucVuDangRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuDangEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinChucVuDangEntity)null);
            _thongTinChucVuDangRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
