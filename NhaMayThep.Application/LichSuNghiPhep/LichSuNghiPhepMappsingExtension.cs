using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.LoaiNghiPhep;
using NhaMayThep.Application.ThongTinGiamTruGiaCanh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep
{
    public static class LichSuNghiPhepMappsingExtension
    {
        public static LichSuNghiPhepDto MapToLichSuNghiPhepDto(this LichSuNghiPhepNhanVienEntity projectfrom, IMapper mapper)
        {
            return mapper.Map<LichSuNghiPhepDto>(projectfrom);

        }
        public static List<LichSuNghiPhepDto> MapToLichSuNghiPhepDtoList(this IEnumerable<LichSuNghiPhepNhanVienEntity> projectFrom, IMapper mapper)
           => projectFrom.Select(x => x.MapToLichSuNghiPhepDto(mapper)).ToList();

        public static LichSuNghiPhepDto MapToLichSuNghiPhepDto(
            this LichSuNghiPhepNhanVienEntity entity,
            IMapper mapper,
            string nhanvien,
            string loainghipheps)
        {
            var dto = mapper.Map<LichSuNghiPhepDto>(entity);
            dto.NhanVien = nhanvien;
            dto.LoaiNghiPhep = loainghipheps;
            return dto;
        }
        public static List<LichSuNghiPhepDto> MapToLichSuNghiPhepDtoList(
            this IEnumerable<LichSuNghiPhepNhanVienEntity> entities,
            IMapper mapper,
            Dictionary<string, string> nhanviens,
            Dictionary<int, string> loainghipheps)
            => entities.Select(x => x.MapToLichSuNghiPhepDto(mapper,
                nhanviens.ContainsKey(x.MaSoNhanVien) ? nhanviens[x.ID] : "Trống",
                loainghipheps.ContainsKey(x.LoaiNghiPhepID) ? loainghipheps[x.LoaiNghiPhepID] : "Trống")).ToList();
    }
}