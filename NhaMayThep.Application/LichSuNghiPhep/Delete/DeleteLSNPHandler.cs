using MediatR;
using NhaMapThep.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLSNPHandler : IRequestHandler<DeleteLSNPCommand,string>
    {
        private readonly ILichSuNghiPhepRepo _repo;

        public DeleteLSNPHandler(ILichSuNghiPhepRepo repo) {
            this._repo = repo;
        }

        public async Task<string> Handle(DeleteLSNPCommand request, CancellationToken cancellationToken)
        {
            var lsnp = await _repo.FindByIdAsync(request.Id, cancellationToken);
            if (lsnp != null)
            {
                _repo.Remove(lsnp);
                await _repo.UnitOfWork.SaveChangesAsync(cancellationToken);
                var response = new DeleteLSNPResponse("Record deleted successfully");
                return JsonSerializer.Serialize(response);
            }
            else 
            {
                var response = new DeleteLSNPResponse("Record not found");
                return JsonSerializer.Serialize(response);
            }
            
        }
    }
}
