using EzRemoteExecutor.Models;
using EzRemoteExecutor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Services
{
    public class PowerShellCommandService : IPowerShellCommandService
    {
        public async Task<PowerShellResult> Execute(string command)
        {
            var powerShellResult = new PowerShellResult();

            try
            {
                using (PowerShell powerShellInstance = PowerShell.Create())
                {
                    powerShellInstance.AddScript(command);

                    Collection<PSObject> result = powerShellInstance.Invoke();

                    foreach (PSObject psObject in result)
                    {
                        string ps = psObject.ToString();
                        powerShellResult.Append(ps);
                    }
                }
            }
            catch (Exception ex)
            {
                powerShellResult.Exception = ex;
            }

            return powerShellResult;
        }
    }
}
