using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu;
using System.Linq.Expressions;

namespace UnitTestHRM
{
    [TestFixture]
    public class Tests
    {
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<IQuaTrinhNhanSuRepository> _quaTrinhNhanSuRepositoryMock;
        private Mock<IChucDanhRepository> _chucDanhRepositoryMock;
        private Mock<IChucVuRepository> _chucVuRepositoryMock;
        private Mock<IThongTinQuaTrinhNhanSuRepository> _thongTinQuaTrinhNhanSuRepositorryMock;
        private Mock<IPhongBanRepository> _phongBanRepositoryMock;
        private Mock<INhanVienRepository> _nhanVienRepositoryMock;


        private CreateQuaTrinhNhanSuCommandHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _quaTrinhNhanSuRepositoryMock = new Mock<IQuaTrinhNhanSuRepository>();
            _chucDanhRepositoryMock = new Mock<IChucDanhRepository>();
            _chucVuRepositoryMock = new Mock<IChucVuRepository>();
            _thongTinQuaTrinhNhanSuRepositorryMock = new Mock<IThongTinQuaTrinhNhanSuRepository>();
            _phongBanRepositoryMock = new Mock<IPhongBanRepository>();
            _nhanVienRepositoryMock = new Mock<INhanVienRepository>();
            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserID");
            _handlerMock = new CreateQuaTrinhNhanSuCommandHandler(_quaTrinhNhanSuRepositoryMock.Object, _chucDanhRepositoryMock.Object
                , _chucVuRepositoryMock.Object
                , _thongTinQuaTrinhNhanSuRepositorryMock.Object
                , _phongBanRepositoryMock.Object
                , _nhanVienRepositoryMock.Object
                , _currentUserServiceMock.Object);
        }

        [Test]
        public async Task CreateValidEntity_QuaTrinhNhanSu_ReturnTrue()
        {
            var expectedResult = "Tạo thành công";

            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);

            _quaTrinhNhanSuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<QuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);


            _quaTrinhNhanSuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public async Task CreateValidEntity_QuaTrinhNhanSu_ReturnFalse()
        {
            var expectedResult = "Tạo thất bại";

            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);

            _quaTrinhNhanSuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<QuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);


            _quaTrinhNhanSuRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(0);

            var actualResult = await _handlerMock.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public async Task CreateWithUnvalidPhongBanID_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = -1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);
            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task CreateWithUnvalidChucVuID_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = 1,
                ChucVuID = -1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);
            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task CreateWithUnvalidChucDanhID_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = -1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);
            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task CreateWithUnvalidLoaiQuaTrinhID_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = -1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);
            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task CreateWithUnvalidMaSoNhanVien_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "123",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);
            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);
            Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
        [Test]
        public async Task CreateDuplicateEntity_QuaTrinhNhanSu_ThrowException()
        {
            var data = new QuaTrinhNhanSuEntity
            {
                LoaiQuaTrinhID = 1,
                ChucDanhID = 1,
                ChucVuID = 1,
                PhongBanID = 1,
                GhiChu = "Test",
                MaSoNhanVien = "cf59fedb4dd74fe483ccb1c15c23b72f",
                NgayBatDau = DateTime.Now,
                NgayKetThuc = DateTime.Now.AddDays(3),
            };
            var command = new CreateQuaTrinhNhanSuCommand(data.MaSoNhanVien, data.LoaiQuaTrinhID, data.NgayBatDau, data.NgayKetThuc, data.PhongBanID, data.ChucVuID, data.ChucDanhID, data.GhiChu);

            _phongBanRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<PhongBanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucDanhRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucDanhEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _chucVuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinChucVuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _thongTinQuaTrinhNhanSuRepositorryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<ThongTinQuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _nhanVienRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<NhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);
            _quaTrinhNhanSuRepositoryMock.Setup(x => x.AnyAsync(It.IsAny<Expression<Func<QuaTrinhNhanSuEntity, bool>>>(), It.IsAny<CancellationToken>()))
              .ReturnsAsync(true);

            Assert.ThrowsAsync<DuplicationException>(() => _handlerMock.Handle(command, CancellationToken.None));
        }
    }
}