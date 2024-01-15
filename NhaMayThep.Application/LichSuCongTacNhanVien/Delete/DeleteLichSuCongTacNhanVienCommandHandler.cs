using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuCongTacNhanVien.Delete
{
    public class DeleteLichSuCongTacNhanVienCommandHandler : IRequestHandler<DeleteLichSuCongTacNhanVienCommand, string>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public DeleteLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSuCongTacNhanVien = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.Id.ToString(),cancellationToken);
            if(lichSuCongTacNhanVien == null || lichSuCongTacNhanVien.NgayXoa.HasValue) 
            {
               return "Delete Failed";
            }
            lichSuCongTacNhanVien.NgayXoa = new DateTime();
            _lichSuCongTacNhanVienRepository.Update(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Delete success";
        }
    }
}
