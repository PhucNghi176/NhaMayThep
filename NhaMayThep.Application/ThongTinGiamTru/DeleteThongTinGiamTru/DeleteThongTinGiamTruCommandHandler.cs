using AutoMapper;
using FluentValidation;
using MediatR;
using NhaMapThep.Domain.Common.Exceptions;
using NhaMapThep.Domain.Repositories.ConfigTable;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommandHandler : IRequestHandler<DeleteThongTinGiamTruCommand, bool>
    {
        private readonly IThongTinGiamTruRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currenuserservice;
        public DeleteThongTinGiamTruCommandHandler(IThongTinGiamTruRepository repository, IMapper mapper, ICurrentUserService currenuserservice)
        {
            _currenuserservice = currenuserservice;
            _repository = repository;
            _mapper = mapper;
        }
        public DeleteThongTinGiamTruCommandHandler() { }
        public async Task<bool> Handle(DeleteThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.FindAsync(x => x.ID.Equals(request.Id),cancellationToken);
            if (thongtingiamtru == null || thongtingiamtru.NgayXoa != null) 
                return false;
            thongtingiamtru.NguoiXoaID =  _currenuserservice.UserId;
            thongtingiamtru.NgayXoa = DateTime.UtcNow;
            _repository.Update(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
