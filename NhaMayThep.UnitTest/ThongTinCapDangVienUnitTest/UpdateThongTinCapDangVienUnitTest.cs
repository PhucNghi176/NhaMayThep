using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCapDangVien.UpdateThongTinCapDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinCapDangVienUnitTest
{
    [TestFixture]
    public class UpdateThongTinCapDangVienUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinCapDangVienRepository> _thongTinCapDangVienRepositoryMock;
        private UpdateThongTinCapDangVienCommandHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinCapDangVienRepositoryMock = new Mock<IThongTinCapDangVienRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new UpdateThongTinCapDangVienCommandHandler(_thongTinCapDangVienRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task ThongTinCapDangVien_UpdateValid_ReturnTrue()
        {
            var expectedResult = "Cập nhật thành công";

            var data = new ThongTinCapDangVienEntity
            {
                ID = 1,
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new UpdateThongTinCapDangVienCommand(data.ID, data.Name);


            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinCapDangVien_UpdateValid_ReturnFalse()
        {
            var expectedResult = "Cập nhật thất bại";

            var data = new ThongTinCapDangVienEntity
            {
                ID = 1,
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new UpdateThongTinCapDangVienCommand(data.ID, data.Name);


            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinCapDangVien_UpdateInvalid_ThrowsDuplicatedException()
        {
            var data = new ThongTinCapDangVienEntity
            {
                ID = 1,
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new UpdateThongTinCapDangVienCommand(data.ID, data.Name);


            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task ThongTinCapDangVien_UpdateInvalid_ThrowsNotFoundException()
        {
            var data = new ThongTinCapDangVienEntity
            {
                ID = 1,
                Name = "Tên Cấp Đảng Viên"
            };

            var command = new UpdateThongTinCapDangVienCommand(data.ID, data.Name);


            _thongTinCapDangVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCapDangVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCapDangVienEntity)null);
            _thongTinCapDangVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
