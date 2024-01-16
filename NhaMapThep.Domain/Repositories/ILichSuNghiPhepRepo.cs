using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Entities.ConfigTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface ILichSuNghiPhepRepo : IEFRepository<LichSuNghiPhepNhanVienEntity,LichSuNghiPhepNhanVienEntity>
    {
        Task<LichSuNghiPhepNhanVienEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<LichSuNghiPhepNhanVienEntity>> FindAllAsync(CancellationToken cancellationToken = default);
    }
}
