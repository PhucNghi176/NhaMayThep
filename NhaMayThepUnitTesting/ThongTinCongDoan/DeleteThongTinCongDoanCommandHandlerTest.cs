using Moq;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinCongDoan.DeleteThongTinCongDoan;
using NhaMayThep.Infrastructure.Persistence;
using NhaMayThep.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThepUnitTesting.ThongTinCongDoan
{
    public class DeleteThongTinCongDoanCommandHandlerTest
    {
        public Mock<IThongTinCongDoanRepository> _thongtincongdoanRepositoryMock;
        public Mock<ICurrentUserService> _currentUserMock;
        public DeleteThongTinCongDoanCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            _thongtincongdoanRepositoryMock = new Mock<IThongTinCongDoanRepository>();
            _currentUserMock = new Mock<ICurrentUserService>();
            _handler = new DeleteThongTinCongDoanCommandHandler(
                _thongtincongdoanRepositoryMock.Object,
                _currentUserMock.Object);
        }
        [Test]
        public async Task Handler_Should_Return_NotFound()
        {
            //Arrange
            var command = new DeleteThongTinCongDoanCommand(id: "invalidId");

            _thongtincongdoanRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((ThongTinCongDoanEntity?)null);
            //Act
            async Task<string> result() => await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.ThrowsAsync<NotFoundException>(result);
        }
        [Test]
        public async Task Handler_Should_Return_Success()
        {
            //Arrange
            var command = new DeleteThongTinCongDoanCommand(id: "validId");
            var exceptedmessage = "Xóa thông tin công đoàn thành công";
            var congdoan = new ThongTinCongDoanEntity
            {
                ID = "validId",
                NhanVienID = "validNhanVien",
                NhanVien = null,
                ThuKiCongDoan = true,
                NgayGiaNhap = DateTime.Now
            };
            var a=_thongtincongdoanRepositoryMock.Setup(
                x => x.FindAsync(It.IsAny<Expression<Func<ThongTinCongDoanEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(congdoan);
            _thongtincongdoanRepositoryMock.Setup(x => x.Update(It.IsAny<ThongTinCongDoanEntity>()))
              .Callback<ThongTinCongDoanEntity>(entity =>
              {
                  Assert.That(true, "isEqual", congdoan.ID, entity.ID);
                  Assert.That(true, "isEqual", congdoan.NhanVienID, entity.NhanVienID);
                  Assert.That(true, "isEqual", congdoan.ThuKiCongDoan, entity.ThuKiCongDoan);
              });
            _thongtincongdoanRepositoryMock.Setup(
                x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None)).ReturnsAsync(1);
            //Act
            var result= await _handler.Handle(command, CancellationToken.None);
            //Assert
            Assert.That(true, "isEqual" ,result, exceptedmessage);        
            _thongtincongdoanRepositoryMock.Verify(x => x.Update(It.IsAny<ThongTinCongDoanEntity>()), Times.Once);
            _thongtincongdoanRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
