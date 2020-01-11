/*
 * 
 * # -------------------------------------------- #
 * # | Programm Name: PiBoost by BoostWare      | #
 * # | Version: 1.0.1                           | #
 * # | Revision: A - 1.3.8                      | #
 * # |                                          | #
 * # | Publisher: BoostWare                     | #
 * # | E-Mail: support@boostware.de             | #
 * # |                                          | #
 * # | (C) 2014 BoostWare                       | #
 * # | Licensed under the CDDL                  | #
 * # -------------------------------------------- #
 */
using System;
using System.IO;
using Microsoft.Win32;

namespace PiBoost
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine();
			Console.WriteLine("PiBOOST Version 1.0.1 ");
 			Console.WriteLine("(C) 2014 BoostWare Foundation by Dierk Piening, Joschua Schwab, Max Luenzer");
 			Console.WriteLine("This Programm is licensed under the CDDL");
			Console.WriteLine("--------------------------------------------------------------------------------");
			 //##################### Globale Pfad Deklaration ####################
			 
			 admin Admin = new admin();
			 
			 
			 SystemDiagnostic systemdiag = new SystemDiagnostic();
			 systemdiag.SystemDiagnosticPush();
			 
			  winclean Winclean = new winclean();
			  Winclean.wincleaner();
			 
			  Console.WriteLine();
			  Console.WriteLine("---> Cleaning Browser Data <---");
			  Chrome Chromeclean =  new Chrome();
			  Chromeclean.ChromeC();
			 
			  Opera Operaclean = new Opera();
			  Operaclean.OperaO();
			  
			  Safari Safariclean = new Safari();
			  Safariclean.SafariS();
			  
			  Firefox Firefoxclean = new Firefox();
			  Firefoxclean.FirefoxF();
			  
			  Iron Ironclean = new Iron();
			  Ironclean.IronI();
			  
			  IExplorer IEclean = new IExplorer();
			  IEclean.IExplorerD();
			  
			  Console.WriteLine();
			Console.Write("Press any key to exit . . . ");
			Console.ReadKey(true);
		}
	}
}