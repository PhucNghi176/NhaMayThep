using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.DonViCongTac.CreateDonViCongTac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.DeleteDonViCongTac
{
    public class DeleteDonViCongTacCommandHandler : IRequestHandler<DeleteDonViCongTacCommand, string>
    {
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        
        public DeleteDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteDonViCongTacCommand request, CancellationToken cancellationToken)
        {
            var donViCongTac = await _donViCongTacRepository.FindAsync(x => x.ID == request.ID, cancellationToken: cancellationToken);
            if (donViCongTac == null)
                throw new NotFoundException("Don Vi Cong Tac is not found");

            donViCongTac.NguoiXoaID = _currentUserService.UserId;
            donViCongTac.NgayXoa = DateTime.Now;

            _donViCongTacRepository.Update(donViCongTac);
            await _donViCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Delete Successfully";
        }
    }
}
