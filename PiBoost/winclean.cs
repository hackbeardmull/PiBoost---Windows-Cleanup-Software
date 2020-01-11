/*
 * Created by SharpDevelop.
 * User: dierk.piening
 * Date: 20.11.2014
 * Time: 08:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.IO;
using System;
using System.IO.IsolatedStorage;

namespace PiBoost
{
	/// <summary>
	/// Description of winclean.
	/// </summary>
	public class winclean
	{
		public void wincleaner()
		{
			
			int error = 0;
			String userName = ("");
	     	userName = Environment.UserName;
	     	String tmpPath = ("C:\\Users\\" + userName + "\\AppData\\Local\\Temp");
	     	String wintmpPath = ("C:\\Windows\\Temp");
	     	Boolean dirRecu = true;
			Console.WriteLine("---> Cleaning Windows Core System <---");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Attention! **Do not shut down or power off the computer!**");
			Console.ResetColor();
			foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "exlporer.exe")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(500);
			try
			{
				Console.WriteLine("Cleaning " + tmpPath);
				System.IO.Directory.Delete(tmpPath, dirRecu);
			// new FolderTreeDeleter().DeleteFolderTree(tmpPath); (Ab Revision 1.3.9)
			}
			catch (IOException e)
			{
				// error++;
				// Console.ForegroundColor = ConsoleColor.Red;
      		   //  Console.WriteLine("#DEV Notice: IOException source: {0}", e.Source);
      		   //  Console.ResetColor();
			}
			try 
			{
				Console.WriteLine("Cleaning " + wintmpPath);
				System.IO.Directory.Delete(wintmpPath, dirRecu);
			}
			catch (IOException e)
			{
			   	error++;
   				// Console.ForegroundColor = ConsoleColor.Red;
      		    // Console.WriteLine("#DEV Notice: IOException source: {0}", e.Source);
				// Console.ResetColor();
			
			// catch (System.IO.IsolatedStorage.IsolatedStorageException b){Console.WriteLine("source:" + b);}
			
			}
			catch (System.UnauthorizedAccessException)
			{ 
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine();
				Console.WriteLine("---> Error 400XAD: Acced Denied <--- ");
				Console.WriteLine("PiBoost requires administrator to be able to perform the core system cleaning process right. ");
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Attention! Please get started with Administrator right !");
				Console.WriteLine();
				Console.ResetColor();
			}
			}
				
			// Console.WriteLine("Beim Windows cleanen traten " + error + " Fehler auf! Der Cleaning Vorgang konnte erfolgreich durgeführt werden!");
		}
	}

