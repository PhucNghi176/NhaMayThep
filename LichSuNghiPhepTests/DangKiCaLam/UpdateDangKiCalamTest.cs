using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiCaLam.Create;
using NhaMayThep.Application.DangKiCaLam.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.DangKiCaLam
{
    [TestFixture]
    public class UpdateDangKiCalamTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IDangKiCaLamRepository> _dangKiCaLamRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private UpdateDangKiCaLamCommandHandler _handler;
        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _dangKiCaLamRepositoryMock = new Mock<IDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handler = new UpdateDangKiCaLamCommandHandler(_mapperMock.Object, _dangKiCaLamRepositoryMock.Object, _currentUserServiceMock.Object, _nhanVienRepositoryMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }
        [Test]
        public async Task Handle_GivenValidRequest_ShouldUpdateDangKiCaLamAndReturnSuccessMessage()
        {
            // Arrange
            var command = new UpdateDangKiCaLamCommand
            {

                MaSoNhanVien = "validMaSoNhanVien",
                NgayDangKi = new DateTime(2023, 1, 1),
                CaDangKi = 1, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 8, 0, 0), // 8 AM start
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 17, 0, 0), // 5 PM end

                ThoiGianChamCongBatDau = null,
                ThoiGianChamCongKetThuc = null,
                HeSoNgayCong = 1, // Assuming full day work
                MaSoNguoiQuanLy = "validMaSoNguoiQuanLy",
                TrangThai = 0, // Assuming 0 represents a pending state
                GhiChu = "Test registration for shift"
            };
            _dangKiCaLamRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
            _nhanVienRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(new NhanVienEntity
            {
                ID = "someId",
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
            });

            var existingEntity = new DangKiCaLamEntity
            {
                MaSoNhanVien = "validMaSoNhanVien",
                NgayDangKi = new DateTime(2023, 1, 1),
                CaDangKi = 2, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 8, 0, 0), // 8 AM start
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 18, 0, 0),

                ThoiGianChamCongBatDau = null,
                ThoiGianChamCongKetThuc = null,
                HeSoNgayCong = 2, // Assuming full day work
                MaSoNguoiQuanLy = "validMaSoNguoiQuanLy",
                TrangThai = 1, // Assuming 0 represents a pending state
                GhiChu = "Test registration for shift"
            };

            _dangKiCaLamRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                         .ReturnsAsync(existingEntity);

            _dangKiCaLamRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default))
                                         .ReturnsAsync(1); // Simulate successful update



            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Cập nhật Đăng Kí Ca Làm thành công", result);
            _dangKiCaLamRepositoryMock.Verify(r => r.Update(It.IsAny<DangKiCaLamEntity>()), Times.Once);
            _dangKiCaLamRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


    }
}
