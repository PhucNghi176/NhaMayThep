using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.LoaiTangCa.Update;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhaMayThep.Application.Common.Interfaces;
using System.Data;

namespace NhaMayThep.Application.LoaiTangCa.Update
{
    public class UpdateLoaiTangCaHandler : IRequestHandler<UpdateLoaiTangCaCommand, string>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _hanVienRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateLoaiTangCaHandler(ILoaiTangCaRepository repository, IMapper mapper, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _hanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateLoaiTangCaCommand request, CancellationToken cancellationToken)
        {
            var loaiTangCa = await _repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (loaiTangCa == null)
            {
                return $"Không tìm thấy trường hợp Loại Tăng Ca với ID : {request.Id} hoặc trường hợp này đã bị xóa.";
            }

            var dup = await _repository.AnyAsync(x => x.ID != request.Id && x.Name == request.Name && x.NguoiXoaID == null);
            if (dup == true)
            {
                throw new DuplicateNameException("Tên Loại Tăng Ca: " + request.Name + " đã tồn tại");
            }

            loaiTangCa.NguoiCapNhatID = this._currentUserService.UserId;
            loaiTangCa.NgayCapNhat = DateTime.UtcNow;
            loaiTangCa.Name = request.Name;
            _repository.Update(loaiTangCa);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật Loại Tăng Ca thành công" : "Cập nhật Loại Tăng Ca thất bại";
        }
    }
}
