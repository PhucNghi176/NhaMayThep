using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FillterByChucVuIDOrTinhTrangLamViecID
{
    public class FillterByChucVuIDOrTinhTrangLamViecIDQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int no { get; set; }
        public int pageSize {  get; set; }
        public int chucvuID {  get; set; }
        public int tinhtranglamviecID {  get; set; }
        public FillterByChucVuIDOrTinhTrangLamViecIDQuery() { }
        public FillterByChucVuIDOrTinhTrangLamViecIDQuery(int no, int pageSize, int chucvuID, int tinhtranglamviecID)
        {
            this.no = no;
            this.pageSize = pageSize;
            this.chucvuID = chucvuID;
            this.tinhtranglamviecID = tinhtranglamviecID;
        }
    }
}
