using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.BangLuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.BangLuong.GetAll
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<BangLuongDto>>
    {
        private readonly IBangLuongRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHandler(IBangLuongRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<BangLuongDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var BangLuong = await this._repository.FindAllAsync(x => x.NgayXoa == null, cancellationToken);
            if (BangLuong == null)
                throw new NotFoundException("Không tìm thấy bất kỳ Bảng Lương nào.");
            return BangLuong.MapToBangLuongDtoList(_mapper).ToList();

        }
    }
}
