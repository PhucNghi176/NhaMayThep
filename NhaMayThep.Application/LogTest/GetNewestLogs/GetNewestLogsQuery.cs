using MediatR;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LogTest.GetNewestLogs
{
    public class GetNewestLogsQuery : IRequest<List<string>>, IQuery
    {
        public GetNewestLogsQuery() { }

        public GetNewestLogsQuery(int lineCount)
        {
            this.lineCount = lineCount;
        }

        public int lineCount { get; set; }
    }
}
