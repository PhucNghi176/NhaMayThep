using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiTangCa.Create
{
    public class CreateCommandHandler : IRequestHandler<CreateLoaiTangCaCommand, string>

    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILoaiTangCaRepository _loaiTangCaRepository;
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;


        public CreateCommandHandler(INhanVienRepository hanVienRepository, ILoaiTangCaRepository repository, IMapper mapper, ICurrentUserService currentUserService, ILoaiTangCaRepository loaiTangCaRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _nhanVienRepository = hanVienRepository;
            _loaiTangCaRepository = loaiTangCaRepository;
        }

        public async Task<string> Handle(CreateLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var name = await this._loaiTangCaRepository.FindAsync(x => x.Name.Equals(request.Name) && x.NgayXoa == null, cancellationToken);
            if (name != null)
                throw new NotFoundException($"Name đã tồn tại");

            var loaiTangCaEntity = new LoaiTangCaEntity
            {
                NguoiTaoID = _currentUserService?.UserId,
                Name = request.Name,
                NgayTao = DateTime.Today
            };
            _repository.Add(loaiTangCaEntity);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo Loại  Tăng Ca thành công" : "Tạo Loại Tăng Ca thất bại";


        }

    }
}
