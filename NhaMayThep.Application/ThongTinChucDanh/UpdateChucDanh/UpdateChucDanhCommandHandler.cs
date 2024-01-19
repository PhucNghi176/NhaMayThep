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

namespace NhaMayThep.Application.ThongTinChucDanh.UpdateChucDanh
{
    public class UpdateChucDanhCommandHandler : IRequestHandler<UpdateChucDanhCommand, ChucDanhDto>
    {
        private readonly IChucDanhRepository _chucDanhRepository;
        private readonly IMapper _mapper;
        public UpdateChucDanhCommandHandler(IChucDanhRepository chucDanhRepository, IMapper mapper)
        {
            _chucDanhRepository = chucDanhRepository;
            _mapper = mapper;
        }
        public async Task<ChucDanhDto> Handle(UpdateChucDanhCommand command, CancellationToken cancellationToken)
        {
            var result = await _chucDanhRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Not found chuc danh {command.Id}");
            result.Name = command.Name;
            _chucDanhRepository.Update(result);
            await _chucDanhRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToChucDanhDto(_mapper);
        }
    }
}
