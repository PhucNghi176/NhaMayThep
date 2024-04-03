using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongTy.DeleteThongTinCongTy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.ThongTinCongTyUnitTest
{
    [TestFixture]
    public class DeleteThongTinCongTyUnitTest
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IThongTinCongTyRepository> _thongTinCongTyRepositoryMock;
        private DeleteThongTinCongTyCommandHandler _handlerMock;
        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _thongTinCongTyRepositoryMock = new Mock<IThongTinCongTyRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

            _handlerMock = new DeleteThongTinCongTyCommandHandler(_thongTinCongTyRepositoryMock.Object, _currentUserServiceMock.Object);
        }

        [TestCase("1")]
        public async Task ThongTinCongTy_DeleteThongTinCongTy_ReturnTrue(string id)
        {
            // Arrange
            var expectedResult = "Xóa thành công";

            var data = new ThongTinCongTyEntity
            {
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

            var command = new DeleteThongTinCongTyCommand(id);
            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("1")]
        public async Task ThongTinCongTy_DeleteThongTinCongTy_ReturnFalse(string id)
        {
            // Arrange
            var expectedResult = "Xóa thất bại";

            var data = new ThongTinCongTyEntity
            {
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

            var command = new DeleteThongTinCongTyCommand(id);
            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(data);

            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            // Act
            var result = await _handlerMock.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestCase("0")]
        public async Task ThongTinCongTy_DeleteThongTinCongTy_NotFoundException(string id)
        {
            // Arrange
            var command = new DeleteThongTinCongTyCommand(id);
            _thongTinCongTyRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCongTyEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
