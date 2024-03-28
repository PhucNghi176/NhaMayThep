
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongDoan.UpdateThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.Comands.ThongTinCongDoan
{
    public class RestoreThongTinCongDoanCommandHandlerTest
    {
        private  Mock<IThongTinCongDoanRepository> _thongtinCongDoanRepository;
        private Mock<INhanVienRepository> _nhanvienRepository;
        private Mock<ICurrentUserService> _currentUserService;
        private UpdateThongTinCongDoanCommandHandler _handler;
        [SetUp]
        public void Setup()
        {
            _thongtinCongDoanRepository = new Mock<IThongTinCongDoanRepository>();
            _nhanvienRepository = new Mock<INhanVienRepository>();
            _currentUserService = new Mock<ICurrentUserService>();
            _handler = new UpdateThongTinCongDoanCommandHandler(
                _thongtinCongDoanRepository.Object,
                _nhanvienRepository.Object,
                _currentUserService.Object);
        }

        [Test]
        public async Task Handler_Should_ReturnNotFound_With_ID_DoesNot_Exist()
        {
            // Arrange
            var id = "ivalidId";
            var command= new UpdateThongTinCongDoanCommand(id: id, "test",false,null);
            _thongtinCongDoanRepository.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCongDoanEntity?)null);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
        }
        [Test]
        public async Task Handler_Should_ReturnNotFound_With_NhanVienID_DoesNot_Exist()
        {
            // Arrange
            var id = "ivalidId";
            var command = new UpdateThongTinCongDoanCommand(id: id, "test", false, null);
            _nhanvienRepository.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((NhanVienEntity?)null);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
        }
        [Test]
        public async Task Handler_Should_ReturnSuuccess_When_Updated()
        {
            // Arrange
            var command = new UpdateThongTinCongDoanCommand("validId", "validId", false, null);
            var nhanvien = new NhanVienEntity
            {
                ID = "validId",
                Email = "validEmail",
                PasswordHash = "validPassword",
                HoVaTen = "validHoVaTen",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                DaCoHopDong = true,
                NgayVaoCongTy = new DateTime(2020, 01, 01),
                DiaChiLienLac = "validAdress",
                SoDienThoaiLienLac = "validPhone",
                MaSoThue = "123456789",
                TenNganHang = "validBank",
                SoTaiKhoan = "validAccount"

            };
            var congdoan = new ThongTinCongDoanEntity
            {
                ID = "validId",
                NhanVienID = "validNhanVien",
                NhanVien = null,
                ThuKiCongDoan = false,
                NgayGiaNhap = DateTime.Now
            };
            var expected = "Cập nhật thành công";
            _nhanvienRepository.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanvien);
            _thongtinCongDoanRepository.Setup(
               x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(congdoan);
            _thongtinCongDoanRepository.Setup(
                x => x.Update(congdoan));
            _thongtinCongDoanRepository.Setup(
            x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            //Act
            var result = await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.That(true, "isEqual",result, expected);
        }
    }
}
