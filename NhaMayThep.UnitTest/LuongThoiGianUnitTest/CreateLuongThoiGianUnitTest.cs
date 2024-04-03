using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LuongThoiGian.CreateLuongThoiGian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.LuongThoiGianUnitTest
{
    [TestFixture]
    public class CreateLuongThoiGianUnitTest
    {
        private Mock<ILuongThoiGianRepository> _luongThoiGianRepositoryMock;
        private Mock<ICurrentUserService> _currentUserService;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private CreateLuongThoiGianCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _luongThoiGianRepositoryMock = new Mock<ILuongThoiGianRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handlerMock = new CreateLuongThoiGianCommandHandler(_luongThoiGianRepositoryMock.Object, _currentUserService.Object, _nhanVienRepositoryMock.Object);
        }

        [TestCase("test")]
        public async Task LuongThoiGian_CreateValid_ReturnTrue(string name)
        {
            var expectedResult = "Tạo thành công";
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

            var command = new CreateLuongThoiGianCommand(
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _luongThoiGianRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase("testDuplication")]
        public async Task LuongThoiGian_CreateWithDuplicatedMaSoNhanVien_ThrowsDuplicatedException(string name)
        {
            var data = new LuongThoiGianEntity
            {
                MaSoNhanVien = "1",// Assume that MaSoNhanVien existed in the database
                MaLuongThoiGian = 1,
                LuongNam = 8640000,
                LuongThang = 720000,
                LuongTuan = 168000,
                LuongNgay = 24000,
                LuongGio = 1000,
                NgayApDung = DateTime.Now
            };

            var command = new CreateLuongThoiGianCommand(
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _luongThoiGianRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LuongThoiGianEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [TestCase("testNotFound")]
        public async Task LuongThoiGian_CreateWithInvalidMaSoNhanVien_ThrowsNotFoundException(string name)
        {
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

            var command = new CreateLuongThoiGianCommand(
                data.MaSoNhanVien,
                data.MaLuongThoiGian,
                data.LuongNam,
                data.LuongThang,
                data.LuongTuan,
                data.LuongNgay,
                data.LuongGio,
                data.NgayApDung);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            _luongThoiGianRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}
