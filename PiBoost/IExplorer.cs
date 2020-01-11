/*
 * Created by SharpDevelop.
 * User: dierk-bent.piening
 * Date: 20.11.2014
 * Time: 14:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Diagnostics;

namespace PiBoost
{
	/// <summary>
	/// Description of IExplorer.
	/// </summary>
	public class IExplorer
	{
		public void IExplorerD()
		{
		Boolean ierecu = true;
		String userName = ("");
	    userName = Environment.UserName;
		  foreach(System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
			 {
			 if (myProc.ProcessName == "iexplore")
			 {
			 myProc.Kill();
			 }
		     } 
		  System.Threading.Thread.Sleep(15);  

		  
		  if(ierecu = true)
      	      {
				 try 
				 {
				 	System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
				 	Console.Write("Cleaning Internet Explorer...\n");
				 }
				 catch(IOException e)
				 {
				 	// error++;
					// Console.ForegroundColor = ConsoleColor.Red;
      		 	  	//  Console.WriteLine("#DEV Notice: IOException source: {0}", e.Source);
      		  	 	//  Console.ResetColor();
				 }
				 catch(System.UnauthorizedAccessException)
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
				 
				 }
			   }
		}
	


		
	

