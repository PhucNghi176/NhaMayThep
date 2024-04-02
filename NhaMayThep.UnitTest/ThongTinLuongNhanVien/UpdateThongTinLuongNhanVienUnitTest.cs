using Moq;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinLuongNhanVien.Update;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.UpdateTrangThaiDangKiCaLamViec;
using NhaMapThep.Domain.Entities;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinLuongNhanVien
{
    public class UpdateThongTinLuongNhanVienUnitTest
    {
        private Mock<IThongTinLuongNhanVienRepository> _thongTinLuongNhanVienMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienMock;
        private Mock<IHopDongRepository> _hopDongMock;
        private UpdateThongTinLuongNhanVienCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _thongTinLuongNhanVienMock = new Mock<IThongTinLuongNhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienMock = new Mock<INhanVienRepository>();
            _hopDongMock = new Mock<IHopDongRepository>();

            _handlerMock = new UpdateThongTinLuongNhanVienCommandHandler(_thongTinLuongNhanVienMock.Object, _nhanVienMock.Object, _hopDongMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase("Test")]
        public async Task Handle_EntityValid_ReturnTrue(string id)
        {
            var expectedResult = "Cập Nhật Thành Công";

            var existingData = new ThongTinLuongNhanVienEntity
            {
                ID = id, //Assume id is valid
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now,
                NgayXoa = null
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");

            _nhanVienMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);
            _hopDongMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<HopDongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);

            var command = new UpdateThongTinLuongNhanVienCommand(existingData.ID, existingData.MaSoNhanVien, existingData.MaSoHopDong, "GiamLuong", 200, 100, existingData.NgayHieuLuc);           
            _thongTinLuongNhanVienMock.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            _thongTinLuongNhanVienMock.Setup(repo => repo.Update(It.IsAny<ThongTinLuongNhanVienEntity>()));
            _thongTinLuongNhanVienMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            _thongTinLuongNhanVienMock.Verify(x => x.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Once);
            _thongTinLuongNhanVienMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            Assert.That(existingData.Loai, Is.EqualTo("GiamLuong"));
            Assert.That(existingData.LuongCu, Is.EqualTo(200));
            Assert.That(existingData.LuongMoi, Is.EqualTo(100));
            Assert.That(existingData.NguoiCapNhatID, Is.EqualTo("SomeUserId"));
            Assert.NotNull(existingData.NgayCapNhatCuoi);
        }

        [TestCase("Test")]
        public async Task Handle_EntityNotFound_ReturnFalse(string id)
        {
            // Arrange

            var command = new UpdateThongTinLuongNhanVienCommand(id, "Test", "Test", "GiamLuong", 200, 100, DateTime.Now); //Assume id is invalid
            _thongTinLuongNhanVienMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinLuongNhanVienEntity)null);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _thongTinLuongNhanVienMock.Verify(x => x.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Never);
            _thongTinLuongNhanVienMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }

        [TestCase("Test")]
        public async Task Handle_EntityAlreadyDeleted_ReturnFalse(string id)
        {
            // Arrange
            var existingData = new ThongTinLuongNhanVienEntity
            {
                ID = id, //Assume id is valid
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now,
                NgayXoa = DateTime.Now
            };

            var command = new UpdateThongTinLuongNhanVienCommand(id, "Test", "Test", "GiamLuong", 200, 100, DateTime.Now); //Assume id is invalid
            _thongTinLuongNhanVienMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingData);

            //Act and Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
            _thongTinLuongNhanVienMock.Verify(x => x.Update(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Never);
            _thongTinLuongNhanVienMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);

        }
    }
}
