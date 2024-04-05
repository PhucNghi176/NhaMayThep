using Moq;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using NhaMayThep.Application.QuaTrinhNhanSu.GetSingleQuaTrinhNhanSu;
using AutoMapper;
using NhaMayThep.Application.QuaTrinhNhanSu.GetAllQuaTrinhNhanSu;
using NhaMapThep.Domain.Entities;
using System.Linq.Expressions;
using NhaMayThep.Application.QuaTrinhNhanSu;
using NhaMayThep.Application.CapBacLuong;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.LoaiHoaDon;

namespace UnitTestHRM;
[TestFixture]
public class GetQuaTrinhNhanSu
{
    private Mock<IQuaTrinhNhanSuRepository> _quaTrinhNhanSuRepositoryMock;
    private Mock<IChucDanhRepository> _chucDanhRepositoryMock;
    private Mock<IChucVuRepository> _chucVuRepositoryMock;
    private Mock<IThongTinQuaTrinhNhanSuRepository> _thongTinQuaTrinhNhanSuRepositorryMock;
    private Mock<IPhongBanRepository> _phongBanRepositoryMock;
    private Mock<INhanVienRepository> _nhanVienRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private GetQuaTrinhNhanSuQueryHandler _handlerMock;

    [SetUp]
    public void Setup()
    {
        _quaTrinhNhanSuRepositoryMock = new Mock<IQuaTrinhNhanSuRepository>();
        _chucDanhRepositoryMock = new Mock<IChucDanhRepository>();
        _chucVuRepositoryMock = new Mock<IChucVuRepository>();
        _thongTinQuaTrinhNhanSuRepositorryMock = new Mock<IThongTinQuaTrinhNhanSuRepository>();
        _phongBanRepositoryMock = new Mock<IPhongBanRepository>();
        _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
        _mapperMock = new Mock<IMapper>();
        _handlerMock = new GetQuaTrinhNhanSuQueryHandler(_mapperMock.Object
            , _quaTrinhNhanSuRepositoryMock.Object            
            , _phongBanRepositoryMock.Object
            , _chucDanhRepositoryMock.Object
            , _chucVuRepositoryMock.Object
            , _nhanVienRepositoryMock.Object
            , _thongTinQuaTrinhNhanSuRepositorryMock.Object);
    }
    [Test]
    public async Task GetEntity_QuaTrinhNhanSu_ReturnTrue()
    {
        var query = new GetQuaTrinhNhanSuQuery("cf59fedb4dd74fe483ccb1c15c23b72f");
     
        var dataNv = new NhanVienEntity
        {
            ID = "cf59fedb4dd74fe483ccb1c15c23b72f",
            ChucVuID = 1,
            DaCoHopDong = true,
            DiaChiLienLac= "string",
            Email = "phucnghi@gmail",
            HoVaTen = "Phạm Phúc Nghị",
            MaSoThue = "mst123",
            NgayVaoCongTy = DateTime.Now.AddMonths(-5),
            PasswordHash = "3fawefuihawuehfiuu23f2",
            SoDienThoaiLienLac = "0123456789",
            SoTaiKhoan = "TP12345",
            TenNganHang = "TPBank",
            TinhTrangLamViecID = 1,
        };
        var dataPb = new PhongBanEntity
        {
            ID = 1,
            Name = "Phòng ban 1"
        };
        var dataCv = new ThongTinChucVuEntity
        {
            ID = 1,
            Name = "Chức vụ 1"
        };
        var dataCd = new ThongTinChucDanhEntity
        {
            ID = 1,
            Name = "Chức Danh 1"
        };
        var dataLqt = new ThongTinQuaTrinhNhanSuEntity
        {
            ID = 1,
            Name = "Thăng tiến"
        };

        var expectedEntity = new QuaTrinhNhanSuEntity
        {
                ID = "fes123",
                LoaiQuaTrinhID = 1,
                PhongBanID = 1,
                ChucDanhID = 1,
                ChucVuID = 1,
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now.AddDays(-10),
                NgayKetThuc = DateTime.Now.AddDays(10)
            
        };

        var expectedDicNv = new Dictionary<string, NhanVienEntity>
        {
            {  "cf59fedb4dd74fe483ccb1c15c23b72f", dataNv }
        };
        var expectedDicPb = new Dictionary<int, PhongBanEntity>
        {
            {  1, dataPb }
        };
        var expectedDicCv = new Dictionary<int, ThongTinChucVuEntity>
        {
            {  1, dataCv }
        };
        var expectedDicCd = new Dictionary<int, ThongTinChucDanhEntity>
        {
            {  1, dataCd }
        };
        var expectedDicLqt = new Dictionary<int, ThongTinQuaTrinhNhanSuEntity>
        {
            {  1, dataLqt }
        };

        var expectedDto = new QuaTrinhNhanSuDto
        {
            ID = expectedEntity.ID,
            LoaiQuaTrinhID = expectedEntity.LoaiQuaTrinhID,
            PhongBanID = expectedEntity.PhongBanID,
            ChucDanhID = expectedEntity.ChucDanhID,
            ChucVuID = expectedEntity.ChucVuID,
            MaSoNhanVien = expectedEntity.MaSoNhanVien,
            NgayBatDau = expectedEntity.NgayBatDau,
            NgayKetThuc = expectedEntity.NgayKetThuc
        };

        _quaTrinhNhanSuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<QuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedEntity);

        _nhanVienRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataNv);
        _chucVuRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataCv);
        _chucDanhRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataCd);
        _phongBanRepositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataPb);
        _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(dataLqt);


        _mapperMock.Setup(mapper => mapper.Map<QuaTrinhNhanSuDto>(expectedEntity))
               .Returns(expectedDto);

        // Act
        var result = await _handlerMock.Handle(query, CancellationToken.None);

        // Assert
        Assert.AreEqual(expectedDto, result);

    }
}