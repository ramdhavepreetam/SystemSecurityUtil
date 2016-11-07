///-----------------------------------------------------------------
///   Namespace:      <CheckTheConnectedPID>
///   Class:          <CheckUnwantedConnectedProcess>
///   Description:    <This Class is used to extract the Current Connected process>
///   Author:         <Preetam Ramdhave>                    Date: <2-OCT-2016>
///   Notes:          <This class will give me all the procoess via netstat and get the 
///                    this class will refine the data and give us the proper data.>
///   Revision History:
///   Name:           Date:        Description:
///----

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTheConnectedPID
{
    public class CheckUnwantedConnectedProcess
    {
public        string GetCurrectProcessData()
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "netstat.exe",
                    Arguments = " -ano",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }   
            };
            proc.Start();
            string line = string.Empty ;
            while (!proc.StandardOutput.EndOfStream)
            {
                  line += proc.StandardOutput.ReadLine();
                // do something with line
            }
          
            proc.Dispose();

            return line;
        }
    }
}
