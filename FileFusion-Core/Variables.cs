using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressManager;

namespace FileFusion_Core
{
    class Variables
    {
        public static Address a = new Address("Main");
        
        public static string ProtocolName = "FFP";
        public static string PluginExtension = "FF";
        public static string ProtocolDescription = "FileFusion universal protocol";
        public static string MainUrl = a.MapAddresses();
        public static string MainUpdateURL = MainUrl + "/update.dat";
        public static string PluginsDatabasePath = Directory.GetCurrentDirectory() + "./Plugins.DAT";
        public static char Separator = '|';
    }
}
