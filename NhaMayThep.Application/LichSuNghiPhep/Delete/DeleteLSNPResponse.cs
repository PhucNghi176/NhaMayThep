using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.LichSuNghiPhep.Delete
{
    public class DeleteLSNPResponse
    {
        public string Message { get; set; }

        public DeleteLSNPResponse(string message)
        {
            Message = message;
        }
    }
}
