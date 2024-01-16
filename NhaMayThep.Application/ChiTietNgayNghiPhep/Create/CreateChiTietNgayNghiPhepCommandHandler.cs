using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommandHandler : IRequestHandler<CreateChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepo _repo;
        private readonly IMapper _mapper;

        public CreateChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(CreateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nhanvien = await _repo.FindByIdAsync(request.MaSoNhanVien);
            if (nhanvien == null)
            {
                throw new NotFoundException("Nhan Vien not found");
            }

            var ctnp = new ChiTietNgayNghiPhepEntity()
            {
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhep = request.LoaiNghiPhep,
                TongSoGio = request.TongSoGio,
                SoGioDaNghiPhep = request.SoGioDaNghiPhep,
                SoGioConLai = request.SoGioConLai,
                NamHieuLuoc = request.NamHieuLuoc
            };

            _repo.Add(ctnp);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ctnp.MapToChiTietNgayNghiPhepDto(_mapper);
          
        }
    }
}
