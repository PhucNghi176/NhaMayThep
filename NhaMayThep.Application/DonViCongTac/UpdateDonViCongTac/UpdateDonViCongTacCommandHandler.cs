using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.UpdateDonViCongTac
{
    public class UpdateDonViCongTacCommandHandler : IRequestHandler<UpdateDonViCongTacCommand, DonViCongTacDto>
    {
        private IDonViCongTacRepository _donViCongTacRepository;
        private IMapper _mapper;
        public UpdateDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository, IMapper mapper)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
        }
        public async Task<DonViCongTacDto> Handle(UpdateDonViCongTacCommand request, CancellationToken cancellationToken)
        {

            var donViCongTac = await _donViCongTacRepository.FindAsync(x => x.ID == request.ID);

            if (donViCongTac == null)
                throw new NotFoundException("Don Vi Cong Tac is not found");

            donViCongTac.Name = request.Name;

            _donViCongTacRepository.Update(donViCongTac);
            await _donViCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return donViCongTac.MapToDonViCongTacDto(_mapper);
        }
    }
}
