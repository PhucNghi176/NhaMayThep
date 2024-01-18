﻿using MediatR;
namespace NhaMayThep.Application.ChiTietNgayNghiPhep.GetById
{
    public class GetChiTietNgayNghiPhepByIdQuery : IRequest<ChiTietNgayNghiPhepDto>
    {
        public string Id { get; set; }

        public GetChiTietNgayNghiPhepByIdQuery(string id)
        {
            Id = id;
        }
    }
}