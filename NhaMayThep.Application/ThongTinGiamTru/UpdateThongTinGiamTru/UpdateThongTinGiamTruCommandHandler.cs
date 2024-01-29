using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommandHandler : IRequestHandler<UpdateThongTinGiamTruCommand, string>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public UpdateThongTinGiamTruCommandHandler(IThongTinGiamTruRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _repository = repository;
            _mapper = mapper;
        }
        public UpdateThongTinGiamTruCommandHandler() { }
        public async Task<string> Handle(UpdateThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.GetThongTinGiamTruById(request.ID, cancellationToken);
            if (thongtingiamtru.NgayXoa != null || thongtingiamtru == null)
                throw new NotFoundException("thông tin giảm trừ đã bị xóa hoặc không tồn tại");
            thongtingiamtru.Name = request.TenMaGiamTru ?? thongtingiamtru.Name;
            thongtingiamtru.SoTienGiamTru = request.SoTienGiamTru;
            thongtingiamtru.NguoiCapNhatID = _currentUserService.UserId;
            thongtingiamtru.NgayCapNhat = DateTime.UtcNow;
            _repository.Update(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return $"Cập nhật thành công thông tin giảm trừ với ID : {request.ID}";
        }
    }
}
