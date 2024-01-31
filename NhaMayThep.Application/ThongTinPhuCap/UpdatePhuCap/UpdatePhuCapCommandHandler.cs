using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;

namespace NhaMayThep.Application.ThongTinPhuCap.UpdatePhuCap
{
    public class UpdatePhuCapCommandHandler : IRequestHandler<UpdatePhuCapCommand, string>
    {
        private readonly IPhuCapRepository _phuCapRepository;
        private readonly IMapper _mapper;
        public UpdatePhuCapCommandHandler(IPhuCapRepository phuCapRepository, IMapper mapper)
        {
            _phuCapRepository = phuCapRepository;
            _mapper = mapper;
        }
        public async Task<string> Handle(UpdatePhuCapCommand command, CancellationToken cancellationToken)
        {
            var result = await _phuCapRepository.FindAsync(x => x.ID == command.Id && x.NgayXoa == null, cancellationToken);
            if (result == null)
                throw new NotFoundException($"Không tìm thấy phụ cấp với id: {command.Id}");
            result.Name = command.Name;
            result.PhanTramPhuCap = command.PhanTramPhuCap;
            _phuCapRepository.Update(result);
            if (await _phuCapRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
                return "Cập nhật thành công";
            else
                return "Cập nhật thất bại";
        }
    }
}
