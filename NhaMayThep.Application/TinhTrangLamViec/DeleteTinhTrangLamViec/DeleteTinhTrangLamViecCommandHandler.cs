using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.DeleteTinhTrangLamViec
{
    public class DeleteTinhTrangLamViecCommandHandler : IRequestHandler<DeleteTinhTrangLamViecCommand, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly IMapper _mapper;
        public DeleteTinhTrangLamViecCommandHandler(ITinhTrangLamViec repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TinhTrangLamViecDTO> Handle(DeleteTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.GetTinhTrangLamViecById(request.Id, cancellationToken);
            if (tinhtranglamviec == null)
                throw new Exception("không tồn tại tình trạng làm việc này");
            tinhtranglamviec.NguoiXoaID = request.NguoiXoaID;
            tinhtranglamviec.NgayXoa = DateTime.UtcNow;
            _repository.Update(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
