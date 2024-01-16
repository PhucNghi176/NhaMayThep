using AutoMapper;
using NhaMapThep.Domain.Entities;
using NhaMapThep.Domain.Repositories;
using NhaMapThep.Infrastructure.Repositories;
using NhaMayThep.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Infrastructure.Repositories
{
    public class LichSuCongTacNhanVienRepository : RepositoryBase<LichSuCongTacNhanVienEntity, LichSuCongTacNhanVienEntity, ApplicationDbContext>, ILichSuCongTacNhanVienRepository
    {
        public LichSuCongTacNhanVienRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
    }
}
