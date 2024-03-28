using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongDoan.CreateThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThepUnitTesting.ThongTinCongDoan
{
    public class CreateThongTinConDoanCommandHandlerTest
    {
        private  Mock<IThongTinCongDoanRepository> _thongtinCongDoanRepository;
        private  Mock<INhanVienRepository> _nhanVienRepository;
        private  Mock<ICurrentUserService> _currentUserService;
        private CreateThongTinCongDoanCommandHandler _handler;
        [SetUp]
        public void Setup()
        {
            _thongtinCongDoanRepository = new Mock<IThongTinCongDoanRepository> ();
            _nhanVienRepository = new Mock<INhanVienRepository> ();
            _currentUserService = new Mock<ICurrentUserService> ();
            _handler = new CreateThongTinCongDoanCommandHandler(
                _thongtinCongDoanRepository.Object,
                _nhanVienRepository.Object,
                _currentUserService.Object);
        }
        [Test]
        public async Task Handler_Should_ReturnNotFound_WhenIdDoesNotExist()
        {

            //Arrange
            var command = new CreateThongTinCongDoanCommand
            (
                nhanVienID : "validNhanVien",
                thuKyCongDoan : false,
                ngaygianhap : DateTime.Now
            );
            var nhanvien = new NhanVienEntity
            {
                ID = "someId",
                Email = "email@example.com",
                PasswordHash = "hashedPassword123",
                HoVaTen = "Nguyen Van A",
                ChucVuID = 1, // Assume this ID exists in your database
                TinhTrangLamViecID = 1, // Same here
                DaCoHopDong = true,
                NgayVaoCongTy = new DateTime(2020, 01, 01),
                DiaChiLienLac = "123 Main St",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "123456789",
                TenNganHang = "Bank ABC",
                SoTaiKhoan = "987654321"
            };
            _nhanVienRepository
               .Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((NhanVienEntity?)null);
            //Act
            async Task<string> Act() => await _handler.Handle(command, CancellationToken.None);
            //Assert
             Assert.ThrowsAsync<NotFoundException>(Act);

        }
        [Test]
        public async Task Handler_Should_ReturnDuplicate_WhenExist_ThongTinCongDoan()
        {

            //Arrange
            var command = new CreateThongTinCongDoanCommand
            (
                nhanVienID: "validNhanVien",
                thuKyCongDoan: false,
                ngaygianhap: DateTime.Now
            );
            var congdoan = new ThongTinCongDoanEntity
            {
                ID = "validId",
                NhanVienID = "validNhanVien",
                NhanVien = null,
                ThuKiCongDoan = true,
                NgayGiaNhap = DateTime.Now
            };
            var nhanvien = new NhanVienEntity
            {
                ID = "validNhanVien",
                Email = "email@example.com",
                PasswordHash = "hashedPassword123",
                HoVaTen = "Nguyen Van A",
                ChucVuID = 1, // Assume this ID exists in your database
                TinhTrangLamViecID = 1, // Same here
                DaCoHopDong = true,
                NgayVaoCongTy = new DateTime(2020, 01, 01),
                DiaChiLienLac = "123 Main St",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "123456789",
                TenNganHang = "Bank ABC",
                SoTaiKhoan = "987654321"
            };

            _nhanVienRepository
               .Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(nhanvien);
            _thongtinCongDoanRepository
               .Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(congdoan);
            //Act
            async Task<string> Act() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<DuplicationException>(Act);
        }
        [Test]
        public async Task Handler_Should_CreateThongTinCongDoan_AndReturnSuccess()
        {

            //Arrange
            var command = new CreateThongTinCongDoanCommand
            (
                nhanVienID: "invalidNhanVien",
                thuKyCongDoan: false,
                ngaygianhap: DateTime.Now
            );
            var thongtincongdoan = new ThongTinCongDoanEntity {
                NhanVienID = "validNhanVien",
                ThuKiCongDoan = true,
                NgayGiaNhap = DateTime.Now,
                NhanVien = null
            };
            var nhanvien = new NhanVienEntity
            {
                ID = "validNhanVien",
                Email = "email@example.com",
                PasswordHash = "hashedPassword123",
                HoVaTen = "Nguyen Van A",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                DaCoHopDong = true,
                NgayVaoCongTy = new DateTime(2020, 01, 01),
                DiaChiLienLac = "123 Main St",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "123456789",
                TenNganHang = "Bank ABC",
                SoTaiKhoan = "987654321"
            };
            var expectedmessage = "Tạo thông tin công đoàn thành công";
             _nhanVienRepository
               .Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(nhanvien);
            _thongtinCongDoanRepository
               .Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync((ThongTinCongDoanEntity?)null);
            _thongtinCongDoanRepository.Setup(x
               => x.Add(thongtincongdoan));
            _thongtinCongDoanRepository.Setup(x =>
            x.UnitOfWork.SaveChangesAsync(CancellationToken.None)).ReturnsAsync(1);

            //Act
            var result= await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.That(true, "isEqual", expectedmessage, result);
        }
    }
}
