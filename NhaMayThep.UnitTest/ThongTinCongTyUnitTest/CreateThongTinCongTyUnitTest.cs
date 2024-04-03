using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongTy.CreateThongTinCongTy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NhaMayThep.UnitTest.ThongTinCongTyUnitTest
{
    [TestFixture]
    public class CreateThongTinCongTyUnitTest
    {
        private Mock<IThongTinCongTyRepository> _thongTinCongTyRepositoryMock;
        private Mock<ICurrentUserService> _currentUserService;
        private CreateThongTinCongTyCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _thongTinCongTyRepositoryMock = new Mock<IThongTinCongTyRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _handlerMock = new CreateThongTinCongTyCommandHandler(_thongTinCongTyRepositoryMock.Object, _currentUserService.Object);
        }

        [TestCase("test")]
        public async Task ThongTinCongTy_CreateWithValidMaDoanhNghiep_ReturnTrue(string name)
        {
            var expectedResult = "Tạo thành công";
            var data = new ThongTinCongTyEntity
            {
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack" ,
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

            var command = new CreateThongTinCongTyCommand(
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.NgayHoatDong,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang);

            _thongTinCongTyRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _thongTinCongTyRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("testDuplication")]
        public async Task ThongTinCongTy_CreateWithInvalidMaDoanhNghiep_ThrowsDuplicatedException(string name)
        {
            var data = new ThongTinCongTyEntity
            {
                MaDoanhNghiep = 1, //Assume that MaDoanhNghiep existed in the database
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

            var command = new CreateThongTinCongTyCommand(
                data.MaDoanhNghiep,
                data.TenQuocTe,
                data.TenVietTat,
                data.SoLuongNhanVien,
                data.DiaChi,
                data.MaSoThue,
                data.DienThoai,
                data.NguoiDaiDien,
                data.NgayHoatDong,
                data.DonViQuanLi,
                data.LoaiHinhDoanhNghiep,
                data.TinhTrang);

            _thongTinCongTyRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
