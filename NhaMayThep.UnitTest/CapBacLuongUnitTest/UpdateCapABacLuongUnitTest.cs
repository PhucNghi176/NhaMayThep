using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.CapBacLuongUnitTest
{
    public class UpdateCapABacLuongUnitTest
    {
        private Mock<ICapBacLuongRepository> _capBacLuongRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateCapBacLuongCommandHandler _handlerMock;

        [SetUp]
        public void SetUp()
        {
            _capBacLuongRepositoryMock = new Mock<ICapBacLuongRepository>();   
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new UpdateCapBacLuongCommandHandler(_capBacLuongRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task CapBacLuong_UpdateValid_ReturnTrue()
        {
            var expectedResult = "Cập nhật thành công";

            var data = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };
            var command = new UpdateCapBacLuongCommand(data.ID, data.Name, data.HeSoLuong, data.TrinhDo);


            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CapBacLuong_UpdateValid_ReturnFalse()
        {
            var expectedResult = "Cập nhật thất bại";

            var data = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };
            var command = new UpdateCapBacLuongCommand(data.ID, data.Name, data.HeSoLuong, data.TrinhDo);


            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CapBacLuong_UpdateInvalid_ThrowsDuplicatedException()
        {
            var data = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };
            var command = new UpdateCapBacLuongCommand(data.ID, data.Name, data.HeSoLuong, data.TrinhDo);


            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task CapBacLuong_UpdateInvalid_ThrowsNotFoundException()
        {
            var data = new CapBacLuongEntity
            {
                ID = 1,
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan",
                Name = "test"
            };
            var command = new UpdateCapBacLuongCommand(data.ID, data.Name, data.HeSoLuong, data.TrinhDo);


            _capBacLuongRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((CapBacLuongEntity)null);
            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
