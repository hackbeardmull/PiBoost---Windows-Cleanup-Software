/*
 * Created by SharpDevelop.
 * User: joschua.schwab
 * Date: 18.11.2014
 * Time: 15:08
 */
 
using System;
using Microsoft.Win32;

namespace PiBoost
{
	/// <summary>
	/// Clean Opera
	/// </summary>
	public class Opera
	{
		public void OperaO()
		{
		 String userName = ("");
	     userName = Environment.UserName;
		 String operaHistory = ("C:\\Users\\" + userName + "\\AppData\\Roaming\\Opera Software\\Opera Stable\\History");
		 String operaSession = ("C:\\Users\\" + userName + "\\AppData\\Roaming\\Opera Software\\Opera Stable\\session.db");
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "opera")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(100);  
		  if(System.IO.File.Exists(operaSession))
		  {
		  	System.IO.File.Delete(operaSession);
		  	Console.Write(" ---> Cleaning Opera Session...\n");
		  }
		  
		  System.Threading.Thread.Sleep(100);
		  if(System.IO.File.Exists(operaHistory))
      	      {
				 System.IO.File.Delete(operaHistory);
				 Console.Write(" ---> Cleaning Opera...\n");
				 
			   }

	}
	}
}
