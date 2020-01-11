/*
 * Created by SharpDevelop.
 * User: joschua.schwab
 * Date: 20.11.2014
 * Time: 10:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;
using System.IO;

namespace PiBoost
{
	/// <summary>
	/// Description of Iron.
	/// </summary>
	public class Iron
	{
		public void IronI()
		{
		 String userName = ("");
	     userName = Environment.UserName;
		 String ironHistory = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\History");
		 String ironHistoryJournal = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\History-journal");
		 String ironPreferences = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\Preferences");
		 String ironCurrentTabs = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\Current Tabs");
		 String ironCurrentSession = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\Current Session");
		 String ironSession = ("C:\\Users\\" + userName + "\\AppData\\Local\\Chromium\\User Data\\Default\\Session Storage");
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "chrome")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(1000);
		  
		  
		  if(System.IO.Directory.Exists(ironSession))
		     {
		  	Directory.Delete(ironSession, true);
		  }
		  
		  if (System.IO.File.Exists(ironHistoryJournal))
		  {
		  	System.IO.File.Delete(ironHistoryJournal);
		  }
		  
		  if (System.IO.File.Exists(ironPreferences))
		  {
		  	System.IO.File.Delete(ironPreferences);
		  }
		  
		  if (System.IO.File.Exists(ironCurrentTabs))
		  {
		  	System.IO.File.Delete(ironCurrentTabs);
		  }
		  
		  if(System.IO.File.Exists(ironCurrentSession))
		     {
		  	System.IO.File.Delete(ironCurrentSession);
		  	Console.Write("-> Cleaning Iron Session...");
		  	System.Threading.Thread.Sleep(500);
		  	Console.Write("[ok]\n");
		     }
		  System.Threading.Thread.Sleep(1000);
		  
		  
		  
		  if(System.IO.File.Exists(ironHistory))
      	      {
				 System.IO.File.Delete(ironHistory);
				 Console.Write("-> Cleaning Iron...");
				 System.Threading.Thread.Sleep(500);
				 Console.Write("[ok]\n");
			  }
		}
	}
}
