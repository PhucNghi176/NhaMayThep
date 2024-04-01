using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using NhaMayThep.Application.BaoHiemNhanVien;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.BaoHiemNhanVien.GetAll;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using NhaMapThep.Domain.Entities;

namespace TestProject1.BaoHiemNhanVienTests
{
    [TestFixture]
    public class GetAllBaoHiemNhanVienQueryHandlerTests
    {
        private GetAllBaoHiemNhanVienQueryHandler _handler;
        private Mock<IMapper> _mapperMock;
        private Mock<IBaoHiemNhanVienRepository> _baoHiemNhanVienRepositoryMock;

        [SetUp]
        public void SetUp()
        {
            _mapperMock = new Mock<IMapper>();
            _baoHiemNhanVienRepositoryMock = new Mock<IBaoHiemNhanVienRepository>();
            _handler = new GetAllBaoHiemNhanVienQueryHandler(_mapperMock.Object, _baoHiemNhanVienRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidInput_ReturnsListOfBaoHiemNhanVienDto()
        {
            // Arrange
            var fakeBaoHiemNhanVienList = new List<BaoHiemNhanVienEntity>
            {
                new BaoHiemNhanVienEntity { ID = "1", MaSoNhanVien = "MSNV001", BaoHiem = 1 },
                new BaoHiemNhanVienEntity { ID = "2", MaSoNhanVien = "MSNV002", BaoHiem = 2 }
            };

            _baoHiemNhanVienRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<BaoHiemNhanVienEntity, bool>>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(fakeBaoHiemNhanVienList);

            _mapperMock.Setup(x => x.Map<List<BaoHiemNhanVienDto>>(fakeBaoHiemNhanVienList))
                .Returns(new List<BaoHiemNhanVienDto>
                {
                    new BaoHiemNhanVienDto { ID = "1", MaSoNhanVien = "MSNV001", BaoHiem = 1 },
                    new BaoHiemNhanVienDto { ID = "2", MaSoNhanVien = "MSNV002", BaoHiem = 2 }
                });

            // Act
            var result = await _handler.Handle(new GetAllQuery(), CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "Kết quả trả về không được null");
            Assert.IsInstanceOf<List<BaoHiemNhanVienDto>>(result, "Kết quả trả về phải là một danh sách của BaoHiemNhanVienDto");
            Assert.AreEqual(2, result.Count, "Danh sách trả về phải có 2 phần tử");
        }
    }
}
