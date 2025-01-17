﻿using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;

namespace NhaMayThep.Application.ThongTinCongDoan.GetById
{
    public class GetThongTinCongDoanByIdQueryHandler : IRequestHandler<GetThongTinCongDoanByIdQuery, ThongTinCongDoanDto>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        public GetThongTinCongDoanByIdQueryHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
        }
        public async Task<ThongTinCongDoanDto> Handle(GetThongTinCongDoanByIdQuery request, CancellationToken cancellationToken)
        {
            var thongtincongdoan = await _thongtinCongDoanRepository
                .FindAsync(x => x.ID.Equals(request.Id) && x.NguoiXoaID == null && !x.NgayXoa.HasValue, cancellationToken);
            if (thongtincongdoan == null)
            {
                throw new NotFoundException($"Thông tin công đoàn với Id {request.Id} không tồn tại");
            }
            return thongtincongdoan.MapToThongTinCongDoanDto(_mapper, thongtincongdoan.NhanVien.HoVaTen ?? "Trống");
        }
    }
}
