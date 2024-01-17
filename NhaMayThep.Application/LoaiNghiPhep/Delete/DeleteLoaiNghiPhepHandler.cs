using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiNghiPhep.Delete
{
    public class DeleteLoaiNghiPhepHandler : IRequestHandler<DeleteLoaiNghiPhepCommand, LoaiNghiPhepDto>
    {
        private readonly ILoaiNghiPhepRepository _repository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _hanVienRepository;

        public DeleteLoaiNghiPhepHandler(ILoaiNghiPhepRepository repository, IMapper mapper, INhanVienRepository hanVienRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _hanVienRepository = hanVienRepository;
        }

        public async Task<LoaiNghiPhepDto> Handle(DeleteLoaiNghiPhepCommand request, CancellationToken cancellationToken)
        {
            var loaiNghiPhep = await _repository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (loaiNghiPhep == null)
            {
                throw new NotFoundException("LoaiNghiPhep not found for deletion");
            }
            if(loaiNghiPhep.NgayXoa != null)
            {
                throw new InvalidOperationException("This id has been deleted");
            }
            // Check if the user performing the delete operation exists
            var nhanVien = await _hanVienRepository.FindAsync(x => x.ID == request.NguoiXoaID, cancellationToken);
            if (nhanVien == null)
            {
                throw new NotFoundException("Employee performing the delete operation not found.");
            }
            if(nhanVien.NgayXoa != null)
            {
                throw new InvalidOperationException("This nhanVien has been deleted");
            }
            // Soft delete: Set NguoiXoaID and NgayXoa
            loaiNghiPhep.NguoiXoaID = request.NguoiXoaID;
            loaiNghiPhep.NgayXoa = DateTime.UtcNow;

            _repository.Update(loaiNghiPhep);
            await _repository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return loaiNghiPhep.MapToLoaiNghiPhepDto(_mapper);
        }
    }
}
