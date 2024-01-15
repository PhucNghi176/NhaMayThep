using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinPhuCap.GetAllThongTinPhuCap
{
    public class GetAllThongTinPhuCapCommandHandler : IRequestHandler<GetAllThongTinPhuCapCommand, List<ThongTinPhuCapDTO>>
    {
        private readonly IThongTinPhuCap _repository;
        private readonly IMapper _mapper;
        public GetAllThongTinPhuCapCommandHandler(IThongTinPhuCap repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinPhuCapDTO>> Handle(GetAllThongTinPhuCapCommand request, CancellationToken cancellationToken)
        {
            var thongtinphucap = await _repository.FindAllAsync(cancellationToken);
            if (thongtinphucap == null)
                throw new Exception("Không có thông tin phụ cấp");
            return thongtinphucap.MapToThongTinPhuCapDTOList(_mapper).ToList();
        }
    }
}
