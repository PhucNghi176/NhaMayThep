using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.DonViCongTac.GetAllDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.GetByIDDonViCongTac
{
    public class GetByIDDonViCongTacCommandHandler : IRequestHandler<GetByIDDonViCongTacCommand, DonViCongTacDto>
    {
        private readonly IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;

        public GetByIDDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository, IMapper mapper)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
        }

        public async Task<DonViCongTacDto> Handle(GetByIDDonViCongTacCommand request, CancellationToken cancellationToken)
        {

            var donViCongTac = await _donViCongTacRepository.FindAnyAsync(x => x.ID == request.ID && x.NgayXoa == null, cancellationToken);
            if( donViCongTac == null )
                throw new NotFoundException("Không tìm thấy Đơn Vị Công Tác");

            return donViCongTac.MapToDonViCongTacDto(_mapper);
    
        }
    }
}
