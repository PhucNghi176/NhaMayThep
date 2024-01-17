using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.QuaTrinhNhanSu.UpdateQuaTrinhNhanSu
{
    public class UpdateQuaTrinhNhanSuCommandHandler : IRequestHandler<UpdateQuaTrinhNhanSuCommand>
    {
        IQuaTrinhNhanSuRepository _quaTrinhNhanSuRepository;
        IMapper _mapper;
        public UpdateQuaTrinhNhanSuCommandHandler(IQuaTrinhNhanSuRepository quaTrinhNhanSuRepository
            , IMapper mapper)
        {
            _mapper = mapper;
            _quaTrinhNhanSuRepository = quaTrinhNhanSuRepository;
        }
        public async Task Handle(UpdateQuaTrinhNhanSuCommand command, CancellationToken cancellationToken)
        {
            var entity = _quaTrinhNhanSuRepository.FindAsync(x => x.ID == command.ID).Result;
            entity.ChucDanhID = command.ChucDanhID;
            entity.ChucVuID = command.ChucVuID;
            entity.LoaiQuaTrinhID = command.LoaiQuaTrinhID;
            entity.GhiChu = command.GhiChu;
            entity.NgayKetThuc = command.NgayKetThuc;
            entity.PhongBanID = command.PhongBanID;
            _quaTrinhNhanSuRepository.Update(entity);
            await _quaTrinhNhanSuRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
