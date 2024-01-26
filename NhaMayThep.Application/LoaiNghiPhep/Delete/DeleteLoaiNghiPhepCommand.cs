﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiNghiPhep;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete;
public class DeleteLoaiNghiPhepCommand : IRequest<LoaiNghiPhepDto>, ICommand
{
    public int Id { get; set; }
    public string NguoiXoaID { get; set; }

    public DeleteLoaiNghiPhepCommand(int id)
    {
        Id = id;
    }
}
