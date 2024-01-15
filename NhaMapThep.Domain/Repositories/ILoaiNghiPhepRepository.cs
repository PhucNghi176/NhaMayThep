using NhaMapThep.Domain.Entities.ConfigTable;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface ILoaiNghiPhepRepository : IEFRepository<LoaiNghiPhepEntity, LoaiNghiPhepEntity> // Assuming int is the ID type
    {
        Task<LoaiNghiPhepEntity?> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<LoaiNghiPhepEntity>> FindAllAsync(CancellationToken cancellationToken = default);
    }
}
