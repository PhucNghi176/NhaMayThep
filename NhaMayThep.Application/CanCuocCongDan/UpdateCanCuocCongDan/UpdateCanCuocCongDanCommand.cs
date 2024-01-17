﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.UpdateCanCuocCongDan
{
    public class UpdateCanCuocCongDanCommand : IRequest<string>, ICommand
    {
        public UpdateCanCuocCongDanCommand(string canCuocCongDan, string hoVaTen, DateTime ngaySinh, bool gioiTinh, string quocTich, string queQuan, string diaChiThuongTru, DateTime ngayCap, string noiCap, string danToc, string tonGiao)
        {

            CanCuocCongDan = canCuocCongDan;
            HoVaTen = hoVaTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            QuocTich = quocTich;
            QueQuan = queQuan;
            DiaChiThuongTru = diaChiThuongTru;
            NgayCap = ngayCap;
            NoiCap = noiCap;
            DanToc = danToc;
            TonGiao = tonGiao;
        }


        public string CanCuocCongDan { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QuocTich { get; set; }
        public string QueQuan { get; set; }
        public string DiaChiThuongTru { get; set; }
        public DateTime NgayCap { get; set; }
        public string NoiCap { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
    }
}