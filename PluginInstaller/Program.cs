using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Diagnostics;


namespace PluginInstaller
{
    static class Program
    {
        public static bool Valid = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            
            if (Args.Length > 0)
            {
                string PluginSource = string.Join(" ", Args);
                try
                {

                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "./Temp");
                    using (ZipArchive archive = ZipFile.OpenRead(PluginSource))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {

                            entry.ExtractToFile(Path.Combine("./Temp", entry.FullName));


                        }

                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    if (File.Exists("./Temp/info.rtf"))
                        Application.Run(new PluginInfo());
                    if (Valid)
                    {
                        CSVManager c = new CSVManager("./Temp/InstallScript.csv");
                        var d = c.CSVToArray();
                        CSVManager csv = new CSVManager("./Plugins.DAT");
                        var z = csv.CSVToArray();
                        var zz = z.ToList();
                        foreach (var t in d)
                        {
                            try
                            {
                                switch (t[0])
                                {
                                    case "install":
                                        File.Copy("./Temp/" + t[1], "./plugins/" + t[1]);
                                        zz.Add(new string[] { "./plugins/" + t[1], t[2],t[3],t[4] });
                                        break;
                                    case "run":
                                        File.Copy("./Temp/" + t[1], "./plugins/" + t[1]);
                                        ProcessStartInfo startInfo = new ProcessStartInfo("./plugins/" + t[1]);
                                        startInfo.Arguments = t[2];
                                        startInfo.UseShellExecute = false;
                                        System.Diagnostics.Process.Start(startInfo);
                                        break;
                                    case "copy":
                                        File.Copy("./Temp/" + t[1], "./plugins/" + t[1]);
                                        break;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    Directory.Delete("./Temp", true);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

        }
    }
}
