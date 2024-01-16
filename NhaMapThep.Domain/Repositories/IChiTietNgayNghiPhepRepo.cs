using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IChiTietNgayNghiPhepRepo : IEFRepository<ChiTietNgayNghiPhepEntity, ChiTietNgayNghiPhepEntity>
    {
        Task<ChiTietNgayNghiPhepEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default);
        Task<List<ChiTietNgayNghiPhepEntity>> FindAllAsync(CancellationToken cancellationToken = default);
    }
}
