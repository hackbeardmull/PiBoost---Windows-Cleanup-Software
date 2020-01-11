/*
 * Created by SharpDevelop.
 * User: dierk-bent.piening
 * Date: 25.11.2014
 * Time: 09:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Linq;

namespace PiBoost
{
	/// <summary>
	/// Description of winver.
	/// </summary>
	public class winver
	{
		 public string version()
        {
            OperatingSystem osInfo = System.Environment.OSVersion;
            string strVers = string.Empty;

            if (osInfo.Platform == PlatformID.Win32Windows)
            {
                // Windows 98 / 98SE oder Windows Me. Windows 95 unterstützt .NET nicht 
                if (osInfo.Version.Minor == 10) strVers = "Windows 98";
                if (osInfo.Version.Minor == 90) strVers = "Windows Me";
            }

            if (osInfo.Platform == PlatformID.Win32NT)
            {
                // Windows NT 4.0, 2000, XP oder Server 2003. Windows NT 3.51 unterstützt .NET nicht 
                if (osInfo.Version.Major == 4) strVers = "Windows NT 4.0";

                if (osInfo.Version.Major == 5)
                {
                    switch (osInfo.Version.Minor)
                    {
                        case 0: strVers = "Windows 2000"; break;
                        case 1: strVers = "Windows XP"; break;
                        case 2: strVers = "Windows Server 2003"; break;
                    }
                }
                if (osInfo.Version.Major == 6)
                {
                    if (osInfo.Version.Minor == 0)
                    {
                        strVers = "Vista/Win2008";
                    }
                }
            }

            strVers += "" + osInfo.ServicePack + ", Revision " + osInfo.Version.Revision.ToString() + ", " + osInfo.VersionString;

            if (strVers == "")
            {
                strVers = "Unbekannte Windows-Version";
            }

            return strVers;
        }
		}
}

