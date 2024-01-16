using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.QuaTrinhNhanSu.CreateQuaTrinhNhanSu
{
    public class CreateQuaTrinhNhanSuCommandHandler : IRequestHandler<CreateQuaTrinhNhanSuCommand, QuaTrinhNhanSuDto>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IMapper _mapper;
        public CreateQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IMapper mapper)
        {
            _mapper = mapper;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }
        
        public async Task<QuaTrinhNhanSuDto> Handle(CreateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            QuaTrinhNhanSuEntity entity = new QuaTrinhNhanSuEntity()
    {
                LoaiQuaTrinhID = command.LoaiQuaTrinhID,
                MaSoNhanVien = command.MaSoNhanVien,
                NgayBatDau = command.NgayBatDau,
                ChucDanhID = command.ChucDanhID,
                ChucVuID = command.ChucVuID,
                PhongBanID = command.PhongBanID,
                NgayKetThuc = command.NgayKetThuc,
                GhiChu = command.GhiChu
            };
            _quaTrinhNhanSuRepository.Add(entity);
            await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return entity.MapToQuaTrinhNhanSuDto(_mapper);
        }
    }
}
