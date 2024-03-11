using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using NhaMayThep.Application.ThongTinLuongNhanVien.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinLuongNhanVien.GetById
{
    public class GetThongTinLuongNhanVienByIdQueryHandler : IRequestHandler<GetThongTinLuongNhanVienByIdQuery, ThongTinLuongNhanVienDTO>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IThongTinLuongNhanVienRepository _thongTinLuongNhanVienRepository;
        private readonly IMapper _mapper;

        public GetThongTinLuongNhanVienByIdQueryHandler(IThongTinLuongNhanVienRepository thongTinLuongNhanVienRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _thongTinLuongNhanVienRepository = thongTinLuongNhanVienRepository;
            _mapper = mapper;
        }


        public async Task<ThongTinLuongNhanVienDTO> Handle(GetThongTinLuongNhanVienByIdQuery request, CancellationToken cancellationToken)
        {

            var thongtin = await _thongTinLuongNhanVienRepository.FindAsync(x => x.ID == request.Id, cancellationToken);
            if (thongtin is null || thongtin.NgayXoa.HasValue)
            {
                throw new NotFoundException("Trạng Thái không tìm thấy hoặc đã bị xóa");
            }
            return thongtin.MapToThongTinLuongNhanVienDTO(_mapper);
        }
    }
}
