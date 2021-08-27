using EzRemoteExecutor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Services.Interfaces
{
    public interface IPowerShellCommandService
    {
        Task<PowerShellResult> Execute(string command);
    }
}
