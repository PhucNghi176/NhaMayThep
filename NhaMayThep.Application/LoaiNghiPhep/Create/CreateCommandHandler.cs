using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateLoaiNghiPhepCommand, LoaiNghiPhepDto>

    {

        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;


        public CreateCommandHandler(ILoaiNghiPhepRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoaiNghiPhepDto> Handle(CreateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var loaiNghiPhepEntity = new LoaiNghiPhepEntity
            {
                ID = request.Id,
                Name = request.Name,
                SoGioNghiPhep = request.SoGioNghiPhep
            };
            _repository.Add(loaiNghiPhepEntity);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiNghiPhepEntity.MapToLoaiNghiPhepDto(_mapper);


        }

    }
}