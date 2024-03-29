using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinChucVu.UpdateChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class UpdateThongTinChucVuUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateChucVuCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
            _handlerMock = new UpdateChucVuCommandHandler(_chucVuRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1, "test")]
        public async Task ThongTinChucVu_UpdateValidEntity_ReturnTrue(int id, string name)
        {
            var expectedResult = "Cập nhật thành công";
            var data = new ThongTinChucVuEntity
            {
                ID = 1,
                Name = "testmock"
            };
            var command = new UpdateChucVuCommand(id, name);
            
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _chucVuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(1, "test")]
        public async Task ThongTinChucVu_UpdateValidEntity_ReturnFalse(int id, string name)
        {
            var expectedResult = "Cập nhật thất bại";
            var data = new ThongTinChucVuEntity
            {
                ID = 1,
                Name = "testmock"
            };
            var command = new UpdateChucVuCommand(id, name);

            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _chucVuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(2, "testMock")]
        public async Task ThongTinChucVu_UpdateInValidEntity_ThrowsDuplicateException(int id, string name)
        {
            var expectedResult = "Cập nhật thất bại";
            
            var command = new UpdateChucVuCommand(id, name);

            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [TestCase(3, "test")]
        public async Task ThongTinChucVu_UpdateInValidEntity_ThrowsNotFoundException(int id, string name)
        {
            var expectedResult = "Cập nhật thất bại";
            var data = new ThongTinChucVuEntity
            {
                ID = 1,
                Name = "testmock"
            };
            var command = new UpdateChucVuCommand(id, name);

            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinChucVuEntity) null );

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
