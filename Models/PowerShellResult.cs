using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace EzRemoteExecutor.Models
{
    public class PowerShellResult
    {
        public string Result { get; set; }
        public bool Success { get; set; }
        public Exception Exception { get; set; }

        public void Append(PSObject psObject)
        {
            Result += (psObject.ToString() + Environment.NewLine);
        }
    }
}
