/*
 * Created by SharpDevelop.
 * User: dierk.piening
 * Date: 18.11.2014
 * Time: 14:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Microsoft.Win32;
using System.IO;

namespace PiBoost
{
	/// <summary>
	/// Chrome Cleaning Class 
	/// </summary>
	public class Chrome
	{
		public void ChromeC()
		{
		 String userName = ("");
	     userName = Environment.UserName;
		 String chromeHistory = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History");
		 String chromeHistoryJournal = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\History-journal");
		 String chromePreferences = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Preferences");
		 String chromeCurrentTabs = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Current Tabs");
		 String chromeCurrentSession = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Current Session");
		 String chromeSession = ("C:\\Users\\" + userName + "\\AppData\\Local\\Google\\Chrome\\User Data\\Default\\Session Storage");
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "chrome")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(100);
		  
		  
		  if(System.IO.Directory.Exists(chromeSession))
		     {
		  	Directory.Delete(chromeSession, true);
		  }
		  
		  if (System.IO.File.Exists(chromeHistoryJournal))
		  {
		  	System.IO.File.Delete(chromeHistoryJournal);
		  }
		  
		  if (System.IO.File.Exists(chromePreferences))
		  {
		  	System.IO.File.Delete(chromePreferences);
		  }
		  
		  if (System.IO.File.Exists(chromeCurrentTabs))
		  {
		  	System.IO.File.Delete(chromeCurrentTabs);
		  }
		  
		  if(System.IO.File.Exists(chromeCurrentSession))
		     {
		  	System.IO.File.Delete(chromeCurrentSession);
		  	Console.Write("Cleaning Chrome Session... \n");
		  	
		     }
		  System.Threading.Thread.Sleep(100);
		  
		 
		  
		  if(System.IO.File.Exists(chromeHistory))
      	      {
				 System.IO.File.Delete(chromeHistory);
				 Console.Write("Cleaning Chrome...\n");
				 
			  }
		}
	}
}
