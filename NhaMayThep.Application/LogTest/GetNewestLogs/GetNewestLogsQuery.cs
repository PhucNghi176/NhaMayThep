using MediatR;
using NhaMayThep.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhaMayThep.Application.Logs.GetNewestLogs
{
    public class GetNewestLogsQuery:IRequest<List<string>>,IQuery
    {
        public GetNewestLogsQuery() { }

        public GetNewestLogsQuery(int lineCount)
        {
            this.lineCount = lineCount;
        }

        public int lineCount { get; set; }
    }
}
