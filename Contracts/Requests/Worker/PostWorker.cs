using Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Worker
{
    public record PostWorker
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
    }
}
