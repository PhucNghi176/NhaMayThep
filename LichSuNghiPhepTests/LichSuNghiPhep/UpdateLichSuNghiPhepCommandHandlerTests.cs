using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMayThep.Application.LichSuNghiPhep;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities.ConfigTable;
namespace NhaMayThep.Application.UnitTests;

[TestFixture]

public class UpdateLichSuNghiPhepCommandHandlerTests
{
    private Mock<ILichSuNghiPhepRepository> _repositoryMock;
    private Mock<IMapper> _mapperMock;
    private Mock<ICurrentUserService> _currentUserServiceMock;
    private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepositoryMock;
    private Mock<INhanVienRepository> _nhanVienRepositoryMock;
    private UpdateLichSuNghiPhepCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _currentUserServiceMock = new Mock<ICurrentUserService>();
        _loaiNghiPhepRepositoryMock = new Mock<ILoaiNghiPhepRepository>();
        _repositoryMock = new Mock<ILichSuNghiPhepRepository>(); // Adjusted to correct variable
        _mapperMock = new Mock<IMapper>();
        _nhanVienRepositoryMock = new Mock<INhanVienRepository>();

        _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

        _handler = new UpdateLichSuNghiPhepCommandHandler(
        _currentUserServiceMock.Object,
        _loaiNghiPhepRepositoryMock.Object,
        _repositoryMock.Object,
        _mapperMock.Object,
         _nhanVienRepositoryMock.Object);
    }


    [Test]
    public async Task Handle_GivenValidCommand_ShouldUpdateEntityAndReturnSuccessMessage()
    {
        // Arrange
        var command = new UpdateLichSuNghiPhepCommand
        {
            Id = "existingId",
            MaSoNhanVien = "updatedMaSoNhanVien",
            LoaiNghiPhepID = 2,
            NgayBatDau = DateTime.Today,
            NgayKetThuc = DateTime.Today.AddDays(5),
            LyDo = "updatedReason",
            NguoiDuyet = "updatedNguoiDuyet"
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
        var existingEntity = new LichSuNghiPhepNhanVienEntity
        {
            ID = command.Id,
            MaSoNhanVien = "existingMaSoNhanVien",
            LoaiNghiPhepID = command.LoaiNghiPhepID, 
            NgayBatDau = command.NgayBatDau,
            NgayKetThuc = command.NgayKetThuc,
            LyDo = command.LyDo,
            NguoiDuyet = command.NguoiDuyet
        };



        _repositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                         .ReturnsAsync(existingEntity);

        _repositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default))
                                     .ReturnsAsync(1); // Simulate successful update



        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("Cập nhật lịch sử nghỉ phép thành công.", result);
        _repositoryMock.Verify(r => r.Update(It.IsAny<LichSuNghiPhepNhanVienEntity>()), Times.Once);
        _repositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
