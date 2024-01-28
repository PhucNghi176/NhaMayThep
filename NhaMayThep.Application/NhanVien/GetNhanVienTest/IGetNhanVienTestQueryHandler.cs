
namespace NhaMayThep.Application.NhanVien.GetNhanVienTest
{
    public interface IGetNhanVienTestQueryHandler
    {
        Task<List<NhanVienDto>> Handle(GetNhanVienTestQueryHandler request, CancellationToken cancellationToken);
    }
}