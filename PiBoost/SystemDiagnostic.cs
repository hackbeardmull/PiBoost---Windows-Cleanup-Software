/*
 * Created by SharpDevelop.
 * User: dierk.piening
 * Date: 20.11.2014
 * Time: 10:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.IO;
using System.Management.Instrumentation;
using System.Management;
using System.Collections;



namespace PiBoost
{
	/// <summary>
	/// Description of SystemDiagnostic.
	/// </summary>
	public class SystemDiagnostic
	{
		winver WinVer = new winver();
		static PerformanceCounter cpuCounter; // globaler PerformanceCounter 

static void InitialisierePerformanceCounter() // Initialisieren
{
	cpuCounter = new PerformanceCounter();
	cpuCounter.CategoryName = "Processor";
	cpuCounter.CounterName = "% Processor Time";
	cpuCounter.InstanceName = "_Total"; // "_Total" entspricht der gesamten CPU Auslastung, Bei Computern mit mehr als 1 logischem Prozessor: "0" dem ersten Core, "1" dem zweiten...
}

static float GetCPUusage() // Liefert die aktuelle Auslastung zurück
{
	return cpuCounter.NextValue();
}



		public void SystemDiagnosticPush()
		{
			
				
// Speicherauslastung (in Byte)
			PerformanceCounter perCnt = new PerformanceCounter("Memory", "Available Bytes");
			long availableMemory = (Convert.ToInt64(perCnt.NextValue()));

			// Gesamtspeicher (in Byte)
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT totalphysicalmemory FROM Win32_ComputerSystem");
			ManagementObjectCollection res = searcher.Get();
			 long totalMemroy = 0;
			foreach (ManagementObject mo in res)
			{
   				long totalMemory = long.Parse(mo["totalphysicalmemory"].ToString());
			}
           InitialisierePerformanceCounter(); // Initialisieren
           
 
			ManagementObjectSearcher mos = 
			new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
			foreach (ManagementObject mo in mos.Get()) {
				Console.WriteLine(mo["Name"]);
			}
			System.Threading.Thread.Sleep(500);
			int counter = 0;
			float cpuUsage = 0;
			while( counter < 3)
			{
				cpuUsage = GetCPUusage();
				System.Threading.Thread.Sleep(90);
				counter++;
			}
			float ramC = availableMemory / 8;
				Console.Write("CPU Auslastung: " + cpuUsage + " % ");    // CPU Auslastung in die Konsole schreiben
                Console.WriteLine("Arbeitspeicher: " + ramC );
                Console.WriteLine(WinVer.version());
                Console.WriteLine();
			
			
			
		}
	}
}
