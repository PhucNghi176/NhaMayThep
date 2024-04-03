using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongTy.UpdateThongTinCongTy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinCongTyUnitTest
{
    [TestFixture]
    public class UpdateThongTinCongTyUnitTest
    {
        private Mock<IThongTinCongTyRepository> _thongTinCongTyRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private UpdateThongTinCongTyCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinCongTyRepositoryMock = new Mock<IThongTinCongTyRepository>();
            _handlerMock = new UpdateThongTinCongTyCommandHandler(
                _thongTinCongTyRepositoryMock.Object,
                _currentUserServiceMock.Object);
        }
        [Test]
        public async Task ThongTinCongTy_UpdateValid_ReturnTrue()
        {
            //Arrange
            var expectedResult = "Cập nhật thành công";

            var data = new ThongTinCongTyEntity
            {
                ID = "1",
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack",
                TenVietTat = "TK",
                SoLuongNhanVien = 2,
                DiaChi = "17/16",
                MaSoThue = 1201,
                DienThoai = "0987654321",
                NguoiDaiDien = "TuanKiet",
                NgayHoatDong = DateTime.Now,
                DonViQuanLi = "NhaNuoc",
                LoaiHinhDoanhNghiep = "Kinh Doanh",
                TinhTrang = "HoatDong"
            };

            var command = new UpdateThongTinCongTyCommand(
                data.ID,
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang,
                data.NgayHoatDong);

            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCongTyRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task ThongTinCongTy_UpdateValid_ReturnFalse()
        {
            //Arrange
            var expectedResult = "Cập nhật thất bại";

            var data = new ThongTinCongTyEntity
            {
                ID = "1",
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack",
                TenVietTat = "TK",
                SoLuongNhanVien = 2,
                DiaChi = "17/16",
                MaSoThue = 1201,
                DienThoai = "0987654321",
                NguoiDaiDien = "TuanKiet",
                NgayHoatDong = DateTime.Now,
                DonViQuanLi = "NhaNuoc",
                LoaiHinhDoanhNghiep = "Kinh Doanh",
                TinhTrang = "HoatDong"
            };

            var command = new UpdateThongTinCongTyCommand(
                data.ID,
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang,
                data.NgayHoatDong);

            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCongTyRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);
            //Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);
            //Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public async Task ThongTinCongTy_UpdateInvalid_NotFoundException()
        {
            //Arrange
            var data = new ThongTinCongTyEntity
            {
                ID = "1",
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack",
                TenVietTat = "TK",
                SoLuongNhanVien = 2,
                DiaChi = "17/16",
                MaSoThue = 1201,
                DienThoai = "0987654321",
                NguoiDaiDien = "TuanKiet",
                NgayHoatDong = DateTime.Now,
                DonViQuanLi = "NhaNuoc",
                LoaiHinhDoanhNghiep = "Kinh Doanh",
                TinhTrang = "HoatDong"
            };

            var command = new UpdateThongTinCongTyCommand(
                data.ID,
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang,
                data.NgayHoatDong);

            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((ThongTinCongTyEntity)null);
            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task ThongTinCongTy_UpdateInvalid_ThrowsDuplicatedException()
        {
            //Arrange
            var data = new ThongTinCongTyEntity
            {
                ID = "1",
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack",
                TenVietTat = "TK",
                SoLuongNhanVien = 2,
                DiaChi = "17/16",
                MaSoThue = 1201,
                DienThoai = "0987654321",
                NguoiDaiDien = "TuanKiet",
                NgayHoatDong = DateTime.Now,
                DonViQuanLi = "NhaNuoc",
                LoaiHinhDoanhNghiep = "Kinh Doanh",
                TinhTrang = "HoatDong"
            };

            var command = new UpdateThongTinCongTyCommand(
                data.ID,
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang,
                data.NgayHoatDong);


            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);
            _thongTinCongTyRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
