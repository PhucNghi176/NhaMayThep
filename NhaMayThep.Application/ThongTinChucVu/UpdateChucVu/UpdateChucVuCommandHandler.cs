using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinChucVu.UpdateChucVu
{
    public class UpdateChucVuCommandHandler : IRequestHandler<UpdateChucVuCommand, ChucVuDto>
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly IMapper _mapper;
        public UpdateChucVuCommandHandler(IChucVuRepository chucVuRepository, IMapper mapper)
        {
            _chucVuRepository = chucVuRepository;
            _mapper = mapper;
        }
        public async Task<ChucVuDto> Handle(UpdateChucVuCommand command, CancellationToken cancellationToken)
        {
            var result = await _chucVuRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy chức vụ với id: {command.Id}");
            result.Name = command.Name;
            _chucVuRepository.Update(result);
            await _chucVuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToChucVuDto(_mapper);
        }
    }
}
