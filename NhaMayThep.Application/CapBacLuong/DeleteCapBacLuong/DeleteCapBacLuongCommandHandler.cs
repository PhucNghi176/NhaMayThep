using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.ChiTietDangVien.DeleteChiTietDangVien;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.DeleteCapBacLuong
{
    public class DeleteCapBacLuongCommandHandler : IRequestHandler<DeleteCapBacLuongCommand, string>
    {
        private ICapBacLuongRepository _CapBacLuongRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteCapBacLuongCommandHandler(ICapBacLuongRepository CapBacLuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _CapBacLuongRepository = CapBacLuongRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteCapBacLuongCommand request, CancellationToken cancellationToken)
        {
            var capbacluong = await _CapBacLuongRepository.FindAsync(x => x.ID == request.Id, cancellationToken: cancellationToken);
            if (capbacluong == null)
                throw new NotFoundException("Không tìm thấy ID Cấp Bậc Lương");

            capbacluong.NguoiXoaID = _currentUserService.UserId;
            capbacluong.NgayXoa = DateTime.Now;

            _CapBacLuongRepository.Update(capbacluong);
            await _CapBacLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Delete Successfully";
        }
    }
}
