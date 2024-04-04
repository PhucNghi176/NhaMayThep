using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.DangKiCaLam.Create;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.DangKiCaLam
{
    [TestFixture]
    public class CreateDangKiCaLamCommandHandlerTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IDangKiCaLamRepository> _dangKiCaLamRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private CreateDangKiCaLamCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _dangKiCaLamRepositoryMock = new Mock<IDangKiCaLamRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handler = new CreateDangKiCaLamCommandHandler(_mapperMock.Object, _dangKiCaLamRepositoryMock.Object, _currentUserServiceMock.Object, _nhanVienRepositoryMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public async Task Handle_GivenValidRequest_ShouldCreateDangKiCaLamAndReturnSuccessMessage()
        {
            // Arrange
            var command = new CreateDangKiCaLamCommand
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

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
      .ReturnsAsync(new NhanVienEntity
      {
          ID = "validNhanVienId",
          TinhTrangLamViecID = 1,
          TenNganHang = "SomeBank",
          SoTaiKhoan = "123456789",
          SoDienThoaiLienLac = "0123456789",
          PasswordHash = "SomeHash",
          NgayVaoCongTy = DateTime.Now,
          MaSoThue = "SomeTaxID",
          HoVaTen = "SomeName",
          ChucVuID = 1,
          Email = "example@example.com",
          DiaChiLienLac = "123 Main Street, Anytown",
          DaCoHopDong = true
      });

            _dangKiCaLamRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                                      .ReturnsAsync(1); 

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Dang Ki Ca Lam thành công", result);
            _dangKiCaLamRepositoryMock.Verify(x => x.Add(It.IsAny<DangKiCaLamEntity>()), Times.Once);
            _dangKiCaLamRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}
