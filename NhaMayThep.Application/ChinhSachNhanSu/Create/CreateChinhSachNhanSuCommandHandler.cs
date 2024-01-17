using AutoMapper;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ThongTinLuongNhanVien.Create;
using NhaMayThep.Application.ThongTinLuongNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.ChinhSachNhanSu.Create
{
    public class CreateChinhSachNhanSuCommandHandler : IRequestHandler<CreateChinhSachNhanSuCommand, ChinhSachNhanSuDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IChinhSachNhanSuRepository _chinhSuRepository;
        private readonly IMapper _mapper;

        public CreateChinhSachNhanSuCommandHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _chinhSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }


        public async Task<ChinhSachNhanSuDto> Handle(CreateChinhSachNhanSuCommand request, CancellationToken cancellationToken)
        {

            var chinhsach = new ChinhSachNhanSuEntity
            {
                Name = "",
                LoaiHinhThuc = request.LoaiHinhThuc,
                MucDo = request.MucDo,
                NgayHieuLuc = request.NgayHieuLuc,
                NoiDung = request.NoiDung,
                NgayTao = DateTime.Now,
                NguoiTaoID = _currentUserService.UserId,
            };

            _chinhSuRepository.Add(chinhsach);
            await _chinhSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return chinhsach.MapToChinhSachNhanSuDto(_mapper);
        }
    }
}
