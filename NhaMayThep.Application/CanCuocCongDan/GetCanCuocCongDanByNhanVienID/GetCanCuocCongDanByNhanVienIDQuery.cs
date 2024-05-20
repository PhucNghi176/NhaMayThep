using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.CanCuocCongDan.GetCanCuocCongDanByNhanVienID
{
    public class GetCanCuocCongDanByNhanVienIDQuery : IRequest<CanCuocCongDanDto>, IQuery
    {
        public required string NhanVienID { get; set; }
        public GetCanCuocCongDanByNhanVienIDQuery(string nhanVienID)
        {
            NhanVienID = nhanVienID;
        }
        public GetCanCuocCongDanByNhanVienIDQuery()
        {

        }
    }
}
