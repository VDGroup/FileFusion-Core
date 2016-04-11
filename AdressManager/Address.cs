using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//TODO: Frantisku jnemam ani tuseni jestli tahle trida funguje. Ani jednou jsem ji nevyzkousel. PORADNE JI PROVETREJ abychom nasli chyby!
namespace AddressManager
{
    public class Address
    {
        private IniManager Im = new IniManager("Adresses.DAT");
        private string Section;
        public Address(string Section)
        {
            this.Section = Section;

        }

        public string GetAddress()
        {
            MainAddressSetup();
            try
            {
                return Im.Read("Main", this.Section);
            }
            catch
            {
                return null;
            }
            

        }

        public void NewAddress(string Address)
        {

            var Adresslist = new List<string>();
            int i = 0;
            bool x = true;
            while ((Im.Read(Convert.ToString(i), Section) != "") && x)
            {
                Adresslist.Add(Im.Read(Convert.ToString(i), Section));
                if (((Im.Read(Convert.ToString(i), Section) == null) || (Im.Read(Convert.ToString(i), Section) == "")) && ((Im.Read(Convert.ToString(i + 1), Section) == null) || (Im.Read(Convert.ToString(i + 1), Section) == "")) && ((Im.Read(Convert.ToString(i + 2), Section) == null) || (Im.Read(Convert.ToString(i + 2), Section) == "")))
                {
                    x = false;
                }
                i++;
            }
            if (!Adresslist.Contains(Address))
            {
                Adresslist.Add(Address);
            }
            int y = 0;
            foreach (var v in Adresslist)
            {
                Im.Write(y.ToString(), v, Section);
                y++;
            }
            MainAddressSetup();
            
        }


        public void MainAddressSetup()
        {
            try
            {
                var Adresslist = new List<string>();
                int i = 0;
                bool x = true;
                while ((Im.Read(Convert.ToString(i), Section) != "") && x)
                {
                    Adresslist.Add(Im.Read(Convert.ToString(i), Section));
                    if (((Im.Read(Convert.ToString(i), Section) == null) || (Im.Read(Convert.ToString(i), Section) == "")) && ((Im.Read(Convert.ToString(i + 1), Section) == null) || (Im.Read(Convert.ToString(i + 1), Section) == "")) && ((Im.Read(Convert.ToString(i + 2), Section) == null) || (Im.Read(Convert.ToString(i + 2), Section) == "")))
                    {
                        x = false;
                    }
                    i++;
                }
                
                foreach (var v in Adresslist)
                {
                    if (UrlCheck(v))
                    {
                        Im.Write("Main",v,Section);
                        return;
                    }
                }
                Im.Write("Main", "", Section);
            }
            catch 
            {
                return;
            }
            
        }

        public string MapAddresses()
        {
           var Adresslist = new List<string>();
            int i = 0;
            bool x = true;
            while ((Im.Read(Convert.ToString(i), Section) != "") && x)
            {
                Adresslist.Add(Im.Read(Convert.ToString(i), Section));
                if (((Im.Read(Convert.ToString(i), Section) == null) || (Im.Read(Convert.ToString(i), Section) == "")) && ((Im.Read(Convert.ToString(i + 1), Section) == null) || (Im.Read(Convert.ToString(i + 1), Section) == "")) && ((Im.Read(Convert.ToString(i + 2), Section) == null) || (Im.Read(Convert.ToString(i + 2), Section) == "")))
                {
                    x = false;
                }
                i++;
            }
            int tmp = 0;
            while (tmp < Adresslist.Count)
            {
                var v = Adresslist[tmp];
                tmp++;
                try
                {
                    if (UrlCheck(v + @"/AddressList.txt"))
                    {
                        string z = v + @"/AddressList.txt";
                        WebRequest request =  WebRequest.Create(z);
                        WebResponse response = request.GetResponse();
                        Stream dataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(dataStream);
                        while (!reader.EndOfStream)
                        {
                            string a = reader.ReadLine();
                            if (!Adresslist.Contains(a))
                            {
                                Adresslist.Add(a);
                            }
                        }
                        
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());

                }
            }
            int y = 0;
            foreach (var v in Adresslist)
            {
                Im.Write(y.ToString(),v,Section);
                y++;
                
            }
            MainAddressSetup();
            return GetAddress();
        }


//        int i = 0;
//            while (true)
//            {
//                if (((Im.Read(Convert.ToString(i), Section) == null) || (Im.Read(Convert.ToString(i), Section) == "")) && ((Im.Read(Convert.ToString(i + 1), Section) == null) || (Im.Read(Convert.ToString(i + 1), Section) == "")) && ((Im.Read(Convert.ToString(i + 2), Section) == null) || (Im.Read(Convert.ToString(i + 2), Section) == "")))
//                {
//                    return;
//                }
//                try
//                {
//                    if (UrlCheck(Im.Read(Convert.ToString(i), Section)))
//                    {
//                        WebRequest request = WebRequest.Create(Im.Read(Convert.ToString(i), Section) + @"/AddressList.txt");
//        WebResponse response = request.GetResponse();
//        Stream dataStream = response.GetResponseStream();
//        StreamReader reader = new StreamReader(dataStream);
//                        while (!reader.EndOfStream)
//                        {
//                            string a = reader.ReadLine();
//                            while (Im.Read(Convert.ToString(i), this.Section) != )
//                            {
//                                if (((Im.Read(Convert.ToString(i), Section) == null) || (Im.Read(Convert.ToString(i), Section) == "")) && ((Im.Read(Convert.ToString(i + 1), Section) == null) || (Im.Read(Convert.ToString(i + 1), Section) == "")) && ((Im.Read(Convert.ToString(i + 2), Section) == null) || (Im.Read(Convert.ToString(i + 2), Section) == "")))
//                                {
//                                    return;
//                                }
//                                i++;
//                            }
//}
//                    }

//                }
//                catch
//                {
//                    i++;
//                }
                

//            }


        private bool UrlCheck(string URL)
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
