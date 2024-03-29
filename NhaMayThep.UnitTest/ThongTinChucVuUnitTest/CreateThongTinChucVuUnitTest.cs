using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ThongTinChucVu.CreateNewChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class CreateThongTinChucVuUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private CreateNewChucVuCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository>();
            _handlerMock = new CreateNewChucVuCommandHandler(_chucVuRepositoryMock.Object);
        }

        [TestCase("test")]
        public async Task ThongTinChucVu_CreateWithValidName_ReturnTrue(string name)
        {
            var expectedResult = "Tạo thành công";
            var command = new CreateNewChucVuCommand(name);

            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _chucVuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("testDuplication")]
        public async Task ThongTinChucVu_CreateWithInvalidName_ThrowsException(string name)
        {
            var command = new CreateNewChucVuCommand(name);

            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
