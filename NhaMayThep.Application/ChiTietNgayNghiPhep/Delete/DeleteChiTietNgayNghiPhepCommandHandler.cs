using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChiTietNgayNghiPhep.Delete
{
    public class DeleteChiTietNgayNghiPhepCommandHandler : IRequestHandler<DeleteChiTietNgayNghiPhepCommand, ChiTietNgayNghiPhepDto>
    {
        private readonly IChiTietNgayNghiPhepRepository _repo;
        private readonly IMapper _mapper;

        public DeleteChiTietNgayNghiPhepCommandHandler(IChiTietNgayNghiPhepRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ChiTietNgayNghiPhepDto> Handle(DeleteChiTietNgayNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException($"ChiTietNgayNghiPhep with ID {request.Id} not found.");
            }

            entity.NguoiXoaID = request.NguoiXoaID;
            entity.NgayXoa = DateTime.Now;

            _repo.Update(entity);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ChiTietNgayNghiPhepDto>(entity);
        }
    }
}
