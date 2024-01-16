using NhaMapThep.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMapThep.Domain.Repositories
{
    public interface IThongTinGiamTruGiaCanhRepository: IEFRepository<ThongTinGiamTruGiaCanhEntity, ThongTinGiamTruGiaCanhEntity>,
        IRepository<ThongTinGiamTruGiaCanhEntity>
    {
    }
}
