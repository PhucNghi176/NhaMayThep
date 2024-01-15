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
    public class DeleteLichSuCongTacNhanVienCommandHandler : IRequestHandler<DeleteLichSuCongTacNhanVienCommand, bool>
    {
        private readonly ILichSuCongTacNhanVienRepository _lichSuCongTacNhanVienRepository;
        private readonly IMapper _mapper;

        public DeleteLichSuCongTacNhanVienCommandHandler(ILichSuCongTacNhanVienRepository lichSuCongTacNhanVienRepository, IMapper mapper)
        {
            _lichSuCongTacNhanVienRepository = lichSuCongTacNhanVienRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLichSuCongTacNhanVienCommand request, CancellationToken cancellationToken)
        {
            var lichSuCongTacNhanVien = await _lichSuCongTacNhanVienRepository.FindAsync(x => x.ID == request.Id.ToString(),cancellationToken);
            if(lichSuCongTacNhanVien == null) 
            {
                throw new NotFoundException("Does Not Exist!");
            }
            _lichSuCongTacNhanVienRepository.Remove(lichSuCongTacNhanVien);
            await _lichSuCongTacNhanVienRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
