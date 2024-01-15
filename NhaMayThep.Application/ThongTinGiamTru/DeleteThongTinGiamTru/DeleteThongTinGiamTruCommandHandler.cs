using AutoMapper;
using FluentValidation;
using MediatR;
using NhaMapThep.Domain.Repositories.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.ThongTinGiamTru.DeleteThongTinGiamTru
{
    public class DeleteThongTinGiamTruCommandHandler : IRequestHandler<DeleteThongTinGiamTruCommand, ThongTinGiamTruDTO>
    {
        private readonly IThongTinGiamTru _repository;
        private readonly IMapper _mapper;
        public DeleteThongTinGiamTruCommandHandler(IThongTinGiamTru repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ThongTinGiamTruDTO> Handle(DeleteThongTinGiamTruCommand request, CancellationToken cancellationToken)
        {
            var thongtingiamtru = await _repository.GetThongTinGiamTruById(request.Id,cancellationToken);
            _repository.Remove(thongtingiamtru);
            await _repository.UnitOfWork.SaveChangesAsync();
            return thongtingiamtru.MapToThongTinGiamTruDTO(_mapper);
        }
    }
}
