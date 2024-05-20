using MediatR;
using Microsoft.AspNetCore.Mvc;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.LogTest.DowloadFileLogs
{
    public class DowloadFileLogsQuery : IRequest<FileContentResult>, IQuery
    {
        public DowloadFileLogsQuery()
        {

        }
    }
}
