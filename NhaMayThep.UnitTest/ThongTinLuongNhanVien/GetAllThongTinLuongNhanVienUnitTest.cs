using Moq;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetAll;
using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec.GetAllTrangThaiDangKiCaLamViec;
using NhaMayThep.Application.TrangThaiDangKiCaLamViec;
using NhaMapThep.Domain.Entities;
using NhaMayThep.Application.ThongTinLuongNhanVien;
using System.Linq.Expressions;

namespace NhaMayThep.UnitTest.ThongTinLuongNhanVien
{
    public class GetAllThongTinLuongNhanVienUnitTest
    {
        private Mock<IThongTinLuongNhanVienRepository> _thongTinLuongNhanVienMock;
        private Mock<IMapper> _mapperMock;
        private GetAllThongTinLuongNhanVienQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _thongTinLuongNhanVienMock = new Mock<IThongTinLuongNhanVienRepository>();
            _mapperMock = new Mock<IMapper>();

            _handlerMock = new GetAllThongTinLuongNhanVienQueryHandler(_thongTinLuongNhanVienMock.Object, _mapperMock.Object);
        }

        [Test]
        public async Task Handle_ValidRequest_ReturnDtoList()
        {
            // Arrange

            var expectedThongTinList = new List<ThongTinLuongNhanVienEntity>
            {
                new ThongTinLuongNhanVienEntity {
                        ID = "string1",
                        MaSoNhanVien = "Test1",
                        MaSoHopDong = "Test1",
                        Loai = "TangLuong",
                        LuongCu = 100,
                        LuongMoi = 200,
                        NgayHieuLuc = DateTime.Now
                    },
                new ThongTinLuongNhanVienEntity {
                        ID = "string2",
                        MaSoNhanVien = "Test2",
                        MaSoHopDong = "Test2",
                        Loai = "TangLuong",
                        LuongCu = 100,
                        LuongMoi = 200,
                        NgayHieuLuc = DateTime.Now
                    }
            };

            var expectedThongTinDtoList = expectedThongTinList
                .Select(entity => new ThongTinLuongNhanVienDTO {
                    Id = entity.ID, MaSoNhanVien = entity.MaSoNhanVien, MaSoHopDong = entity.MaSoHopDong,
                    Loai = entity.Loai, LuongCu = entity.LuongCu, LuongMoi = entity.LuongMoi, NgayHieuLuc = entity.NgayHieuLuc
                })
                .ToList();


            _thongTinLuongNhanVienMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), CancellationToken.None))
            .ReturnsAsync(expectedThongTinList);

            _mapperMock.Setup(m => m.Map<ThongTinLuongNhanVienDTO>(It.IsAny<ThongTinLuongNhanVienEntity>()))
                .Returns<ThongTinLuongNhanVienEntity>(entity => expectedThongTinDtoList.FirstOrDefault(dto => dto.Id == entity.ID));


            // Act
            var request = new GetAllThongTinLuongNhanVienQuery();
            var result = await _handlerMock.Handle(request, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedThongTinDtoList, result);
        }

        [Test]
        public async Task Handle_EmptyList_ReturnsNotFoundException()
        {
            // Arrange
            _thongTinLuongNhanVienMock.Setup(repo => repo.FindAllAsync(It.IsAny<Expression<Func<ThongTinLuongNhanVienEntity, bool>>>(), CancellationToken.None))
                .ReturnsAsync((List<ThongTinLuongNhanVienEntity>)null);

            var request = new GetAllThongTinLuongNhanVienQuery();

            // Act & Assert
            var ex = Assert.ThrowsAsync<NotFoundException>(() => _handlerMock.Handle(request, CancellationToken.None));
            Assert.AreEqual("Danh Sách Trống", ex.Message);
        }

    }
}
