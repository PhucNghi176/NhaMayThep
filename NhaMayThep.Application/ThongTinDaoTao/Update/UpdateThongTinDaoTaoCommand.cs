﻿using NhaMayThep.Application.Common.Interfaces;
using MediatR;
using System;

namespace NhaMayThep.Application.ThongTinDaoTao.Update
{
    public class UpdateThongTinDaoTaoCommand : IRequest<ThongTinDaoTaoDto>, ICommand
    {
        public UpdateThongTinDaoTaoCommand(string id, string tenTruong, string chuyenNganh, DateTime namTotNghiep, int trinhDoVanHoa)
        {
            Id = id;
            TenTruong = tenTruong;
            ChuyenNganh = chuyenNganh;
            NamTotNghiep = namTotNghiep;
            TrinhDoVanHoa = trinhDoVanHoa;
        }

        public string Id { get; set; }
        public string TenTruong { get; set; }
        public string ChuyenNganh { get; set; }
        public DateTime NamTotNghiep { get; set; }
        public int TrinhDoVanHoa { get; set; }
    }
}
