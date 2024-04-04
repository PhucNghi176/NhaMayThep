using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep.Update;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;

namespace NhaMayThep.Application.UnitTests.LoaiNghiPhep
{
    [TestFixture]
    public class UpdateLoaiNghiPhepCommandHandlerTest
    {
        private Mock<ILoaiNghiPhepRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<INhanVienRepository> _hanVienRepositoryMock;
        private UpdateLoaiNghiPhepHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<ILoaiNghiPhepRepository>();
            _mapperMock = new Mock<IMapper>();
            _hanVienRepositoryMock = new Mock<INhanVienRepository>();

            _handler = new UpdateLoaiNghiPhepHandler(
                _repositoryMock.Object,
                _mapperMock.Object,
                _hanVienRepositoryMock.Object
            );
        }

        [Test]
        public async Task Handle_GivenValidCommand_ShouldUpdateEntityAndReturnSuccessMessage()
        {
            // Arrange
            var command = new UpdateLoaiNghiPhepCommand
            {
                Id = 1,
                Name = "Updated Name"
            };

            var existingEntity = new LoaiNghiPhepEntity
            {
                ID = command.Id,
                Name = "Existing Name"
            };

            _repositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(existingEntity);

            _repositoryMock.Setup(r => r.FindAllAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(new List<LoaiNghiPhepEntity>());

            _repositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default))
                           .ReturnsAsync(1); // Simulate successful update

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Update thành công.", result);
            _repositoryMock.Verify(r => r.Update(It.IsAny<LoaiNghiPhepEntity>()), Times.Once);
            _repositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public void Handle_GivenDuplicateName_ShouldThrowDuplicationException()
        {
            // Arrange
            var command = new UpdateLoaiNghiPhepCommand
            {
                Id = 1,
                Name = "Duplicate Name"
            };

            var existingEntity = new LoaiNghiPhepEntity
            {
                ID = command.Id,
                Name = "Existing Name"
            };

            _repositoryMock.Setup(r => r.FindAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(existingEntity);

            _repositoryMock.Setup(r => r.FindAllAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                           .ReturnsAsync(new List<LoaiNghiPhepEntity> { new LoaiNghiPhepEntity { Name = command.Name } });

            // Assert
            Assert.ThrowsAsync<DuplicationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
