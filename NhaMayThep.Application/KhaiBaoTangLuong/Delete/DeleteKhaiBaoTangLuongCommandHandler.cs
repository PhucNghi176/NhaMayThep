using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.KhaiBaoTangLuong.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.KhaiBaoTangLuong.Delete
{
    public class DeleteKhaiBaoTangLuongCommandHandler : IRequestHandler<DeleteKhaiBaoTangLuongCommand, KhaiBaoTangLuongDto>
    {
        private readonly IKhaiBaoTangLuongRepository _khaiBaoTangLuongRepository;
        private readonly IMapper _mapper;

        public DeleteKhaiBaoTangLuongCommandHandler(IKhaiBaoTangLuongRepository khaiBaoTangLuongRepository, IMapper mapper)
        {
            _khaiBaoTangLuongRepository = khaiBaoTangLuongRepository;
            _mapper = mapper;
        }


        public async Task<KhaiBaoTangLuongDto> Handle(DeleteKhaiBaoTangLuongCommand request, CancellationToken cancellationToken)
        {
            var k = await _khaiBaoTangLuongRepository.FindByIdAsync(request.Id, cancellationToken);

            if (k == null || k.NgayXoa != null)
            {
                throw new NotFoundException("Khai bao Tang Luong is not exist");
            }

            k.NgayXoa = DateTime.Now;

            _khaiBaoTangLuongRepository.Update(k);
            await _khaiBaoTangLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return k.MapToKhaiBaoTangLuongDto(_mapper);
        }
    }
}
