using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.GetAllThongTinGiamTru
{
    public class GetAllThongTinGiamTruQueryHandler : IRequestHandler<GetAllThongTinGiamTruQuery, List<ThongTinGiamTruDTO>>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly IMapper _mapper;
        public GetAllThongTinGiamTruQueryHandler(IThongTinGiamTruRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ThongTinGiamTruDTO>> Handle(GetAllThongTinGiamTruQuery request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (thongtingiamtru == null)
                throw new Exception("There're no thong tin giam tru");
            /*
             * List<ThongTinGiamTruEntity> list = new List<ThongTinGiamTruEntity>();
             *foreach(var items in thongtingiamtru)
             *{
             *    if(items.NgayXoa == null)
             *        list.Add(items);  
             *}
             */
            return thongtingiamtru.MapToThongTinGiamTruDTOList(_mapper).ToList();
        }
    }
}
