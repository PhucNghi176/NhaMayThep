using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KhenThuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhenThuong.Delete
{
    public class DeleteKhenThuongCommandHandler : IRequestHandler<DeleteKhenThuongCommand, KhenThuongDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKhenThuongRepository _khenThuongRepository;
        private readonly IMapper _mapper;

        public DeleteKhenThuongCommandHandler(IKhenThuongRepository khenThuongRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _khenThuongRepository = khenThuongRepository;
            _mapper = mapper;
        }


        public async Task<KhenThuongDto> Handle(DeleteKhenThuongCommand request, CancellationToken cancellationToken)
        {
            var k = await _khenThuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Khen Thuong not found");
            }

            k.NgayXoa = DateTime.Now;
            k.NguoiXoaID = _currentUserService.UserId;

            _khenThuongRepository.Update(k);
            await _khenThuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhenThuongDto(_mapper);
        }
    }
}
