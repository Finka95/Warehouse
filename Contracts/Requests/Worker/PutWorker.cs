using FastEndpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Worker
{
    public record PutWorker
    {
        public int Id { get; init; }
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
    }
}