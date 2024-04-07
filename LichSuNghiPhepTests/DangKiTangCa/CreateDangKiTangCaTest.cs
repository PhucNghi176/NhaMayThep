using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DangKiCaLam.Create;
using NhaMayThep.Application.DangKiTangCa.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.UnitTest.DangKiTangCa
{
    public class CreateDangKiTangCaTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IDangKiTangCaRepository> _dangKiTangCaRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private CreateDangKiTangCaCommandHandler _handler;



        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _dangKiTangCaRepositoryMock = new Mock<IDangKiTangCaRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _handler = new CreateDangKiTangCaCommandHandler(_mapperMock.Object, _currentUserServiceMock.Object, _dangKiTangCaRepositoryMock.Object, _nhanVienRepositoryMock.Object);

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }


        [Test]
        public async Task Handle_GivenValidRequest_ShouldCreateDangKiTangCaAndReturnSuccessMessage()
        {
            // Arrange
            var command = new CreateDangKiTangCaCommand
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

            _dangKiTangCaRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                                      .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Dang Ki Tang Ca thành công", result);
            _dangKiTangCaRepositoryMock.Verify(x => x.Add(It.IsAny<DangKiTangCaEntity>()), Times.Once);
            _dangKiTangCaRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}
