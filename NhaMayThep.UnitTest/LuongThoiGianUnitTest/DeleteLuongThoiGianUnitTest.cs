using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongThoiGian.DeleteLuongThoiGian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.LuongThoiGianUnitTest
{
    [TestFixture]
    public class DeleteLuongThoiGianUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ILuongThoiGianRepository> _luongThoiGianRepositoryMock;
        private DeleteLuongThoiGianCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _luongThoiGianRepositoryMock = new Mock<ILuongThoiGianRepository>();
            _handlerMock = new DeleteLuongThoiGianCommandHandler(_luongThoiGianRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase("1")]
        public async Task LuongThoiGian_DeleteLuongThoiGian_ReturnTrue(string id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new LuongThoiGianEntity
            {
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new DeleteLuongThoiGianCommand(id);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("1")]
        public async Task LuongThoiGian_DeleteLuongThoiGian_ReturnFalse(string id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new LuongThoiGianEntity
            {
                MaSoNhanVien = "1",
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new DeleteLuongThoiGianCommand(id);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("0")]
        public async Task LuongThoiGian_DeleteLuongThoiGian_NotFoundException(string id)
        {
            // Arrange
            var command = new DeleteLuongThoiGianCommand(id);
            _luongThoiGianRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((LuongThoiGianEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
