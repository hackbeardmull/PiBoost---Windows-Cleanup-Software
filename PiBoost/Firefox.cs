/*
 * Created by SharpDevelop.
 * User: Joschua
 * Date: 19.11.2014
 * Time: 16:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Microsoft.Win32;

namespace PiBoost
{
	/// <summary>
	/// Cleaning Firefox.
	/// </summary>
	public class Firefox
	{
		public void FirefoxF()
		{
			String userName = (""), firefoxHistory = (""), firefoxSession = (""), firefoxCrashes = (""), firefoxSessionStorage = ("");
	    userName = Environment.UserName;
		String firefoxProfile = ("C:\\Users\\" + userName + "\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles");
		if (System.IO.Directory.Exists(firefoxProfile))
		    {
		System.IO.DirectoryInfo ParentDirectory = new
		System.IO.DirectoryInfo(firefoxProfile);
		foreach (System.IO.DirectoryInfo d in ParentDirectory.GetDirectories())
		{
			firefoxHistory = (firefoxProfile + "\\" + d.Name + "\\places.sqlite");
			firefoxSession = (firefoxProfile + "\\" + d.Name + "\\sessionCheckpoints.json");
			firefoxCrashes = (firefoxProfile + "\\" + d.Name + "\\crashes");
			firefoxSessionStorage = (firefoxProfile + "\\" + d.Name + "\\sessionstore-backups");
		}
		    }
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "firefox")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(100); 
		  if (System.IO.Directory.Exists(firefoxCrashes))
		      {
		      	Directory.Delete(firefoxCrashes, true);
		      }
	      
		  if(System.IO.Directory.Exists(firefoxSessionStorage))
		         {
		         	Directory.Delete(firefoxSessionStorage, true);
		         }
		         
		  if(System.IO.File.Exists(firefoxSession))
      	      {
				 System.IO.File.Delete(firefoxSession);
				 Console.Write("Cleaning Firefox Session...\n");
				
			   }

		  
			if(System.IO.File.Exists(firefoxHistory))
      	      {
				 System.IO.File.Delete(firefoxHistory);
				 Console.Write("Cleaning Firefox... \n");
				 
			   }		  
			

		}
	}
}
