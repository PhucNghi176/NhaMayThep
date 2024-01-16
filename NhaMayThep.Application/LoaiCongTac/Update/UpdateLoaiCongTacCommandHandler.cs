using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Update
{
    public class UpdateLoaiCongTacCommandHandler : IRequestHandler<UpdateLoaiCongTacCommad, LoaiCongTacDto>
    {

        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public UpdateLoaiCongTacCommandHandler(ILoaiCongTacRepository loaiCongTacRepository, IMapper mapper)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<LoaiCongTacDto> Handle(UpdateLoaiCongTacCommad request, CancellationToken cancellationToken)
        {
            var loaiCongtac = await _loaiCongTacRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if(loaiCongtac == null || loaiCongtac.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loai Cong Tac is not found");
            }
            loaiCongtac.Name = request.Name;
            loaiCongtac.NgayCapNhat = DateTime.Now;
            _loaiCongTacRepository.Update(loaiCongtac);
            await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return loaiCongtac.MapToLoaiCongTacDto(_mapper);
        }
    }
}
