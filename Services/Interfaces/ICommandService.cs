using EzRemoteExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Services.Interfaces
{
    public interface ICommandService
    {
        Task<CommandResult> Execute(string command);
    }
}
