using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.DangKiCaLam.CheckIn;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.DangKiCaLam
{
    [TestFixture]
    public class CheckInTest
    {
        private Mock<IDangKiCaLamRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;
        private CheckInCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IDangKiCaLamRepository>();
            _mapperMock = new Mock<IMapper>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();
            _handler = new CheckInCommandHandler(_repositoryMock.Object, _mapperMock.Object, _currentUserServiceMock.Object);
        }

        [Test]
        public async Task Handle_ValidCheckIn_ShouldReturnSuccessMessage()
        {
            // Arrange
            var command = new CheckInCommand { Id = "validId" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new DangKiCaLamEntity
                {
                    ID = "validId",
                    ThoiGianCaLamBatDau = DateTime.UtcNow.AddHours(-1), // Assuming the shift started an hour ago
                    ThoiGianChamCongBatDau = null
                });

            // Mocking the UnitOfWork.SaveChangesAsync to return a positive value to simulate a successful save operation
            _repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Check-in thành công", result);
            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


        [Test]
        public void Handle_NonExistentDangKiCaLam_ShouldThrowNotFoundException()
        {
            // Arrange
            var command = new CheckInCommand { Id = "nonexistentId" };
            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((DangKiCaLamEntity)null);

            // Act & Assert
            Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Test]
        public async Task Handle_LateCheckIn_ShouldUpdateGhiChuAndReturnSuccessMessage()
        {
            // Arrange
            var command = new CheckInCommand { Id = "validIdForLateCheckIn" };
            var scheduledStartTime = DateTime.UtcNow.AddHours(-2); // Assuming the shift started 2 hours ago
            var existingDangKiCaLam = new DangKiCaLamEntity
            {
                ID = command.Id,
                MaSoNhanVien = "validMaSoNhanVien",
                ThoiGianCaLamBatDau = scheduledStartTime,
                ThoiGianChamCongBatDau = null,
                GhiChu = string.Empty // Initially, there is no note
            };

            _repositoryMock.Setup(x => x.FindAsync(It.IsAny<Expression<Func<DangKiCaLamEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(existingDangKiCaLam);

            // Mocking Update method call to ensure it's captured
            _repositoryMock.Setup(x => x.Update(It.IsAny<DangKiCaLamEntity>()))
                .Callback<DangKiCaLamEntity>(entity => existingDangKiCaLam = entity);

            _repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default(CancellationToken)))
                .ReturnsAsync(1);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Check-in thành công", result);
            Assert.IsTrue(existingDangKiCaLam.GhiChu.Contains("Check-in trễ"), "GhiChu should contain a note about the late check-in.");

            // Verifying the Update method was called with an entity whose GhiChu contains "Check-in trễ"
            _repositoryMock.Verify(x => x.Update(It.Is<DangKiCaLamEntity>(e => e.GhiChu.Contains("Check-in trễ"))), Times.Once);

            _repositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }


    }
}
