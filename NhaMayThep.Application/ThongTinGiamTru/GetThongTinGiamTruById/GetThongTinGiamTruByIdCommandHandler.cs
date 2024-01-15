using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdCommandHandler : IRequestHandler<GetThongTinGiamTruByIdCommand, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruByIdCommandHandler(IThongTinGiamTru repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinGiamTruDTO> Handle(GetThongTinGiamTruByIdCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.GetThongTinGiamTruById(request.Id, cancellationToken);
            if (thongtingiamtru == null)
                throw new ArgumentException($"Not Found any thong tin giam tru with ID : {request.Id}");
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
