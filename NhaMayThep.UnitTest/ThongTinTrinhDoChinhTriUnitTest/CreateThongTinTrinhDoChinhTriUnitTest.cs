using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinTrinhDoChinhTri.CreateThongTinTrinhDoChinhTri;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinTrinhDoChinhTriUnitTest
{
    [TestFixture]
    public class CreateThongTinTrinhDoChinhTriUnitTest
    {
        private Mock<IThongTinTrinhDoChinhTriRepository> _thongTinTrinhDoChinhTriRepositoryMock;
        private CreateThongTinTrinhDoChinhTriCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _thongTinTrinhDoChinhTriRepositoryMock = new Mock<IThongTinTrinhDoChinhTriRepository>();
            _handlerMock = new CreateThongTinTrinhDoChinhTriCommandHandler(_thongTinTrinhDoChinhTriRepositoryMock.Object);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_CreateValidEntity_ReturnTrue()
        {
            var expectedResult = "Tạo thành công";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new CreateThongTinTrinhDoChinhTriCommand(data.Name);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_CreateValidEntity_ReturnFalse()
        {
            var expectedResult = "Tạo thất bại";

            var data = new ThongTinTrinhDoChinhTriEntity
            {
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new CreateThongTinTrinhDoChinhTriCommand(data.Name);

            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var result = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public async Task ThongTinTrinhDoChinhTri_CreateDuplicatedEntity_ThrowsDuplicatedException()
        {
            var data = new ThongTinTrinhDoChinhTriEntity
            {
                Name = "Tên Trình Độ Chính Trị"
            };

            var command = new CreateThongTinTrinhDoChinhTriCommand(data.Name);

            _thongTinTrinhDoChinhTriRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinTrinhDoChinhTriEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

    }
}
