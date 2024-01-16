using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepHandler : IRequestHandler<DeleteLoaiNghiPhepCommand, LoaiNghiPhepDto>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        public DeleteLoaiNghiPhepHandler(ILoaiNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoaiNghiPhepDto> Handle(DeleteLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var loaiNghiPhep = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiNghiPhep == null)
            {
                throw new NotFoundException("LoaiNghiPhep not found for deletion");
            }
            _repository.Remove(loaiNghiPhep);
            await _repository.UnitOfWork.SaveChangesAsync();
            return loaiNghiPhep.MapToLoaiNghiPhepDto(_mapper);
        }
    }
}