using MediatR;
using NhaMayThep.Application.ChiTietDangVien.UpdateChiTietDangVien;
using NhaMayThep.Application.ChiTietDangVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NhaMayThep.Application.Common.Interfaces;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using NhaMapThep.Domain.Common.Exceptions;

namespace NhaMayThep.Application.CapBacLuong.UpdateCapBacLuong
{
    public class UpdateCapBacLuongCommandHandler : IRequestHandler<UpdateCapBacLuongCommand, CapbacLuongDto>
    {
        private ICapBacLuongRepository _capBacLuongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCapBacLuongCommandHandler(ICapBacLuongRepository capBacLuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _capBacLuongRepository = capBacLuongRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<CapbacLuongDto> Handle(UpdateCapBacLuongCommand request, CancellationToken cancellationToken)
        {
            var capbacLuong = await _capBacLuongRepository.FindAsync(x => x.ID == request.Id, cancellationToken: cancellationToken);
            if (capbacLuong == null)
                throw new NotFoundException("Không tìm thấy ID của bậc lương");
            capbacLuong.HeSoLuong = request.HeSoLuong;
            capbacLuong.Name = request.Name;
            capbacLuong.NguoiCapNhatID = _currentUserService.UserId;
            capbacLuong.NgayCapNhat = DateTime.Now;
            _capBacLuongRepository.Update(capbacLuong);
            await _capBacLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return capbacLuong.MaptoCapBacLuongDto(_mapper);

        }

    }
}
