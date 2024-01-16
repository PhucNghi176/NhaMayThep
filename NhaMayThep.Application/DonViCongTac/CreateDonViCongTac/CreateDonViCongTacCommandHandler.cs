using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DonViCongTac.CreateDonViCongTac
{
    public class CreateDonViCongTacCommandHandler : IRequestHandler<CreateDonViCongTacCommand, int>
    {
        private IDonViCongTacRepository _donViCongTacRepository;
        public CreateDonViCongTacCommandHandler(IDonViCongTacRepository donViCongTacRepository)
        {
            _donViCongTacRepository = donViCongTacRepository;
        }
        public async Task<int> Handle(CreateDonViCongTacCommand request, CancellationToken cancellationToken)
        {
            var checkDuplication = await _donViCongTacRepository.FindAsync(x => x.Name == request.Name, cancellationToken);
            if (checkDuplication != null)
                throw new Exception("Tên đơn vị công tác đã tồn tại");

            var donViCongTac = new DonViCongTacEntity()
            {
                Name = request.Name,
                NguoiTaoID = request.NguoiTaoID,
                NgayTao = DateTime.Now
            };
            _donViCongTacRepository.Add(donViCongTac);
            await _donViCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return donViCongTac.ID;
        }
    }
}
