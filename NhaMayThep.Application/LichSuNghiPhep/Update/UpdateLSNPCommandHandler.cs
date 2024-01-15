using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Update
{
    public class UpdateLSNPCommandHandler : IRequestHandler<UpdateLSNPCommand, LichSuNghiPhepDto>
    {
        private readonly ILichSuNghiPhepRepo _repo;
        private readonly IMapper _mapper;

        public UpdateLSNPCommandHandler(ILichSuNghiPhepRepo repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        public async Task<LichSuNghiPhepDto> Handle(UpdateLSNPCommand request, CancellationToken cancellationToken)
        {
            var existingLsnp = await _repo.FindByIdAsync(request.MaSoNhanVien, cancellationToken);
            if (existingLsnp == null)
            {
                throw new NotFoundException($"LichSuNghiPhepNhanVienEntity with MSNV {request.MaSoNhanVien} not found.");
            }

            existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
            existingLsnp.NgayBatDau = request.NgayBatDau;
            existingLsnp.NgayKetThuc = request.NgayKetThuc;
            existingLsnp.LyDo = request.LyDo;
            existingLsnp.NguoiDuyet = request.NguoiDuyet;

            _repo.Update(existingLsnp);

            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<LichSuNghiPhepDto>(existingLsnp);
        }
    }
}
