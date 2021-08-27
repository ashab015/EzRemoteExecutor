using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Models
{
    public class CommandResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
    }
}
