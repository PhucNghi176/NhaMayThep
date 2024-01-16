using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChinhSachNhanSu.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Update
{
    public class UpdateChinhSachNhanSuCommandHandler : IRequestHandler<UpdateChinhSachNhanSuCommand, ChinhSachNhanSuDto>
    {
        private readonly IChinhSachNhanSuRepository _chinhSuRepository;
        private readonly IMapper _mapper;

        public UpdateChinhSachNhanSuCommandHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }


        public async Task<ChinhSachNhanSuDto> Handle(UpdateChinhSachNhanSuCommand request, CancellationToken cancellationToken)
        {

            var chinhsach = await _chinhSuRepository.FindByIdAsync(request.Id, cancellationToken);

            if (chinhsach == null || chinhsach.NgayTao != null)
            {
                throw new NotFoundException("Chinh sach is not found");
            }

            chinhsach.LoaiHinhThuc = string.IsNullOrEmpty(request.LoaiHinhThuc) ? chinhsach.LoaiHinhThuc : request.LoaiHinhThuc;
            chinhsach.MucDo = string.IsNullOrEmpty(request.MucDo) ? chinhsach.MucDo : request.MucDo;
            chinhsach.NoiDung = string.IsNullOrEmpty(request.NoiDung) ? chinhsach.NoiDung : request.NoiDung;
            chinhsach.NgayHieuLuc = request.NgayHieuLuc != default(DateTime) ? request.NgayHieuLuc : chinhsach.NgayHieuLuc;

            _chinhSuRepository.Update(chinhsach);
            await _chinhSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return chinhsach.MapToChinhSachNhanSuDto(_mapper);
        }
    }
}
