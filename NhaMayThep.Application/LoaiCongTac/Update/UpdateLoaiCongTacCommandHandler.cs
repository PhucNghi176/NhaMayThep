using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LoaiCongTac.Update
{
    public class UpdateLoaiCongTacCommandHandler : IRequestHandler<UpdateLoaiCongTacCommad, string>
    {
        private readonly ICurrentUserService _currentUserService;
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;

        public UpdateLoaiCongTacCommandHandler(ILoaiCongTacRepository loaiCongTacRepository,
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateLoaiCongTacCommad request, CancellationToken cancellationToken)
        {
            var loaiCongtac = await _loaiCongTacRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiCongtac == null || loaiCongtac.NgayXoa.HasValue)
            {
                throw new NotFoundException("Loại Công Tác Không Tồn Tại");
            }
            if (loaiCongtac.Name.Equals(request.Name))
            {
                throw new DuplicationException("Loại Công Tác Này Đã Tồn Tại");
            }
            loaiCongtac.Name = request.Name;
            loaiCongtac.NguoiCapNhatID = _currentUserService.UserId;
            loaiCongtac.NgayCapNhat = DateTime.Now;
            _loaiCongTacRepository.Update(loaiCongtac);
            await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Cập Nhật Thành Công";
        }
    }
}
