using AutoMapper;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LuongCongNhat.Delete
{
    public class DeleteLuongCongNhatCommandHandler : IRequestHandler<DeleteLuongCongNhatCommand, string>
    {
        private ILuongCongNhatRepository _LuongCongNhatRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public DeleteLuongCongNhatCommandHandler(ILuongCongNhatRepository LuongCongNhatRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _LuongCongNhatRepository = LuongCongNhatRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteLuongCongNhatCommand request, CancellationToken cancellationToken)
        {

            var LuongCongNhat = await _LuongCongNhatRepository.FindAsync(x => x.ID == request.ID);
            if (LuongCongNhat == null)
                throw new NotFoundException("Luong Cong Nhat is not found");

            LuongCongNhat.NguoiXoaID = _currentUserService.UserId;
            LuongCongNhat.NgayXoa = DateTime.Now;

            _LuongCongNhatRepository.Update(LuongCongNhat);
            await _LuongCongNhatRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return "Delete Successfully";
        }
    }
}