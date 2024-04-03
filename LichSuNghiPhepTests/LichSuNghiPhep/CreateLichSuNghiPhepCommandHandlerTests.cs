using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.LichSuNghiPhep.Create;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Common.Exceptions;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.LichSuNghiPhep;

namespace NhaMayThep.Application.UnitTests
{
    [TestFixture]
    public class CreateLichSuNghiPhepCommandHandlerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ILichSuNghiPhepRepository> _lichSuNghiPhepRepositoryMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepositoryMock;

        private CreateLichSuNghiPhepCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _lichSuNghiPhepRepositoryMock = new Mock<ILichSuNghiPhepRepository>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _loaiNghiPhepRepositoryMock = new Mock<ILoaiNghiPhepRepository>();

            _handler = new CreateLichSuNghiPhepCommandHandler(
                _mapperMock.Object,
                _currentUserServiceMock.Object,
                _lichSuNghiPhepRepositoryMock.Object,
                _nhanVienRepositoryMock.Object,
                _loaiNghiPhepRepositoryMock.Object
            );

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public async Task Handle_GivenValidRequest_ShouldCreateLichSuNghiPhepAndReturnSuccessMessage()
        {
            var command = new CreateLichSuNghiPhepCommand
            {
                MaSoNhanVien = "validMaSoNhanVien",
                LoaiNghiPhepID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(5),
                LyDo = "Sick leave",
                NguoiDuyet = "validNguoiDuyet"
            };

            _loaiNghiPhepRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
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
            _lichSuNghiPhepRepositoryMock.Setup(r => r.Add(It.IsAny<LichSuNghiPhepNhanVienEntity>()));
            _lichSuNghiPhepRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Lịch sử nghỉ phép đã tạo thành công", result);
            _lichSuNghiPhepRepositoryMock.Verify(r => r.Add(It.IsAny<LichSuNghiPhepNhanVienEntity>()), Times.Once);
            _lichSuNghiPhepRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
        [Test]
        public void Handle_GivenInvalidLoaiNghiPhepID_ShouldThrowNotFoundException()
        {
            // Arrange for LoaiNghiPhepID not found
            _loaiNghiPhepRepositoryMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

            var command = new CreateLichSuNghiPhepCommand
            {
                MaSoNhanVien = "validMaSoNhanVien",
                LoaiNghiPhepID = 999, // This ID does not exist
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(5),
                LyDo = "Sick leave",
                NguoiDuyet = "validNguoiDuyet"
            };

            // Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
        [Test]
        public void Handle_NhanVienOrNguoiDuyetNotFound_ShouldThrowNotFoundException()
        {
            // Arrange for NhanVien not found
            _nhanVienRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>())).ReturnsAsync((NhanVienEntity)null);

            var command = new CreateLichSuNghiPhepCommand
            {
                MaSoNhanVien = "nonExistentNhanVien", // This NhanVien does not exist
                LoaiNghiPhepID = 1,
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(5),
                LyDo = "Sick leave",
                NguoiDuyet = "validNguoiDuyet"
            };

            // Assert for NhanVien not found
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));

            // Arrange for NguoiDuyet not found
            _nhanVienRepositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(new NhanVienEntity
         {
          
             Email = "example@example.com",
             PasswordHash = "hashedPassword",
             HoVaTen = "Example Name",
             ChucVuID = 1, 
             TinhTrangLamViecID = 1, 
             DaCoHopDong = true,
             NgayVaoCongTy = DateTime.Now,
             DiaChiLienLac = "123 Example St",
             SoDienThoaiLienLac = "0123456789",
             MaSoThue = "123456789",
             TenNganHang = "Example Bank",
             SoTaiKhoan = "1234567890"
         });
            command.NguoiDuyet = "nonExistentNguoiDuyet"; //nguoiduyet k ton tai

           
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
