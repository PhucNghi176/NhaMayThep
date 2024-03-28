using AutoMapper;
using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChiTietNgayNghiPhep;
using NhaMayThep.Application.ChiTietNgayNghiPhep.Update;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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
        public async Task Handle_ValidCommand_ShouldUpdateEntityAndReturnSuccess()
        {
            // Arrange
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
                LoaiNghiPhepID = 2,
                TongSoGio = 6,
                SoGioConLai = 3,
                SoGioDaNghiPhep = 3,
                NamHieuLuc = 2025,
            };

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                   .ReturnsAsync(existingEntity);

            _repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default))
                           .ReturnsAsync(1);
            var expectedDto = new ChiTietNgayNghiPhepDto();
            _mapperMock.Setup(m => m.Map<ChiTietNgayNghiPhepDto>(existingEntity)).Returns(expectedDto);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.AreEqual(expectedDto, result);
            _repositoryMock.Verify(x => x.Update(It.IsAny<ChiTietNgayNghiPhepEntity>()), Times.Once);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

        }


        [Test]
        public void Handle_EntityNotFound_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new UpdateChiTietNgayNghiPhepCommand
            {
                Id = "nonExistingEntityId",
                LoaiNghiPhepID = 2,
                TongSoGio = 6,
                SoGioConLai = 3,
                SoGioDaNghiPhep = 3,
                NamHieuLuc = 2025,
            };

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<ChiTietNgayNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .Returns(Task.FromResult<ChiTietNgayNghiPhepEntity>(null)); // Simulating entity not found

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _handler.Handle(command, CancellationToken.None));
        }
    }
}
