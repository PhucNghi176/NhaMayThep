//using AutoMapper;
//using MediatR;
//using NhaMapThep.Domain.Common.Exceptions;
//using NhaMapThep.Domain.Entities;
//using NhaMapThep.Domain.Repositories;
//using NhaMapThep.Domain.Repositories.ConfigTable;
//using NhaMayThep.Application.Common.Interfaces;
//using NhaMayThep.Application.ThongTinDangVien.UpdateThongTinDangVien;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NhaMayThep.Application.ThueTNCN.CreateThueTNCN
//{
//    public class CreateThueTNCNCommandHandler : IRequestHandler<CreateThueTNCNCommand, decimal>
//    {
//        private IThueTNCNRepository _thueTNCNRepository;

//        //private IBangLuongRepository _bangLuongRepository;
//        //private IGiamTruNhanVienRepository _giamTruNhanVienRepository;

//        private readonly IMapper _mapper;
//        private readonly ICurrentUserService _currentUserService;

//        public CreateThueTNCNCommandHandler(IThueTNCNRepository thueTNCNRepository, IMapper mapper, ICurrentUserService currentUserService)
//        {
//            _thueTNCNRepository = thueTNCNRepository;
//            _mapper = mapper;
//            _currentUserService = currentUserService;
//        }

//        public async Task<decimal> Handle(CreateThueTNCNCommand request, CancellationToken cancellationToken)
//        {
//            //lương cơ bản * 12 + (Tăng ca + Khen thưởng + Lương Nghỉ Phép)  = tổng thu nhập = Thu nhập chịu thuế ( ko có thu nhập miễn thuế) 
//            //Thu nhập chịu thuế - ( (GiamTruNhanVien.GiamTru.SoTienGiam * 12) + (số NPT * ThongTinGiamTruGiaCanh.ThongTinGiamTru.SoTienGiamTru * 12) + Luong Dong BH * 12 + Phí Công Đoàn * 12) = thu nhập tính thuế
//            // Thu nhập tính thuế * Thuế Suất = Thuế TNCN Phai Nop

//            //var thueTNCN = new ThueTNCNEntity()
//            //{
//            //    MaSoNhanVien 
//            //    LuongCoBan 
//            //    TongThuNhap 
//            //    ThuNhapChiuThue
//            //    ThuNhapTinhThue
//            //    GiamTruNhanVienID
//            //    ThueTNCNPhaiNop
//            //    NguoiTao
//            //    NgayTao
//            //};

//            //_thueTNCNRepository.Add(thueTNCN);
//            //if (await _thueTNCNRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0)
//            //    return 1;
//            //else
//            //    return 0;

//            return 0;
//        }
//    }
//}
