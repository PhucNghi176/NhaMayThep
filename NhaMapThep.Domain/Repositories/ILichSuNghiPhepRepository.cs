using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;

public interface ILichSuNghiPhepRepository : IEFRepository<LichSuNghiPhepNhanVienEntity, LichSuNghiPhepNhanVienEntity>
{
    Task<LichSuNghiPhepNhanVienEntity> FindByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<LichSuNghiPhepNhanVienEntity> FindByMaSoNhanVienAsync(string maSoNhanVien, CancellationToken cancellationToken = default); // New method
    Task<List<LichSuNghiPhepNhanVienEntity>> FindAllAsync(CancellationToken cancellationToken = default);
}
