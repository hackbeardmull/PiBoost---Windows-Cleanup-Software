/*
 * Created by SharpDevelop.
 * User: joschua.schwab
 * Date: 18.11.2014
 * Time: 15:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PiBoost
{
	/// <summary>
	/// Description of Safari.
	/// </summary>
	public class Safari
	{
		public void SafariS()
		{
		 String userName = ("");
	     userName = Environment.UserName;
		 String safariHistory = ("C:\\Users\\" + userName + "\\AppData\\Roaming\\Apple Computer\\Safari\\History.plist");
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "Safari")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(100);  

		  
		  if(System.IO.File.Exists(safariHistory))
      	      {
				 System.IO.File.Delete(safariHistory);
				 Console.Write(" ---> Cleaning Safari...\n");
			
			   }
		}
	}
}
