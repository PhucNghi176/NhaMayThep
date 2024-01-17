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
    public class DeleteLoaiCongTacCommadHandler : IRequestHandler<DeleteLoaiCongTacCommad, string>
    {
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public DeleteLoaiCongTacCommadHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteLoaiCongTacCommad request, CancellationToken cancellationToken)
        {
            var loaiCongtac = await _loaiCongTacRepository.FindAsync(x => x.ID == request.Id, cancellationToken);

            if (loaiCongtac == null)
            {
                throw new NotFoundException("Loại Công Tác không tồn tại");
            }
            if(loaiCongtac.NgayXoa.HasValue) 
            {
                return "Delete Failed";
            }

           
                loaiCongtac.NgayXoa = DateTime.Now;
                _loaiCongTacRepository.Update(loaiCongtac);
                await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Delete Success"; // Trả về true nếu quá trình xóa thành công
            }
           
        }
    }

