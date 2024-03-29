using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinChucVu.DeleteChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NhaMayThep.UnitTest.ThongTinChucVuUnitTest
{
    [TestFixture]
    public class DeleteThongTinChucVuUnitTest
    {
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private DeleteChucVuCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _chucVuRepositoryMock = new Mock<IChucVuRepository> ();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
            _handlerMock = new DeleteChucVuCommandHandler(_chucVuRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase(1)] 
        public async Task ThongTinChucVu_DeleteValidId_ReturnTrue(int id)
        {
            var expectedResult = "Xóa thành công";
            var data = new ThongTinChucVuEntity
            {
                ID = 1,
                Name = "test"
            };

            var command = new DeleteChucVuCommand(id);

            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _chucVuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }
        
        [TestCase(2)] 
        public async Task ThongTinChucVu_DeleteValidId_ReturnFalse(int id)
        {
            var expectedResult = "Xóa thất bại";
            var data = new ThongTinChucVuEntity
            {
                ID = 2,
                Name = "test"
            };

            var command = new DeleteChucVuCommand(id);

            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _chucVuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(3)]
        public async Task ThongTinChucVu_DeleteInvalidId_ThrowsException(int id)
        {
            var command = new DeleteChucVuCommand(id);

            _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinChucVuEntity)null);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
