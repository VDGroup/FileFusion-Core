using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Update
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] Args)
        {
            //TODO:WOP New Main project
            /*Input Documentation 
            0)FF url (required)
            1)Plugin version (Not required)
            2)Plugin url (Not required)
            
            */

            if (Args.Length == 1)
            {
                UpdateFF(Args[0]);
            }
            if (Args.Length == 3)
            {
                UpdateFF(Args[0]);
                if (Args.Length == 1)
            {
                UpdateFF(Args[0]);
                Update(Args[1],Args[2]);
            }
            }


        }
        static void UpdateFF(string FFURL)
        {
            try
            {
                if (UrlCheck(FFURL))
                {

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        static void Update(string PluginVersion, string PluginURL)
        {
            try
            {
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private static bool UrlCheck(string URL)
        {
            try
            {
                if (URL == null)
                {
                    return false;
                }
                bool exists = false;
                HttpWebResponse response = null;
                var request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "HEAD";
                request.Timeout = 5000;
                request.AllowAutoRedirect = false;

                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    exists = response.StatusCode == HttpStatusCode.OK;
                }
                catch
                {
                    exists = false;
                }
                finally
                {

                    if (response != null)
                        response.Close();
                }
                return exists;
            }
            catch
            {

                return false;
            }
        }
    }
}
