﻿using AutoMapper;
using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinCongDoan.GetAllDeletedPaginition
{
    public class GetAllThongTinCongDoanPaginationDeletedQueryHandler : IRequestHandler<GetAllThongTinCongDoanPaginationDeletedQuery, PagedResult<ThongTinCongDoanDto>>
    {
        private readonly IThongTinCongDoanRepository _thongtinCongDoanRepository;
        private readonly IMapper _mapper;
        private readonly INhanVienRepository _nhanVienRepository;
        public GetAllThongTinCongDoanPaginationDeletedQueryHandler(
            IThongTinCongDoanRepository thongTinCongDoanRepository,
            IMapper mapper,
            INhanVienRepository nhanVienRepository)
        {
            _thongtinCongDoanRepository = thongTinCongDoanRepository;
            _mapper = mapper;
            _nhanVienRepository = nhanVienRepository;
        }
        public async Task<PagedResult<ThongTinCongDoanDto>> Handle(GetAllThongTinCongDoanPaginationDeletedQuery request, CancellationToken cancellationToken)
        {
            var thongtincongdoans = await _thongtinCongDoanRepository
                .FindAllAsync(x => x.NgayXoa.HasValue && x.NguoiXoaID != null, request.PageNumber, request.PageSize, cancellationToken);
            var nhanviens = await _nhanVienRepository
                .FindAllToDictionaryAsync(x => !x.NgayXoa.HasValue && x.NguoiXoaID == null, x => x.ID, x => x.HoVaTen, cancellationToken);
            if (thongtincongdoans == null || !thongtincongdoans.Any())
            {
                throw new NotFoundException("Không tồn tại bất kì thông tin công đoàn nào");
            }
            var resultList = thongtincongdoans.MapToThongTinCongDoanDtoList(_mapper, nhanviens);
            return PagedResult<ThongTinCongDoanDto>.Create(
                totalCount: thongtincongdoans.TotalCount,
                pageCount: thongtincongdoans.PageCount,
                pageSize: thongtincongdoans.PageSize,
                pageNumber: thongtincongdoans.PageNo,
                data: resultList);
        }
    }
}