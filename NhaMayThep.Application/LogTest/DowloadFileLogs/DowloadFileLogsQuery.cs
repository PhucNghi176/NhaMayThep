using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Logs.DowloadFileLogs
{
    public class DowloadFileLogsQuery : IRequest<FileContentResult>, IQuery
    {
        public DowloadFileLogsQuery()
        {

        }
    }
}
