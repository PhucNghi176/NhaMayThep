using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllThongTinCongDoan
{
    public class GetThongTinCongDoansQueryhandler : IRequestHandler<GetThongTinCongDoansQuery, List<ThongTinCongDoanDto>>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        public GetThongTinCongDoansQueryhandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
        }
        public async Task<List<ThongTinCongDoanDto>> Handle(GetThongTinCongDoansQuery request, CancellationToken cancellationToken)
        {
            var thongtincongdoans = await _thongtinCongDoanRepository.FindAll(cancellationToken);
            if(thongtincongdoans == null || !thongtincongdoans.Any())
            {
                throw new NotFoundException("Does not any ThongTinCongDoan exists");
            }
            return thongtincongdoans.MapToThongTinCongDoanDtoList(_mapper);
        }
    }
}
