using Moq;
using NUnit.Framework;
using AutoMapper;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Create;
using NhaMayThep.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Entities;
using System.Linq.Expressions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.UnitTests.ChiTietNgayNghiPhep.Create;

[TestFixture]
public class CreateChiTietNgayNghiPhepCommandHandlerTests
{
    private Mock<IChiTietNgayNghiPhepRepository> _repositoryMock;
    private Mock<IMapper> _mapperMock;
    private Mock<INhanVienRepository> _hanVienRepositoryMock;
    private Mock<ICurrentUserService> _currentUserServiceMock;
    private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepoMock;
    private CreateChiTietNgayNghiPhepCommandHandler _handler;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IChiTietNgayNghiPhepRepository>();
        _mapperMock = new Mock<IMapper>();
        _hanVienRepositoryMock = new Mock<INhanVienRepository>();
        _currentUserServiceMock = new Mock<ICurrentUserService>();
        _loaiNghiPhepRepoMock = new Mock<ILoaiNghiPhepRepository>();

        _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");

        _handler = new CreateChiTietNgayNghiPhepCommandHandler(
            _mapperMock.Object,
            _repositoryMock.Object,
            _hanVienRepositoryMock.Object,
            _currentUserServiceMock.Object,
            _loaiNghiPhepRepoMock.Object);
    }

    [Test]
    public async Task Handle_ValidCommand_ShouldCreateRecordAndReturnSuccess()
    {
        // Arrange
        var command = new CreateChiTietNgayNghiPhepCommand("validNhanVienId", 1, 100, 50, 50, 2021);
        _hanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
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
        _loaiNghiPhepRepoMock.Setup(x => x.AnyAsync(
        It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(),
        It.IsAny<CancellationToken>()))
    .ReturnsAsync(true);
        _repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default))
            .ReturnsAsync(1); // Simulate successful save

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.AreEqual("Tạo thành công", result);
    }

    [Test]
    public void Handle_NhanVienDoesNotExist_ShouldThrowNotFoundException()
    {
        // Arrange
        var command = new CreateChiTietNgayNghiPhepCommand("nonExistingNhanVienId", 1, 100, 50, 50, 2021);

        _hanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((NhanVienEntity)null); // Simulate NhanVien not found

        _loaiNghiPhepRepoMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true); // Assume LoaiNghiPhep exists for this test

        // Act & Assert
        var ex = Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        Assert.That(ex.Message, Is.EqualTo("Nhan Vien không tồn tại."));
    }

}