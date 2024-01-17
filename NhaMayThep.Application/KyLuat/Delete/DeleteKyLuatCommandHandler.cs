using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.KyLuat.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KyLuat.Delete
{
    public class DeleteKyLuatCommandHandler : IRequestHandler<DeleteKyLuatCommand, KyLuatDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IKyLuatRepository _kyLuatRepository;
        private readonly IMapper _mapper;

        public DeleteKyLuatCommandHandler(IKyLuatRepository kyLuatRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _kyLuatRepository = kyLuatRepository;
            _mapper = mapper;
        }


        public async Task<KyLuatDto> Handle(DeleteKyLuatCommand request, CancellationToken cancellationToken)
        {
            var k = await _kyLuatRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Ky Luat not found");
            }

            k.NguoiXoaID = _currentUserService.UserId;
            k.NgayXoa = DateTime.Now;

            _kyLuatRepository.Update(k);
            await _kyLuatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKyLuatDto(_mapper);
        }
    }
}
