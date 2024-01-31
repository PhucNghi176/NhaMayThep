using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateLoaiNghiPhepCommand, LoaiNghiPhepDto>

    {
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;


        public CreateCommandHandler(INhanVienRepository hanVienRepository, ILoaiNghiPhepRepository repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _hanVienRepository = hanVienRepository;
        }

        public async Task<LoaiNghiPhepDto> Handle(CreateLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tìm thấy");
            }

            var existingLoaiNghiPhep = await _repository.FindAllAsync(x => x.Name.ToLower() == request.Name.ToLower());
            if (existingLoaiNghiPhep.Any())
            {
                throw new DuplicateNameException($"Loại Nghỉ Phép với tên này  '{request.Name}' đã có sẵn.");
            }


            var loaiNghiPhepEntity = new LoaiNghiPhepEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                Name = request.Name,
                
            };
            _repository.Add(loaiNghiPhepEntity);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiNghiPhepEntity.MapToLoaiNghiPhepDto(_mapper);


        }

    }
}