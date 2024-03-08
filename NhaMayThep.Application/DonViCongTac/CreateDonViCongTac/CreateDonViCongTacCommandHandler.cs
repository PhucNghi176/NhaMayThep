using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommandHandler : IRequestHandler<CreateDonViCongTacCommand, string>
    {
        private IDonViCongTacRepository _donViCongTacRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository, ICurrentUserService currentUserService)
        {
            _donViCongTacRepository = donViCongTacRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateDonViCongTacCommand request, CancellationToken cancellationToken)
        {
            var checkDuplication = await _donViCongTacRepository.AnyAsync(x => x.Name == request.Name && x.NgayXoa == null, cancellationToken);
            if (checkDuplication)
                throw new NotFoundException("Tên đơn vị công tác đã tồn tại");

            var donViCongTac = new DonViCongTacEntity()
            {
                Name = request.Name,
                NguoiTaoID = _currentUserService.UserId,
                NgayTao = DateTime.Now
            };
            _donViCongTacRepository.Add(donViCongTac);
            if (await _donViCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Tạo thành công";
            else
                return "Tạo thất bại";
        }
    }
}
