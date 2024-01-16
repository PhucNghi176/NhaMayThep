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

namespace NhaMayThep.Application.LichSuNghiPhep.Create
{
    public class CreateLichSuNghiPhepCommandHandler : IRequestHandler<CreateLichSuNghiPhepCommand, LichSuNghiPhepDto>
    {
        private readonly IMapper _mapper;
        private readonly ILichSuNghiPhepRepository _repository;
        private readonly INhanVienRepository _hanVienRepository;

        public CreateLichSuNghiPhepCommandHandler(IMapper mapper, ILichSuNghiPhepRepository repository, INhanVienRepository hanVienRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _hanVienRepository = hanVienRepository;
        }


        public async Task<LichSuNghiPhepDto> Handle(CreateLichSuNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Nhan Vien does not exist.");
            }
            var nhanvien2 = await _hanVienRepository.FindAsync(x=> x.ID == request.NguoiDuyet, cancellationToken);
            if (nhanvien2 == null)
            {
                throw new NotFoundException("Nguoi Duyet does not exist.");
            }
       
            var lsnp = new LichSuNghiPhepNhanVienEntity
            {
                MaSoNhanVien = request.MaSoNhanVien,
                LoaiNghiPhepID = request.LoaiNghiPhepID,
                NgayBatDau = request.NgayBatDau,
                NgayKetThuc = request.NgayKetThuc,
                LyDo = request.LyDo,
                NguoiDuyet = request.NguoiDuyet
            };
            _repository.Add(lsnp);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return lsnp.MapToLichSuNghiPhepDto(_mapper);

        }
    }

}
