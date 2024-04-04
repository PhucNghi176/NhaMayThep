using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep.Create;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.LoaiNghiPhep
{
    [TestFixture]
    public class CreateLoaiNghiPhepCommandHandlerTests
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ILoaiNghiPhepRepository> _loaiNghiPhepRepositoryMock;
        private Mock<ICurrentUserService> _currentUserServiceMock;

        private CreateCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _loaiNghiPhepRepositoryMock = new Mock<ILoaiNghiPhepRepository>();
            _currentUserServiceMock = new Mock<ICurrentUserService>();

            _handler = new CreateCommandHandler(
                null, 
                _loaiNghiPhepRepositoryMock.Object,
                _mapperMock.Object,
                _currentUserServiceMock.Object
            );

            _currentUserServiceMock.Setup(x => x.UserId).Returns("mockUserId");
        }

        [Test]
        public async Task Handle_GivenValidRequest_ShouldCreateLoaiNghiPhepAndReturnSuccessMessage()
        {
            var command = new CreateLoaiNghiPhepCommand
            {
                Name = "Annual Leave"
            };

            _loaiNghiPhepRepositoryMock.Setup(r => r.FindAllAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                       .ReturnsAsync(new List<LoaiNghiPhepEntity>());
            _loaiNghiPhepRepositoryMock.Setup(r => r.Add(It.IsAny<LoaiNghiPhepEntity>()));
            _loaiNghiPhepRepositoryMock.Setup(r => r.UnitOfWork.SaveChangesAsync(default)).ReturnsAsync(1);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(result);
            Assert.AreEqual("Tạo thành công", result);
            _loaiNghiPhepRepositoryMock.Verify(r => r.Add(It.IsAny<LoaiNghiPhepEntity>()), Times.Once);
            _loaiNghiPhepRepositoryMock.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Test]
        public void Handle_GivenDuplicateName_ShouldThrowDuplicationException()
        {
            var command = new CreateLoaiNghiPhepCommand
            {
                Name = "Annual Leave"
            };

            _loaiNghiPhepRepositoryMock.Setup(r => r.FindAllAsync(It.IsAny<Expression<Func<LoaiNghiPhepEntity, bool>>>(), It.IsAny<CancellationToken>()))
                                       .ReturnsAsync(new List<LoaiNghiPhepEntity> { new LoaiNghiPhepEntity { Name = "Annual Leave" } });

            Assert.ThrowsAsync<DuplicationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}
