using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.TangCa.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TangCa.Delete
{
    public class DeleteTangCaCommandHandler : IRequestHandler<DeleteTangCaCommand, string>
    {
        private ITangCaRepository _TangCaRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteTangCaCommandHandler(ITangCaRepository TangCaRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _TangCaRepository = TangCaRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteTangCaCommand request, CancellationToken cancellationToken)
        {

            var TangCa = await _TangCaRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (TangCa == null)
                throw new NotFoundException($"Không tìm thấy bảng Tăng Ca với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            TangCa.NguoiXoaID = _currentUserService.UserId;
            TangCa.NgayXoa = DateTime.Now;

            _TangCaRepository.Update(TangCa);
            return await _TangCaRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa bảng Tăng Ca thành công" : "Xóa bảng Tăng Ca thất bại";
        }
    }
}
