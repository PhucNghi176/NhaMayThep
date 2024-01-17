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
    public class DeleteLoaiHoaDonCommandHandler : IRequestHandler<DeleteLoaiHoaDonCommand, string>
    {
        public readonly ILoaiHoaDonRepository _LoaiHoaDonRepository;
        public readonly IMapper _mapper;

        public DeleteLoaiHoaDonCommandHandler(ILoaiHoaDonRepository loaiHoaDonRepository, IMapper mapper)
        {
            _LoaiHoaDonRepository = loaiHoaDonRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteLoaiHoaDonCommand request, CancellationToken cancellationToken)
        {
            var loaiHoaDon = await _LoaiHoaDonRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiHoaDon == null) 
            {
                throw new NotFoundException("Loại Hóa Đơn Không Tồn Tại");
            }
            if (loaiHoaDon.NgayXoa.HasValue)
            {
                return "Delete Failed";
            }
           
                loaiHoaDon.NgayXoa = DateTime.Now;
                _LoaiHoaDonRepository.Update(loaiHoaDon);
                await _LoaiHoaDonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Delete Success";
           
        }
    }
}
