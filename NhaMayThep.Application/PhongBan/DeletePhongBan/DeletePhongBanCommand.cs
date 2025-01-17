﻿using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.PhongBan.DeletePhongBan
{
    public class DeletePhongBanCommand : IRequest<string>, ICommand
    {
        public DeletePhongBanCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
