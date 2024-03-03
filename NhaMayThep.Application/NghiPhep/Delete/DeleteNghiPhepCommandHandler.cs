using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.NghiPhep.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NghiPhep.Delete
{
    public class DeleteNghiPhepCommandHandler : IRequestHandler<DeleteNghiPhepCommand, string>
    {
        private INghiPhepRepository _NghiPhepRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteNghiPhepCommandHandler(INghiPhepRepository NghiPhepRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _NghiPhepRepository = NghiPhepRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteNghiPhepCommand request, CancellationToken cancellationToken)
        {

            var NghiPhep = await _NghiPhepRepository.FindAsync(x => x.ID.Equals(request.ID) && x.NgayXoa == null, cancellationToken);
            if (NghiPhep == null)
                throw new NotFoundException($"Không tìm thấy Nghỉ Phép với ID : {request.ID} hoặc trường hợp này đã bị xóa.");

            NghiPhep.NguoiXoaID = _currentUserService.UserId;
            NghiPhep.NgayXoa = DateTime.Now;

            _NghiPhepRepository.Update(NghiPhep);
            return await _NghiPhepRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Nghỉ Phép thành công" : "Xóa Nghỉ Phép thất bại";
        }
    }
}
