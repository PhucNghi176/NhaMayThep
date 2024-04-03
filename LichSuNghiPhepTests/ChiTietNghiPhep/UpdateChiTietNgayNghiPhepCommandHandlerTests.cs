using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Entities;
using System;
using System.Linq.Expressions;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Update;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.UnitTest.ChiTietNghiPhep
{
    public class UpdateChiTietNgayNghiPhepCommandHandlerTests
    {
        private Mock<IChiTietNgayNghiPhepRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepoMock;
        private UpdateChiTietNgayNghiPhepCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IChiTietNgayNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _loaiNghiPhepRepoMock = new Mock<ILoaiNghiPhepRepository>();

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
            _handler = new UpdateChiTietNgayNghiPhepCommandHandler(_repositoryMock.Object, _mapperMock.Object, _currentUserServiceMock.Object, _loaiNghiPhepRepoMock.Object);
        }

        [Test]
        public async Task Handle_GivenValidCommand_ShouldUpdateEntityAndReturnSuccessMessage()
        {
            var command = new UpdateChiTietNgayNghiPhepCommand
            {
                Id = "existingEntityId",
                LoaiNghiPhepID = 1,
                TongSoGio = 5,
                SoGioConLai = 2,
                SoGioDaNghiPhep = 3,
                NamHieuLuc = 2024,
            };

            var existingEntity = new ChiTietNgayNghiPhepEntity
            {
                ID = command.Id,
                LoaiNghiPhepID = 2, // Different ID to simulate update
                TongSoGio = 6,
                SoGioConLai = 3,
                SoGioDaNghiPhep = 3,
                NamHieuLuc = 2025,
            };

            _repositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(existingEntity);

            _loaiNghiPhepRepoMock.Setup(r => r.AnyAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                 .ReturnsAsync(true); // Ensures LoaiNghiPhep exists

            _repositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default))
                           .ReturnsAsync(1); // Simulates successful save

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.AreEqual("Cập nhật chi tiết ngày nghỉ phép thành công.", result);
            _repositoryMock.Verify(r => r.Update(It.Is<ChiTietNgayNghiPhepEntity>(e =>
                e.ID == command.Id &&
                e.LoaiNghiPhepID == command.LoaiNghiPhepID &&
                e.TongSoGio == command.TongSoGio &&
                e.SoGioConLai == command.SoGioConLai &&
                e.SoGioDaNghiPhep == command.SoGioDaNghiPhep &&
                e.NamHieuLuc == command.NamHieuLuc
            )), Times.Once);
            _repositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }
    }
}
