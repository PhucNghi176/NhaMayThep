using Moq;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.DeleteTrangThaiDangKiCaLamViec;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using System.Linq.Expressions;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.UnitTest.ThongTinLuongNhanVien
{
    public class DeleteThongTinLuongNhanVienUnitTest
    {
        private Mock<IThongTinLuongNhanVienRepository> _thongTinLuongNhanVienMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienMock;
        private Mock<IHopDongRepository> _hopDongMock;
        private DeleteThongTinLuongNhanVienCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _thongTinLuongNhanVienMock = new Mock<IThongTinLuongNhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienMock = new Mock<INhanVienRepository>();
            _hopDongMock = new Mock<IHopDongRepository>();

            _handlerMock = new DeleteThongTinLuongNhanVienCommandHandler(_thongTinLuongNhanVienMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase("Test")]
        public async Task Handle_EntityValid_ReturnTrue(string id)
        {
            // Arrange
            var expected = "Xóa Thành Công";

            var existingData = new ThongTinLuongNhanVienEntity
            {
                ID = id, //Assume id = Test is valid
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now,
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(user => user.UserId).Returns("SomeUserId");
            var command = new DeleteThongTinLuongNhanVienCommand(id); // Assume id = Test is valid
            _thongTinLuongNhanVienMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            _thongTinLuongNhanVienMock.Setup(repo => repo.Update(It.IsAny<ThongTinLuongNhanVienEntity>()));
            _thongTinLuongNhanVienMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
            _thongTinLuongNhanVienMock.Verify(repo => repo.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Once);
            _thongTinLuongNhanVienMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.That(existingData.NguoiXoaID, Is.EqualTo("SomeUserId")); // Ensuring correct user ID set
            Assert.NotNull(existingData.NgayXoa);
        }

        [TestCase("Test")]
        public async Task Handle_EntityNotFound_ReturnFalse(string id)
        {
            //Arrage
            var expected = "Thông Tin Không Tìm Thấy Hoặc Đã Bị Xóa";
            var command = new DeleteThongTinLuongNhanVienCommand(id); // Assume id = 2 is invalid
            _thongTinLuongNhanVienMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinLuongNhanVienEntity)null);

            //Act and Assert
            var result = Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            Assert.That(expected, Is.EqualTo(result.Message));
            _thongTinLuongNhanVienMock.Verify(repo => repo.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Never);
            _thongTinLuongNhanVienMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [TestCase("Test")]
        public async Task Handle_EntityAlreadyDeleted_ReturnFalse(string id)
        {
            // Arrange
            var expected = "Thông Tin Không Tìm Thấy Hoặc Đã Bị Xóa";

            var existingData = new ThongTinLuongNhanVienEntity
            {
                ID = id, //Assume id = Test is already deleted
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now,
                NgayXoa = DateTime.Now
            };

            var command = new DeleteThongTinLuongNhanVienCommand(id); // Assume id = 2 is deleted
            _thongTinLuongNhanVienMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            // Act and Assert
            var result = Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            Assert.That(expected, Is.EqualTo(result.Message));
            _thongTinLuongNhanVienMock.Verify(repo => repo.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Never);
            _thongTinLuongNhanVienMock.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
