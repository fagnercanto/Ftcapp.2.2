using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Sigef.Poc.Ftcapp.Util
{
    public static class ProcessUtil
    {
        public static void KillProcess(string sProcess)
        {
            List<Process> listKill = new List<Process>();
            Process[] proc = Process.GetProcessesByName(sProcess);
            if (proc.Length > 0)
            {
                proc.ToList().ForEach(e =>
                {
                    if (e.ProcessName.ToUpper().Equals(sProcess.ToUpper()))
                    {
                        listKill.Add(e);
                    }
                });
                if (listKill.Count > 0)
                {
                    listKill.ForEach(e => e.Kill());
                }

            }



        }
        public static void KillIEBrowserProcess()
        {
            KillProcess(CONST_PROCESS.IE_BROWSER);
        }

        public static void KillIEDriverProcess()
        {
            KillProcess(CONST_PROCESS.IE_DRIVER);

        }

        public static void ForceKill()
        {
            KillIEBrowserProcess();
            KillIEDriverProcess();

        }
    }
}
