using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.LoaiTangCa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiTangCa.Delete
{
    public class DeleteLoaiTangCaCommandHandler : IRequestHandler<DeleteLoaiTangCaCommand, string>
    {
        private readonly ILoaiTangCaRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLoaiTangCaCommandHandler(ILoaiTangCaRepository repository, IMapper mapper, INhanVienRepository hanVienRepository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _nhanVienRepository = hanVienRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteLoaiTangCaCommand request, CancellationToken cancellationToken)
        {


            var loaiTangCa = await _repository.FindAsync(x => x.ID.Equals(request.Id) && x.NgayXoa == null, cancellationToken);
            if (loaiTangCa == null)
            {
                return $"Không tìm thấy trường hợp Loại Tăng Ca với ID : {request.Id} hoặc trường hợp này đã bị xóa.";
            }

            loaiTangCa.NguoiXoaID = this._currentUserService.UserId;
            loaiTangCa.NgayXoa = DateTime.UtcNow;

            _repository.Update(loaiTangCa);
            return await _repository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Loại Tăng Ca thành công" : "Xóa Loại Tăng Ca thất bại";
        }
    }
}