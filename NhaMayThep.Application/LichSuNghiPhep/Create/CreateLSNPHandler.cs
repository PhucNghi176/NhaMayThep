using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Create
{
    public class CreateLSNPHandler : IRequestHandler<CreateLSNPCommand, LichSuNghiPhepDto>
    {
        private readonly ILichSuNghiPhepRepo _repository;
        private readonly IMapper _mapper;

        public CreateLSNPHandler(ILichSuNghiPhepRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LichSuNghiPhepDto> Handle(CreateLSNPCommand request, CancellationToken cancellationToken)
        {
            // Check if employees exist
            var nhanVien = await _repository.FindByIdAsync(request.MaSoNhanVien, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Nhan Vien does not exist.");
            }

            var nguoiDuyet = await _repository.FindByIdAsync(request.NguoiDuyet, cancellationToken);
            if (nguoiDuyet == null)
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
            // Map to DTO

        }
    }
}
