﻿using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using NhaMayThep.Application.Common.Interfaces;

namespace NhaMayThep.Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
         where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;

            _logger.LogInformation("NhaMayThep Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);
            return Task.CompletedTask;
        }
    }
}
