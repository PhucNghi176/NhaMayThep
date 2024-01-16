using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.UpdateThongTinGiamTru
{
    public class UpdateThongTinGiamTruCommandHandler : IRequestHandler<UpdateThongTinGiamTruCommand, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly IMapper _mapper;
        public UpdateThongTinGiamTruCommandHandler(IThongTinGiamTru repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinGiamTruDTO> Handle(UpdateThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.GetThongTinGiamTruById(request.ID, cancellationToken);
            if (thongtingiamtru.NgayXoa != null)
                throw new Exception("thông tin giảm trừ đã bị xóa");
            thongtingiamtru.Name = request.TenMaGiamTru ?? thongtingiamtru.Name;
            thongtingiamtru.SoTienGiamTru = request.SoTienGiamTru;
            thongtingiamtru.NguoiCapNhatID = request.NguoiCapNhatID;
            thongtingiamtru.NgayCapNhat = DateTime.UtcNow;
            _repository.Update(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
