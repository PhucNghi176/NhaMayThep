using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.ChinhSachNhanSu.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ChinhSachNhanSu.Delete
{
    public class DeleteChinhSachNhanSuCommandHandler : IRequestHandler<DeleteChinhSachNhanSuCommand, ChinhSachNhanSuDto>
    {
        private readonly IChinhSachNhanSuRepository _chinhSuRepository;
        private readonly IMapper _mapper;

        public DeleteChinhSachNhanSuCommandHandler(IChinhSachNhanSuRepository chinhSachNhanSuRepository, IMapper mapper)
        {
            _chinhSuRepository = chinhSachNhanSuRepository;
            _mapper = mapper;
        }


        public async Task<ChinhSachNhanSuDto> Handle(DeleteChinhSachNhanSuCommand request, CancellationToken cancellationToken)
        {
            var chinhsach = await _chinhSuRepository.FindByIdAsync(request.Id, cancellationToken);

            if (chinhsach == null || chinhsach.NgayXoa != null) 
            {
                throw new NotFoundException("Chinh sach is not found");
            }

            chinhsach.NgayXoa = DateTime.Now;

            _chinhSuRepository.Update(chinhsach);
            await _chinhSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return chinhsach.MapToChinhSachNhanSuDto(_mapper);
        }
    }
}
