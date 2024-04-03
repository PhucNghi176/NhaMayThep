using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.UpdateThongTinTrinhDoChinhTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinTrinhDoChinhTriUnitTest
{
    [TestFixture]
    public class UpdateThongTinTrinhDoChinhTriUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinTrinhDoChinhTriRepository> _thongTinTrinhDoChinhTriRepositoryMock;
        private UpdateThongTinTrinhDoChinhTriCommandHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinTrinhDoChinhTriRepositoryMock = new Mock<IThongTinTrinhDoChinhTriRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new UpdateThongTinTrinhDoChinhTriCommandHandler(_thongTinTrinhDoChinhTriRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_UpdateValid_ReturnTrue()
        {
            var expectedResult = "Cập nhật thành công";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                ID = 1,
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new UpdateThongTinTrinhDoChinhTriCommand(data.ID, data.Name);


            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_UpdateValid_ReturnFalse()
        {
            var expectedResult = "Cập nhật thất bại";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                ID = 1,
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new UpdateThongTinTrinhDoChinhTriCommand(data.ID, data.Name);


            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_UpdateInvalid_ThrowsDuplicatedException()
        {
            var data = new ThongTinTrinhDoChinhTriEntity
            {
                ID = 1,
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new UpdateThongTinTrinhDoChinhTriCommand(data.ID, data.Name);


            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_UpdateInvalid_ThrowsNotFoundException()
        {
            var data = new ThongTinTrinhDoChinhTriEntity
            {
                ID = 1,
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new UpdateThongTinTrinhDoChinhTriCommand(data.ID, data.Name);


            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinTrinhDoChinhTriEntity)null);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
