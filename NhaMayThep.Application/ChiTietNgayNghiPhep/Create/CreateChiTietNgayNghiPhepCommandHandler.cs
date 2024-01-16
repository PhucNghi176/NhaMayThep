using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Create
{
    public class CreateChiTietNgayNghiPhepCommandHandler : IRequestHandler<CreateChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IMapper _mapper;
        private readonly IChiTietNgayNghiPhepRepository _repository;
        private readonly INhanVienRepository _hanVienRepository;

        public CreateChiTietNgayNghiPhepCommandHandler(IMapper mapper, IChiTietNgayNghiPhepRepository repository, INhanVienRepository hanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _hanVienRepository = hanVienRepository;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(CreateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Nhan Vien does not exist.");
            }

            var ctnp = new ChiTietNgayNghiPhepEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                TongSoGio = request.TongSoGio,
                SoGioDaNghiPhep = request.SoGioDaNghiPhep,
                SoGioConLai = request.SoGioConLai,
                NamHieuLuc = request.NamHieuLuc
            };

            _repository.Add(ctnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ctnp.MapToChiTietNgayNghiPhepDto(_mapper);
        }
    }
}
