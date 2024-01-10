using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string CreateToken(string userName, IList<string> roles = null);
    }
}
