using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LichSuNghiPhep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.DangKiTangCa.Delete
{
    public class DeleteDangKiTangCaHandler : IRequestHandler<DeleteDangKiTangCaCommand,DangKiTangCaDto>
    {
        private readonly IDangKiTangCaRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteDangKiTangCaHandler(IDangKiTangCaRepository repo, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<DangKiTangCaDto> Handle(DeleteDangKiTangCaCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User ID không tồn tại .");
            }


            var lsnp = await _repo.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (lsnp == null)
            {
                throw new NotFoundException($"DangKiTangCA với Id  {request.Id} không tìm thấy .");
            }

            if (lsnp.NgayXoa != null)
            {
                throw new NotFoundException("DangKiTangCA này đã bị xóa ");
            }
            lsnp.NguoiXoaID = userId;
            lsnp.NgayXoa = DateTime.Now;

            _repo.Update(lsnp);
            await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<DangKiTangCaDto>(lsnp);
        }
    }
}
