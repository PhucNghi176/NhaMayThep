using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac
{
    public class UpdateDonViCongTacCommandHandler : IRequestHandler<UpdateDonViCongTacCommand, string>
    {
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository, ICurrentUserService currentUserService)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateDonViCongTacCommand request, CancellationToken cancellationToken)
        {

            var donViCongTac = await _donViCongTacRepository.FindAsync(x => x.ID == request.ID && x.NgayXoa == null, cancellationToken);
            if (donViCongTac == null)
                throw new NotFoundException("Không tìm thấy Đơn Vị Công Tác");

            var checkDuplication = await _donViCongTacRepository.AnyAsync(x => x.Name == request.Name && x.NgayXoa == null, cancellationToken);
            if (checkDuplication)
                throw new NotFoundException("Tên đơn vị công tác đã tồn tại");

            donViCongTac.Name = request.Name;
            donViCongTac.NguoiCapNhatID = _currentUserService.UserId;
            donViCongTac.NgayCapNhat = DateTime.Now;

            _donViCongTacRepository.Update(donViCongTac);
            if (await _donViCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
