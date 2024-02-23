using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.MaDangKiCaLamViec.Create
{
    public class CreateMaDangKiCaLamHandler : IRequestHandler<CreateMaDangKiCaLamCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly IMaDangKiCaLamRepository _maDangKiCaLamRepository;
        public readonly IMapper _mapper;

        public CreateMaDangKiCaLamHandler(IMaDangKiCaLamRepository maDangKiCaLamRepository, IMapper mapper,
            ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _maDangKiCaLamRepository = maDangKiCaLamRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateMaDangKiCaLamCommand request, CancellationToken cancellationToken)
        {
            var exist = await _maDangKiCaLamRepository.FindAsync(x => x.Name == request.Name && !x.NgayXoa.HasValue, cancellationToken);
            if (exist != null)
            {
                throw new NotFoundException("Loại Đăng Kí trên đã tồn tại!");
            }

            var dangKi = new MaDangKiCaLamEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now,
            };
            _maDangKiCaLamRepository.Add(dangKi);
            await _maDangKiCaLamRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Tạo Mới Thành Công";
        }
    }
}
