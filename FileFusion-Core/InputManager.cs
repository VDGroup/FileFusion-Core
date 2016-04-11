using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FileFusion_Core
{
    class InputManager
    {

        public InputManager(string[] Input)
        {

            //TODO: Useless object! Class program.cs is empty - no idea what to do :(
            using (RegistryKey Key = Registry.ClassesRoot.OpenSubKey(Variables.ProtocolName))
                if (Key == null)
                    Asoc();
            string NInput = string.Join(" ", Input);
            if ((NInput.ToLower()).StartsWith(Variables.ProtocolName.ToLower() + ":"))
                NInput = NInput.Remove(0, Variables.ProtocolName.Length + 1);
            Input = NInput.Split(Variables.Separator);
            if (Input.Length > 0)
            {
                if (Input[0] != null)
                {
                    string PluginName = Input[0];
                    Input = Input.RemoveFromArray(PluginName);
                    StartPlugin(PluginName,Input);
                }
            }

        }

        /*TODO: Lot of work to do! - important!!!
        1) Start plugin must load database of plugins
        2) Start plugin must scan database for plugin
        3) Plugin start sequence
        */
        private void StartPlugin(string PLuginName,string[] InputArgs)
        {
            CSVManager csv = new CSVManager(Variables.PluginsDatabasePath);
            var PluginList = csv.CSVToArray();
            try
            {
                foreach (var Plugin in PluginList)
                {
                    try
                    {
                        if (Plugin[0] == PLuginName)
                        {
                            Process PLuginArgs = new Process();
                            PLuginArgs.StartInfo.Arguments = string.Join(" ",InputArgs);
                            PLuginArgs.StartInfo.FileName = Plugin[1];
                            PLuginArgs.StartInfo.UseShellExecute = false;
                            PLuginArgs.Start();
                        }
                    }
                    catch(Exception e)
                    {//MessageBox.Show(e.ToString()); 
                    }
                }
            }
            catch
            {
                //Code for empty array XD
            }
        }
        //TODO: Improve Registry association :D (rubbish) - not important
        public static void Asoc()
        {
            
            try
            {
                //Adding registry into system

                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                RegistryKey reg = Registry.ClassesRoot.CreateSubKey(Variables.ProtocolName);
                reg.SetValue("", "URL:" + Variables.ProtocolDescription);
                reg.SetValue("URL Protocol", "");
                reg.CreateSubKey("DefaultIcon").SetValue("", "");
                reg.CreateSubKey("shell\\open\\command").SetValue("", @"""" + path + @""" ""%1""");
                //RegistryKey My = Registry.ClassesRoot.CreateSubKey(Variables.);
                Registry.ClassesRoot.CreateSubKey("."+Variables.PluginExtension).SetValue("", Variables.PluginExtension, Microsoft.Win32.RegistryValueKind.String);
                Registry.ClassesRoot.CreateSubKey(Variables.PluginExtension + "\\shell\\open\\command").SetValue("", Application.ExecutablePath + @" ""%l"" ", Microsoft.Win32.RegistryValueKind.String);
                //MessageBox.Show("Associated to\"" + protocolname + "\" protocol");
                //iniManager.Write("AStatus", "0");

            }
            catch
            {
                //Asociation failed

                //if (iniManager.Read("AStatus") != "1")
                //{
                try
                {
                    WindowsIdentity identity = WindowsIdentity.GetCurrent();
                    WindowsPrincipal principal = new WindowsPrincipal(identity);
                    if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                    {
                        var exeName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                        ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                        startInfo.Verb = "runas";
                        //iniManager.Write("AStatus", "1");
                        System.Diagnostics.Process.Start(startInfo);
                    }
                    Environment.Exit(0);
                }
                catch
                {

                    Environment.Exit(1);
                }
                    //TODO: Maybe assoc loop bug is again posible thanks to some changes so... Try to find defective code and fix the issue XDD (Good luck)
                    
            }




        }

    }
}
