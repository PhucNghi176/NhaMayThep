using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.BaoHiemNhanVien.Update;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Common.Interfaces;

namespace TestProject1.BaoHiemNhanVienTests
{
    [TestFixture]
    public class UpdateBaoHiemNhanVienCommandHandlerTests
    {
        private UpdateBaoHiemNhanVienCommandHandler _handler;
        private Mock<IBaoHiemNhanVienRepository> _baoHiemNhanVienRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<IBaoHiemRepository> _baoHiemRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _baoHiemNhanVienRepositoryMock = new Mock<IBaoHiemNhanVienRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _baoHiemRepositoryMock = new Mock<IBaoHiemRepository>();

            // Thiết lập giá trị cho tất cả các thuộc tính bắt buộc của NhanVienEntity
            var nhanVienEntity = new NhanVienEntity
            {
                Email = "example@example.com",
                PasswordHash = "passwordHash",
                HoVaTen = "Tên nhân viên",
                ChucVuID = 1,
                TinhTrangLamViecID = 1,
                NgayVaoCongTy = DateTime.Now,
                DiaChiLienLac = "Địa chỉ liên lạc",
                SoDienThoaiLienLac = "0123456789",
                MaSoThue = "MaSoThue",
                TenNganHang = "TenNganHang",
                SoTaiKhoan = "SoTaiKhoan",
                DaCoHopDong = true
            };

            // Thiết lập trả về của các mock repository
            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaoHiemNhanVienEntity
                {
                    MaSoNhanVien = "MSNV001",
                    BaoHiem = 1
                });

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(nhanVienEntity);

            _handler = new UpdateBaoHiemNhanVienCommandHandler(
                _baoHiemNhanVienRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object,
                _nhanVienRepositoryMock.Object,
                _baoHiemRepositoryMock.Object
            );
            _baoHiemNhanVienRepositoryMock.Setup(x => x.UnitOfWork).Returns(Mock.Of<IUnitOfWork>());
        }

        [Test]
        public async Task Handle_WithValidInput_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new UpdateBaoHiemNhanVienCommand("id", "maSoNhanVien", 1);
            var baoHiemNhanVienEntity = new BaoHiemNhanVienEntity
            {
                MaSoNhanVien = "MSNV001",
                BaoHiem = 1
            };

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(baoHiemNhanVienEntity);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new NhanVienEntity
                {
                    Email = "example@example.com",
                    PasswordHash = "passwordHash",
                    HoVaTen = "Tên nhân viên",
                    ChucVuID = 1,
                    TinhTrangLamViecID = 1,
                    NgayVaoCongTy = DateTime.Now,
                    DiaChiLienLac = "Địa chỉ liên lạc",
                    SoDienThoaiLienLac = "0123456789",
                    MaSoThue = "MaSoThue",
                    TenNganHang = "TenNganHang",
                    SoTaiKhoan = "SoTaiKhoan",
                    DaCoHopDong = true
                });

            _baoHiemRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaoHiemEntity() { Name = "test", PhanTramKhauTru = 1 });

            _currentUserServiceMock.Setup(x => x.UserId).Returns("userId");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Cập nhật thành công!", result);
            _baoHiemNhanVienRepositoryMock.Verify(x => x.Update(It.IsAny<BaoHiemNhanVienEntity>()), Times.Once);
        }


        [Test]
        public void Handle_WithNonExistentBaoHiemNhanVien_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateBaoHiemNhanVienCommand("id", "maSoNhanVien", 1);

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((BaoHiemNhanVienEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_WithNonExistentNhanVien_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateBaoHiemNhanVienCommand("id", "maSoNhanVien", 1);
            var baoHiemNhanVienEntity = new BaoHiemNhanVienEntity
            {
                ID = "id",
                MaSoNhanVien = "maSoNhanVien",
                BaoHiem = 1,
            };

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(baoHiemNhanVienEntity);

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((NhanVienEntity)null!);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_WithNonExistentBaoHiem_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateBaoHiemNhanVienCommand("id", "maSoNhanVien", 1);
            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaoHiemNhanVienEntity() { BaoHiem = 1, MaSoNhanVien = "ExampleMaSoNhanVien"});

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new NhanVienEntity {Email = "example@example.com", PasswordHash = "passwordHash", HoVaTen = "Tên nhân viên", ChucVuID = 1, TinhTrangLamViecID = 1, NgayVaoCongTy = DateTime.Now, DiaChiLienLac = "Địa chỉ liên lạc", SoDienThoaiLienLac = "0123456789", MaSoThue = "MaSoThue", TenNganHang = "TenNganHang", SoTaiKhoan = "SoTaiKhoan", DaCoHopDong = true });

            _baoHiemRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync((BaoHiemEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public void Handle_WithExistingBaoHiemNhanVien_ThrowsNotFoundException()
        {
            // Arrange
            var command = new UpdateBaoHiemNhanVienCommand("id", "maSoNhanVien", 1);
            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaoHiemNhanVienEntity() { BaoHiem = 1, MaSoNhanVien = "ExampleMaSoNhanVien"});

            _nhanVienRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<NhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new NhanVienEntity {Email = "example@example.com", PasswordHash = "passwordHash", HoVaTen = "Tên nhân viên", ChucVuID = 1, TinhTrangLamViecID = 1, NgayVaoCongTy = DateTime.Now, DiaChiLienLac = "Địa chỉ liên lạc", SoDienThoaiLienLac = "0123456789", MaSoThue = "MaSoThue", TenNganHang = "TenNganHang", SoTaiKhoan = "SoTaiKhoan", DaCoHopDong = true });

            _baoHiemRepositoryMock.Setup(x => x.FindAsync(
                It.IsAny<Expression<Func<BaoHiemEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(new BaoHiemEntity() { Name = "test", PhanTramKhauTru = 1 });

            _baoHiemNhanVienRepositoryMock.Setup(x => x.AnyAsync(
                It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
