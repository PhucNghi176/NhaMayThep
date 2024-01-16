using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetAllThongTinGiamTru
{
    public class GetAllThongTinGiamTruCommandHandler : IRequestHandler<GetAllThongTinGiamTruCommand, List<ThongTinGiamTruDTO>>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly IMapper _mapper;
        public GetAllThongTinGiamTruCommandHandler(IThongTinGiamTru repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinGiamTruDTO>> Handle(GetAllThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.FindAllAsync(cancellationToken);
            if (thongtingiamtru != null)
                throw new Exception("There're no thong tin giam tru");
            foreach(var items in thongtingiamtru)
            {
                if(items.NgayXoa != null)
                {
                    thongtingiamtru.Remove(items);
                }
            }
            return thongtingiamtru.MapToThongTinGiamTruDTOList(_mapper).ToList();
        }
    }
}
