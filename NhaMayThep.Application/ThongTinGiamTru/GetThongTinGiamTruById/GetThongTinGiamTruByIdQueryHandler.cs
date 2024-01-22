using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetThongTinGiamTruById
{
    public class GetThongTinGiamTruByIdQueryHandler : IRequestHandler<GetThongTinGiamTruByIdQuery, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly IMapper _mapper;
        public GetThongTinGiamTruByIdQueryHandler(IThongTinGiamTruRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinGiamTruDTO> Handle(GetThongTinGiamTruByIdQuery request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.GetThongTinGiamTruById(request.Id, cancellationToken);
            if (thongtingiamtru == null || thongtingiamtru.NgayXoa != null)
                throw new NotFoundException($"Not Found any thong tin giam tru with ID : {request.Id} or it was deleted.");
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
