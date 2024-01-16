using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Update
{
    public class UpdateChiTietNgayNghiPhepCommandHandler : IRequestHandler<UpdateChiTietNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepo _repo;
        private readonly IMapper _mapper;

        public UpdateChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(UpdateChiTietNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var existingLsnp = await _repo.FindByIdAsync(request.Id, cancellationToken);
            if (existingLsnp == null)
            {
                throw new NotFoundException($"ChiTietNghiPhep with Id {request.Id} not found.");
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
