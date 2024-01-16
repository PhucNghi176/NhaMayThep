using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNgayNghiPhepCommandHandler : IRequestHandler<UpdateChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepository _repo;
        private readonly IMapper _mapper;
        public UpdateChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(UpdateChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var existingLsnp = await _repo.FindByIdAsync(request.Id, cancellationToken);
            if (existingLsnp == null)
            {
                throw new NotFoundException($"ChiTietNghiPhep with Id {request.Id} not found.");
            }
            if(existingLsnp.NgayXoa != null)
            {
                throw new NotFoundException("This ID is deleted");
            }

            // Update properties

            existingLsnp.LoaiNghiPhepID = request.LoaiNghiPhepID;
            existingLsnp.TongSoGio = request.TongSoGio;
            existingLsnp.SoGioDaNghiPhep = request.SoGioDaNghiPhep;
            existingLsnp.SoGioConLai = request.SoGioConLai;
            existingLsnp.NamHieuLuc = request.NamHieuLuc;

            _repo.Update(existingLsnp);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChiTietNgayNghiPhepDto>(existingLsnp);
        }

    }
}
