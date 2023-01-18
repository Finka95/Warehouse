using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Requests.Worker
{
    public record GetDeleteWorker
    {
        public int Id { get; init; }
    }
}
