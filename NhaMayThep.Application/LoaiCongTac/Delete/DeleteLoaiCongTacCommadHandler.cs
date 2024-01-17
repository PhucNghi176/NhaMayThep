using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LoaiCongTac.Delete
{
    public class DeleteLoaiCongTacCommadHandler : IRequestHandler<DeleteLoaiCongTacCommad, string>
    {
        public readonly ILoaiCongTacRepository _loaiCongTacRepository;
        public readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public DeleteLoaiCongTacCommadHandler(ILoaiCongTacRepository loaiCongTacRepository, 
            IMapper mapper, ICurrentUserService currentUserService)
        {
            _loaiCongTacRepository = loaiCongTacRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteLoaiCongTacCommad request, CancellationToken cancellationToken)
        {
            var loaiCongtac = await _loaiCongTacRepository.FindAsync(x => x.ID == request.Id, cancellationToken);

          
            if(loaiCongtac is null ||loaiCongtac.NgayXoa.HasValue) 
            {
                return "Xóa Thất Bại";
            }

                loaiCongtac.NguoiXoaID = _currentUserService.UserId;
                loaiCongtac.NgayXoa = DateTime.Now;
                _loaiCongTacRepository.Update(loaiCongtac);
                await _loaiCongTacRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "Xóa Thành Công"; // Trả về true nếu quá trình xóa thành công
            }
           
        }
    }

