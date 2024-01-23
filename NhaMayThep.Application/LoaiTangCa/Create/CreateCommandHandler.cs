using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiTangCa.Create;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateLoaiTangCaCommand, LoaiTangCaDto>

    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;


        public CreateCommandHandler(INhanVienRepository hanVienRepository, ILoaiTangCaRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _nhanVienRepository = hanVienRepository;
        }

        public async Task<LoaiTangCaDto> Handle(CreateLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID not found.");
            }
            var loaiTangCaEntity = new LoaiTangCaEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                Name = request.Name,

            };
            _repository.Add(loaiTangCaEntity);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiTangCaEntity.MapToLoaiTangCaDto(_mapper);


        }

    }
}
