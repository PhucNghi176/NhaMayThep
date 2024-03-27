using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiHoaDon.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1.LoaiHoaDonTest
{
    public class DeleteLoaiHoaDonCommandHandlerTests
    {
        private Mock<ILoaiHoaDonRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<ICurrentUserService> _mockCurrentUser;
        private DeleteLoaiHoaDonCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ILoaiHoaDonRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockCurrentUser = new Mock<ICurrentUserService>();

            _handler = new DeleteLoaiHoaDonCommandHandler(_mockRepository.Object, _mockMapper.Object, _mockCurrentUser.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnsSuccessMessage()
        {
            // Arrange
            var command = new DeleteLoaiHoaDonCommand  (1); // Assuming id = 1 is a valid id

            // Simulating data retrieval from repository
            var loaiHoaDonEntity = new LoaiHoaDonEntity() { ID = 1, NgayXoa = null, Name= "Ký Hợp Đồng" /* or DateTime.MinValue */ };
            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(loaiHoaDonEntity);

            // Simulating successful save
            _mockRepository.Setup(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1); // Assuming one entity saved

            // Simulating current user
            _mockCurrentUser.Setup(user => user.UserId).Returns("SomeUserId");

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thành Công", result);
            _mockRepository.Verify(repo => repo.Update(It.IsAny<LoaiHoaDonEntity>()), Times.Once);
            _mockRepository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
            Assert.AreEqual("SomeUserId", loaiHoaDonEntity.NguoiXoaID); // Ensuring correct user ID set
            Assert.NotNull(loaiHoaDonEntity.NgayXoa); // Ensuring deletion date is set
        }

        [Test]
        public async Task Handle_EntityNotFound_ReturnsFailureMessage()
        {
            // Arrange
            var command = new DeleteLoaiHoaDonCommand (2); // Assuming id = 2 does not exist

            // Simulating no entity found in repository
            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync((LoaiHoaDonEntity)null);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại", result);
            _mockRepository.Verify(repo => repo.Update(It.IsAny<LoaiHoaDonEntity>()), Times.Never);
            _mockRepository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Test]
        public async Task Handle_EntityAlreadyDeleted_ReturnsFailureMessage()
        {
            // Arrange
            var command = new DeleteLoaiHoaDonCommand (3); // Assuming id = 3 is already deleted

            // Simulating entity already deleted in repository
            var loaiHoaDonEntity = new LoaiHoaDonEntity { ID = 3, NgayXoa = DateTime.Now , Name = "Du lịch" };
            _mockRepository.Setup(repo => repo.FindAsync(It.IsAny<Expression<Func<LoaiHoaDonEntity, bool>>>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(loaiHoaDonEntity);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.AreEqual("Xóa Thất Bại", result);
            _mockRepository.Verify(repo => repo.Update(It.IsAny<LoaiHoaDonEntity>()), Times.Never);
            _mockRepository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

    }
}
