using AutoMapper;
using Moq;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinCongTy;
using NhaMayThep.Application.ThongTinCongTy.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NhaMayThep.UnitTest.ThongTinCongTyUnitTest
{
    [TestFixture]
    public class GetAllThongTinCongTyUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IThongTinCongTyRepository> _thongTinCongTyRepositoryMock;
        private GetAllThongTinCongTyQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _thongTinCongTyRepositoryMock = new Mock<IThongTinCongTyRepository>();
            _handlerMock = new GetAllThongTinCongTyQueryHandler(_thongTinCongTyRepositoryMock.Object, _mapperMock.Object);
        }


        [Test]
        public async Task GetAllQueryHandler_ValidId_ReturnsThongTinCongTyDto()
        {
            // Arrange
            var query = new GetAllThongTinCongTyQuery();
            var expectedResult = new List<ThongTinCongTyEntity>
            {
                new ThongTinCongTyEntity
                {
                ID = "1",
                MaDoanhNghiep = 1,
                TenQuocTe = "Jack",
                TenVietTat = "TK",
                SoLuongNhanVien = 2,
                DiaChi = "17/16",
                MaSoThue = 1201,
                DienThoai = "0987654321",
                NguoiDaiDien = "TuanKiet",
                NgayHoatDong = DateTime.Now,
                DonViQuanLi = "NhaNuoc",
                LoaiHinhDoanhNghiep = "Kinh Doanh",
                TinhTrang = "HoatDong"
                }
            };

            var expectedDto = expectedResult.Select(entity => new ThongTinCongTyDto
            {
                ID = entity.ID,
                MaDoanhNghiep = entity.MaDoanhNghiep,
                TenQuocTe = entity.TenQuocTe,
                TenVietTat = entity.TenVietTat,
                SoLuongNhanVien = entity.SoLuongNhanVien,
                DiaChi = entity.DiaChi,
                MaSoThue = entity.MaSoThue,
                DienThoai = entity.DienThoai,
                NguoiDaiDien = entity.NguoiDaiDien,
                DonViQuanLi = entity.DonViQuanLi,
                LoaiHinhDoanhNghiep = entity.LoaiHinhDoanhNghiep,
                TinhTrang = entity.TinhTrang,
                NgayHoatDong = entity.NgayHoatDong
            }).ToList();


            _thongTinCongTyRepositoryMock.Setup(x => x.FindAllAsync(It.IsAny<Expression<Func<ThongTinCongTyEntity, bool>>>(), It.IsAny<CancellationToken>()))
         .ReturnsAsync(expectedResult);

            _mapperMock.Setup(m => m.Map<ThongTinCongTyDto>(It.IsAny<ThongTinCongTyEntity>()))
                .Returns<ThongTinCongTyEntity>(entity => expectedDto.FirstOrDefault(dto => dto.ID == entity.ID));

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto, result);
        }
    }
}
