using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommadHandler : IRequestHandler<DeleteLoaiCongTacCommad, bool>
    {
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public DeleteLoaiCongTacCommadHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteLoaiCongTacCommad request, CancellationToken cancellationToken)
        {
            var loaiCongtac = await _loaiCongTacRepository.FindAsync(x => x.ID == request.Id, cancellationToken);

            if (loaiCongtac == null)
            {
                throw new NotFoundException("Loai Cong Tac is not found");
            }

            try
            {
                _loaiCongTacRepository.Remove(loaiCongtac);
                await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return true; // Trả về true nếu quá trình xóa thành công
            }
            catch (Exception ex) 
            {
                return false;
            }
           
        }
    }
}
