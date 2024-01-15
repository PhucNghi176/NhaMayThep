using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiHoaDon.Delete
{
    public class DeleteLoaiHoaDonCommandHandler : IRequestHandler<DeleteLoaiHoaDonCommand, bool>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public DeleteLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = await _LoaiHoaDonRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiHoaDon == null) 
            {
                throw new NotFoundException("Loai Hoa Don list is empty");
            }
            try{
                _LoaiHoaDonRepository.Remove(loaiHoaDon);
                await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return true;
            }catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
