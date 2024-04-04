using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.PhuCapNhanVien.CreatePhuCapNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.PhuCapNhanVienUnitTest
{
    [TestFixture]
    public class CreatePhuCapNhanVienUnitTest
    {
        private Mock<IPhuCapNhanVienRepository> _PhuCapNhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserService;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private CreatePhuCapNhanVienCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _PhuCapNhanVienRepositoryMock = new Mock<IPhuCapNhanVienRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handlerMock = new CreatePhuCapNhanVienCommandHandler(_PhuCapNhanVienRepositoryMock.Object, _currentUserService.Object, _nhanVienRepositoryMock.Object);
        }

        [TestCase("test")]
        public async Task PhuCapNhanVien_CreateValid_ReturnTrue(string name)
        {
            var expectedResult = "Tạo thành công";
            var data = new PhuCapNhanVienEntity
            {
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new CreatePhuCapNhanVienCommand(
                data.MaSoNhanVien,
                data.PhuCap);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _PhuCapNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _PhuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("testDuplication")]
        public async Task PhuCapNhanVien_CreateWithDuplicatedMaSoNhanVien_ThrowsDuplicatedException(string name)
        {
            var data = new PhuCapNhanVienEntity
            {
                MaSoNhanVien = "1",// Assume that MaSoNhanVien existed in the database
                PhuCap = 100000
            };

            var command = new CreatePhuCapNhanVienCommand(
                data.MaSoNhanVien,
                data.PhuCap);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _PhuCapNhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhuCapNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _PhuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [TestCase("testNotFound")]
        public async Task PhuCapNhanVien_CreateWithInvalidMaSoNhanVien_ThrowsNotFoundException(string name)
        {
            var data = new PhuCapNhanVienEntity
            {
                MaSoNhanVien = "1",
                PhuCap = 100000
            };

            var command = new CreatePhuCapNhanVienCommand(
                data.MaSoNhanVien,
                data.PhuCap);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _PhuCapNhanVienRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
