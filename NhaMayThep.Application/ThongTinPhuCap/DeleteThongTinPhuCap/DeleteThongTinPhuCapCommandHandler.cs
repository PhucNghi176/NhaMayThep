using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.DeleteThongTinPhuCap
{
    public class DeleteThongTinPhuCapCommandHandler : IRequestHandler<DeleteThongTinPhuCapCommand, ThongTinPhuCapDTO>
    {
        private readonly IThongTinPhuCap _repository;
        private readonly IMapper _mapper;
        public DeleteThongTinPhuCapCommandHandler(IThongTinPhuCap repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinPhuCapDTO> Handle(DeleteThongTinPhuCapCommand request, CancellationToken cancellationToken)
        {
            var thongtinphucap = await _repository.GetThongTinPhuCapById(request.Id, cancellationToken);
            if (thongtinphucap == null)
                throw new ArgumentException($"Not Found thông tin phụ cấp với ID : {request.Id}");
            _repository.Remove(thongtinphucap);
            await _repository.UnitOfWork.SaveChangesAsync();
            return thongtinphucap.MapToThongTinPhuCapDTO(_mapper);
        }
    }
}
