using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.CanCuocCongDan.CreateNewCanCuocCongDan;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.CapBacLuong.CreateCapBacLuong
{
        public class CreateCapBacLuongCommandHandler : IRequestHandler<CreateCapBacLuongCommand, string>
        {
            private readonly ICapBacLuongRepository _CapBacLuongRepository;
            private readonly ICurrentUserService _currentUserService;

            public CreateCapBacLuongCommandHandler(ICapBacLuongRepository CapBacLuongRepository, ICurrentUserService currentUserService)
            {
                _CapBacLuongRepository = CapBacLuongRepository;
                _currentUserService = currentUserService;
            }

            public async Task<string> Handle(CreateCapBacLuongCommand request, CancellationToken cancellationToken)
            {

            var checkDuplication = await _CapBacLuongRepository.FindAsync(x => x.HeSoLuong == request.HeSoLuong , cancellationToken);
            if (checkDuplication != null)
            {
                throw new Exception("Cấp bậc lương không được trùng nhau");
            }
            var capbacluong = new CapBacLuongEntity()
                {
                    HeSoLuong = request.HeSoLuong,
                    Name = request.Name,
                    NgayTao = DateTime.Now,
                    NguoiTaoID = _currentUserService.UserId,
                    
                };
                _CapBacLuongRepository.Add(capbacluong);
                return await _CapBacLuongRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Them Thanh Cong" : "Them That Bai";


            }
        }
 }
