using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sigef.Poc.Ftcapp.WebDriver.Util
{
    public class ProcessUtil
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
            KillProcess(ConstUtil.PROCESS_IE_BROWSER);
        }

        public static void KillIEDriverProcess()
        {
            KillProcess(ConstUtil.PROCESS_IE_DRIVER);

        }

        public static void ForceKill()
        {
            KillIEBrowserProcess();
            KillIEDriverProcess();

        }

    }
}
