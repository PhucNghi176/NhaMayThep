﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap
{
    public class UpdatePhuCapCommandHandler : IRequestHandler<UpdatePhuCapCommand, PhuCapDto>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly IMapper _mapper;
        public UpdatePhuCapCommandHandler(IPhuCapRepository phuCapRepository, IMapper mapper)
        {
            _phuCapRepository = phuCapRepository;
            _mapper = mapper;
        }
        public async Task<PhuCapDto> Handle(UpdatePhuCapCommand command, CancellationToken cancellationToken)
        {
            var result = await _phuCapRepository.FindAsync(x => x.ID == command.Id, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Not found phu cap {command.Id}");
            result.Name = command.Name;
            result.PhanTramPhuCap = command.PhanTramPhuCap;
            _phuCapRepository.Update(result);
            await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result.MapToPhuCapDto(_mapper);
        }
    }
}