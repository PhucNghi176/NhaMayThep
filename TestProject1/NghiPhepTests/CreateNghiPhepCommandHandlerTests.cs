using AutoMapper;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Create;
using NhaMayThep.Domain.Repositories;
using NhaMapThep.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System.Linq.Expressions;

namespace TestProject1.NghiPhepTests
{
    [TestFixture]
    public class CreateNghiPhepCommandHandlerTests
    {
        private CreateNghiPhepCommandHandler _handler;
        private Mock<INghiPhepRepository> _nghiPhepRepositoryMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;
        private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void SetUp()
        {
            _nghiPhepRepositoryMock = new Mock<INghiPhepRepository>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _loaiNghiPhepRepositoryMock = new Mock<ILoaiNghiPhepRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _mapperMock = new Mock<IMapper>();

            _handler = new CreateNghiPhepCommandHandler(
                _currentUserServiceMock.Object,
                _mapperMock.Object,
                _nghiPhepRepositoryMock.Object,
                _nhanVienRepositoryMock.Object,
                _loaiNghiPhepRepositoryMock.Object
            );
        }

        [Test]
        public async Task Handle_WithValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new CreateNghiPhepCommand(
                maSoNhanVien: "123",
                luongNghiPhep: 8.0m,
                khoanTruLuong: 1.5m,
                soGioNghiPhep: 8.0,
                loaiNghiPhepId: 1
            );

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                               .ReturnsAsync(true);

            _loaiNghiPhepRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                       .ReturnsAsync(true);

            _nghiPhepRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thành Công!", result);
        }

        [Test]
        public async Task Handle_WithNonexistentEmployee_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateNghiPhepCommand(
                maSoNhanVien: "456",
                luongNghiPhep: 8.0m,
                khoanTruLuong: 1.5m,
                soGioNghiPhep: 8.0,
                loaiNghiPhepId: 1
            );

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại! Nhân viên không tồn tại.", result);
        }

        [Test]
        public async Task Handle_WithInvalidLeaveType_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateNghiPhepCommand(
                maSoNhanVien: "123",
                luongNghiPhep: 8.0m,
                khoanTruLuong: 1.5m,
                soGioNghiPhep: 8.0,
                loaiNghiPhepId: 2 // Giả định không có loaiNghiPhepId 2
            );

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(true);

            _loaiNghiPhepRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                       .ReturnsAsync(false);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại! Loại nghỉ phép không hợp lệ.", result);
        }

        [Test]
        public async Task Handle_WithSavingFailure_ReturnsFailureMessage()
        {
            // Arrange
            var command = new CreateNghiPhepCommand(
                maSoNhanVien: "123",
                luongNghiPhep: 8.0m,
                khoanTruLuong: 1.5m,
                soGioNghiPhep: 8.0,
                loaiNghiPhepId: 1
            );

            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(true);

            _loaiNghiPhepRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                       .ReturnsAsync(true);

            _nghiPhepRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                                   .ReturnsAsync(0); // Mô phỏng việc lưu thất bại

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Thất Bại!", result);
        }
    }
}
