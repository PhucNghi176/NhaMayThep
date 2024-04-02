using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinLuongNhanVien
{
    public class CreateThongTinLuongNhanVienUnitTest
    {
        private Mock<IThongTinLuongNhanVienRepository> _thongTinLuongNhanVienMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienMock;
        private Mock<IHopDongRepository> _hopDongMock;
        private CreateThongTinLuongNhanVienCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _thongTinLuongNhanVienMock = new Mock<IThongTinLuongNhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienMock = new Mock<INhanVienRepository>();
            _hopDongMock = new Mock<IHopDongRepository>();

            _handlerMock = new CreateThongTinLuongNhanVienCommandHandler(_thongTinLuongNhanVienMock.Object, _nhanVienMock.Object, _hopDongMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_CreateValidEntity_ReturnTrue()
        {
            // Arrange
            var expectedResult = "Tạo Mới Thành Công";

            var data = new ThongTinLuongNhanVienEntity
            {
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");

            _nhanVienMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);
            _hopDongMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<HopDongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);

            var command = new CreateThongTinLuongNhanVienCommand(data.MaSoNhanVien, data.MaSoHopDong, data.Loai, data.LuongCu, data.LuongMoi, data.NgayHieuLuc);
            var thongTinLuongNhanViens = new List<ThongTinLuongNhanVienEntity>
                {
                    new ThongTinLuongNhanVienEntity {
                        MaSoNhanVien = "00485caa695d4942bc9d2de6498e9be2",
                        MaSoHopDong = "00485caa695d4942bc9d2de6498e9be2",
                        Loai = "TangLuong",
                        LuongCu = 100,
                        LuongMoi = 200,
                        NgayHieuLuc = DateTime.Now
                    },
                    // Add more entities as needed for your test
            };

            // Setting up the mock to return the list when FindAllAsync is called
            _thongTinLuongNhanVienMock.Setup(repo => repo.FindAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(thongTinLuongNhanViens);

            _thongTinLuongNhanVienMock.Setup(repo => repo.Add(It.IsAny<ThongTinLuongNhanVienEntity>()));
            _thongTinLuongNhanVienMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            _thongTinLuongNhanVienMock.Verify(x => x.Add(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Once);
            _thongTinLuongNhanVienMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);

            Assert.NotNull(data.NgayTao);
        }

        [Test]
        public async Task Handle_CreateDuplicateEntity_ThrowsException()
        {
            //Arrange
            var expected = "Mã Nhân Viên và Mã Hợp Đồng bị trùng lặp";
            var data = new ThongTinLuongNhanVienEntity
            {
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                Loai = "TangLuong",
                LuongCu = 100,
                LuongMoi = 200,
                NgayHieuLuc = DateTime.Now
            };

            _currentUserServiceMock.Setup(x => x.UserId).Returns("SomeUserId");

            _nhanVienMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);
            _hopDongMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<HopDongEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);

            var command = new CreateThongTinLuongNhanVienCommand(data.MaSoNhanVien, data.MaSoHopDong, data.Loai, data.LuongCu, data.LuongMoi, data.NgayHieuLuc);
            var thongTinLuongNhanViens = new List<ThongTinLuongNhanVienEntity>
                {
                    new ThongTinLuongNhanVienEntity {
                        MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                        MaSoHopDong = "cf59fedb4dd74fe483ccb1c15c23b72f",
                        Loai = "TangLuong",
                        LuongCu = 100,
                        LuongMoi = 200,
                        NgayHieuLuc = DateTime.Now
                    },
                    // Add more entities as needed for your test
            };

            // Setting up the mock to return the list when FindAllAsync is called
            _thongTinLuongNhanVienMock.Setup(repo => repo.FindAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(thongTinLuongNhanViens);

            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result, Is.EqualTo(expected));
            _thongTinLuongNhanVienMock.Verify(x => x.Add(It.IsAny<ThongTinLuongNhanVienEntity>()), Times.Never);
            _thongTinLuongNhanVienMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Never);
        }
    }
}
