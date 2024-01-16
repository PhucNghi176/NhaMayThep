using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.CreateThongTinGiamTru
{
    public class CreateThongTinGiamTruCommandHandler : IRequestHandler<CreateThongTinGiamTruCommand, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly IMapper _mapper;
        public CreateThongTinGiamTruCommandHandler(IThongTinGiamTru repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinGiamTruDTO> Handle(CreateThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = new ThongTinGiamTruEntity
            {
                ID = request.Id,
                Name = request.Name,
                SoTienGiamTru = request.SoTienGiamTru,
                NguoiTaoID = request.idUser,
                NgayTao = DateTime.UtcNow,
            };
            _repository.Add(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
