using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NhaMayThep.Application.Common.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMapThep.Domain.Entities;

namespace NhaMayThep.Application.LuongSanPham.Create
{
    public class CreateLuongSanPhamCommand : IRequest<string>, ICommand
    {
        public CreateLuongSanPhamCommand(string maSoNhanVien, int soSanPhamLam, string mucSanPhamId, decimal tongLuong)
        {

            MaSoNhanVien = maSoNhanVien;
            SoSanPhamLam = soSanPhamLam;
            MucSanPhamID = mucSanPhamId;
            TongLuong = tongLuong;
        }


        public string MaSoNhanVien { get; set; }
        public int SoSanPhamLam { get; set; }
        public string MucSanPhamID { get; set; }
        public decimal TongLuong { get; set; }

    }
}