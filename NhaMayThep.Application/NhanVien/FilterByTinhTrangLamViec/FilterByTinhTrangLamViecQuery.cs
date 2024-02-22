using MediatR;
using NhaMapThep.Application.Common.Pagination;
using NhaMapThep.Domain.Repositories;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.NhanVien.FilterByTinhTrangLamViec
{
    public class FilterByTinhTrangLamViecQuery : IRequest<PagedResult<NhanVienDto>>, IQuery
    {
        public int pageNumber {  get; set; }
        public int pageSize { get; set; }
        public int tinhtranglamviecID {  get; set; }
        public FilterByTinhTrangLamViecQuery(int pageNumber, int pageSize, int tinhtranglamviecID)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.tinhtranglamviecID = tinhtranglamviecID;
        }

        public FilterByTinhTrangLamViecQuery() { }

    }
}
