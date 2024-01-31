﻿using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MucSanPham.Create
{
    public class CreateMucSanPhamCommandHandler : IRequestHandler<CreateMucSanPhamCommand, string>
    {
        ICurrentUserService _currentUserService;
        IMucSanPhamRepository _mucSanPhamRepository;
        public CreateMucSanPhamCommandHandler(ICurrentUserService currentUserService, IMucSanPhamRepository mucSanPhamRepository)
        {
            _currentUserService = currentUserService;
            _mucSanPhamRepository = mucSanPhamRepository;
        }
        public async Task<string> Handle(CreateMucSanPhamCommand command, CancellationToken cancellationToken)
        {
            var existName = await _mucSanPhamRepository.AnyAsync(x => x.Name.Equals(command.Name) && x.NguoiXoaID == null);
            if (existName)
            {
                throw new DuplicateNameException("Name đã tồn tại");
            }
            MucSanPhamEntity entity = new MucSanPhamEntity()
            {
                Name = command.Name,
                LuongMucSanPham = command.LuongMucSanPham,
                MucSanPhamToiDa = command.MucSanPhamToiDa,
                MucSanPhamToiThieu = command.MucSanPhamToiThieu,
                NgayTao = DateTime.UtcNow,
                NguoiTaoID = _currentUserService.UserId,
            };
            _mucSanPhamRepository.Add(entity);
            return await _mucSanPhamRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}