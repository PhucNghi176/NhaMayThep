using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiCaLam.Update;
using NhaMayThep.Application.DangKiTangCa.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.DangKiTangCa
{
    [TestFixture]

    public class UpdateDangKiTangCaTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IDangKiTangCaRepository> _dangKiTangCaRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private UpdateDangKiTangCaCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _dangKiTangCaRepositoryMock = new Mock<IDangKiTangCaRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handler = new UpdateDangKiTangCaCommandHandler(_mapperMock.Object, _dangKiTangCaRepositoryMock.Object, _currentUserServiceMock.Object, _nhanVienRepositoryMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");


        }
        [Test]
        public async Task Handle_GivenValidRequest_ShouldUpdateDangKiCaLamAndReturnSuccessMessage()
        {
            // Arrange
            var command = new UpdateDangKiTangCaCommand
            {

                MaSoNhanVien = "validMaSoNhanVien",
                NgayLamTangCa = new DateTime(2023, 1, 1),
                CaDangKi = 1, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 18, 0, 0), // 6 PM start for overtime
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 22, 0, 0), // 10 PM end for overtime
                LiDoTangCa = "Extra project work",
                SoGioTangCa = new TimeSpan(4, 0, 0), // 4 hours of overtime
                HeSoLuongTangCa = 1.5M, // Assuming 1.5 times the regular pay
                TrangThaiDuyet = 0, // Pending approval
                NguoiDuyet = "validNguoiDuyetId"



            };
            _dangKiTangCaRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<DangKiTangCaEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
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

            var existingEntity = new DangKiTangCaEntity
            {
                MaSoNhanVien = "validMaSoNhanVien",
                NgayLamTangCa = new DateTime(2023, 1, 1),
                CaDangKi = 2, // Assuming this represents a valid shift
                ThoiGianCaLamBatDau = new DateTime(2023, 1, 1, 19, 0, 0), // 6 PM start for overtime
                ThoiGianCaLamKetThuc = new DateTime(2023, 1, 1, 22, 0, 0), // 10 PM end for overtime
                LiDoTangCa = "Extra project workasdasd",
                SoGioTangCa = new TimeSpan(5, 0, 0), // 4 hours of overtime
                HeSoLuongTangCa = 1.5M, // Assuming 1.5 times the regular pay
                TrangThaiDuyet = 1, // Pending approval
                NguoiDuyet = "validNguoiDuyetId"
            };

            _dangKiTangCaRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<DangKiTangCaEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                         .ReturnsAsync(existingEntity);

            _dangKiTangCaRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default))
                                         .ReturnsAsync(1); // Simulate successful update



            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Cập nhật Đăng Kí Tăng Ca thành công", result);
            _dangKiTangCaRepositoryMock.Verify(r => r.Update(It.IsAny<DangKiTangCaEntity>()), Times.Once);
            _dangKiTangCaRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
    }
