using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.TinhTrangLamViec.UpdateTinhTrangLamViec
{
    public class UpdateTinhTrangLamViecCommandHandler : IRequestHandler<UpdateTinhTrangLamViecCommand, TinhTrangLamViecDTO>
    {
        private readonly ITinhTrangLamViec _repository;
        private readonly IMapper _mapper;
        public UpdateTinhTrangLamViecCommandHandler(ITinhTrangLamViec repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TinhTrangLamViecDTO> Handle(UpdateTinhTrangLamViecCommand request, CancellationToken cancellationToken)
        {
            var tinhtranglamviec = await _repository.GetTinhTrangLamViecById(request.Id,cancellationToken);
            if (tinhtranglamviec == null)
                throw new Exception($"Not found tình trạng làm việc với ID : {request.Id}");
            tinhtranglamviec.Name = request.Name ?? tinhtranglamviec.Name;
            tinhtranglamviec.NguoiCapNhatID = request.NguoiCapNhatID;
            tinhtranglamviec.NgayCapNhat = DateTime.UtcNow;
            _repository.Update(tinhtranglamviec);
            await _repository.UnitOfWork.SaveChangesAsync();
            return tinhtranglamviec.MapToTinhTrangLamViecDTO(_mapper);
        }
    }
}
