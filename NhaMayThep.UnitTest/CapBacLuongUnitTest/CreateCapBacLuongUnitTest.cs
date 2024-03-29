using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.CapBacLuong.CreateCapBacLuong;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.CapBacLuongUnitTest
{
    public class CreateCapBacLuongUnitTest
    {
        private Mock<ICapBacLuongRepository> _capBacLuongRepositoryMock;
        private Mock<ICurrentUserService> _currrentUserServiceMock;
        private CreateCapBacLuongCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _capBacLuongRepositoryMock = new Mock<ICapBacLuongRepository>();
            _currrentUserServiceMock = new Mock<ICurrentUserService>();

            _currrentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
            _handlerMock = new CreateCapBacLuongCommandHandler(_capBacLuongRepositoryMock.Object, _currrentUserServiceMock.Object);
        }

        [Test]
        public async Task CapBacLuong_CreateValidEntity_ReturnTrue()
        {
            var expectedResult = "Tạo thành công";

            var data = new CapBacLuongEntity
            {
                HeSoLuong = 1.5F,
                Name = "testcase",
                TrinhDo = "CuNhan"
            };

            var command = new CreateCapBacLuongCommand(data.Name, data.HeSoLuong, data.TrinhDo);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CapBacLuong_CreateValidEntity_ReturnFalse()
        {
            var expectedResult = "Tạo thất bại";
            var data = new CapBacLuongEntity
            {
                HeSoLuong = 1.5F,
                Name = "testcase",
                TrinhDo = "CuNhan"
            };

            var command = new CreateCapBacLuongCommand(data.Name, data.HeSoLuong, data.TrinhDo);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _capBacLuongRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CapBacLuong_CreateDuplicateEntity_ThrowsException()
        {
            var data = new CapBacLuongEntity
            {
                Name = "test",
                HeSoLuong = 2.5F,
                TrinhDo = "CuNhan"
            };

            var command = new CreateCapBacLuongCommand(data.Name, data.HeSoLuong, data.TrinhDo);
            _capBacLuongRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<CapBacLuongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

    }
}
