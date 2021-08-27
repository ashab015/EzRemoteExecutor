using EzRemoteExecutor.Models;
using EzRemoteExecutor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Services
{
    public class CommandService : ICommandService
    {
        public async Task<CommandResult> Execute(string command)
        {
            var commandResult = new CommandResult();

            try
            {
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.UseShellExecute = false;

                startInfo.WorkingDirectory = @"C:\Windows\System32";
                startInfo.RedirectStandardOutput = true;

                startInfo.FileName = @"C:\Windows\System32\cmd.exe";
                startInfo.Verb = "runas";
                startInfo.Arguments = "/c " + command;
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo = startInfo;

                process.Start();

                process.WaitForExit();
                commandResult.Success = true;
            }
            catch (Exception ex)
            {
                commandResult.Exception = ex;
            }

            return commandResult;
        }
    }
}
