using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep.Update;
using NhaMayThep.Application.LichSuNghiPhep;
using System.Linq.Expressions;
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
    public async Task Handle_GivenValidCommand_ShouldUpdateEntity()
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

        var existingEntity = new LichSuNghiPhepNhanVienEntity
        {
            ID = command.Id,
            MaSoNhanVien = "updatedMaSoNhanVien",
            LoaiNghiPhepID = 3,
            NgayBatDau = DateTime.Today,
            NgayKetThuc = DateTime.Today.AddDays(5),
            LyDo = "kbiet",
            NguoiDuyet = "updatedNguoiDuyet"
        };

        var updatedDto = new LichSuNghiPhepDto
        {
            Id = command.Id,
            MaSoNhanVien = "updatedMaSoNhanVien",
            LoaiNghiPhepID = 3,
            NgayBatDau = DateTime.Today,
            NgayKetThuc = DateTime.Today.AddDays(5),
            LyDo = "kbiet",
            NguoiDuyet = "updatedNguoiDuyet"
        };

        _repositoryMock.Setup(r => r.FindAsync(
            It.Is<Expression<Func<LichSuNghiPhepNhanVienEntity, bool>>>(expr => expr.Compile()(existingEntity)),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(existingEntity);

        _mapperMock.Setup(m => m.Map<LichSuNghiPhepDto>(It.IsAny<LichSuNghiPhepNhanVienEntity>()))
                   .Returns(updatedDto);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(updatedDto, result);

        _repositoryMock.Verify(r => r.Update(It.Is<LichSuNghiPhepNhanVienEntity>(e =>
            e.MaSoNhanVien == command.MaSoNhanVien &&
            e.LoaiNghiPhepID == command.LoaiNghiPhepID &&
            e.NgayBatDau == command.NgayBatDau &&
            e.NgayKetThuc == command.NgayKetThuc &&
            e.LyDo == command.LyDo &&
            e.NguoiDuyet == command.NguoiDuyet
        )), Times.Once);

        _repositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
    }
}
