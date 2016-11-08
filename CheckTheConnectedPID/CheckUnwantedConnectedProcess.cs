///----------------------------------------------------------------------------------
///   Namespace:      <CheckTheConnectedPID>
///   Class:          <CheckUnwantedConnectedProcess>
///   Description:    <This Class is used to extract the Current Connected process>
///   Author:         <Preetam Ramdhave>                    Date: <2-OCT-2016>
///   Notes:          <This class will give me all the procoess via netstat and get the 
///                    this class will refine the data and give us the proper data.>
///   Revision History:
///   Name:           Date:        Description:
///----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
namespace CheckTheConnectedPID
{
    public class CheckUnwantedConnectedProcess
    {
        /// <summary>
        /// This function will get the current ip address and the process connected 
        /// associated with it. 
        /// </summary>
        /// <returns></returns>
        public string GetCurrectProcessData()
        {
         

            StringBuilder networkData = null;
          

            using (Process proc = new Process())
            {
                proc.StartInfo = new ProcessStartInfo
                {
                    FileName = "netstat.exe",
                    Arguments = " -ano",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };
                proc.Start();
                networkData = new StringBuilder();
                while (!proc.StandardOutput.EndOfStream)
                {
                    networkData.Append(proc.StandardOutput.ReadLine());

                }
            };
           
          
            StringUtils stringUtils = new StringUtils();
            stringUtils.GenrateQuamaSeprated(networkData);
            return networkData.ToString();
        } 
    }
}
