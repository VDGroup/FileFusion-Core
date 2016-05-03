using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF_Omega
{
    class PluginRequest
    {
        public string pluginName { get; }
        public string[] arguments;
        public PluginRequest(string[] input)
        {
            string inp = string.Join(" ",input);
            if (inp.ToLower().StartsWith(Variables.protocolName + ":")) ;
            inp.Remove(0,Variables.protocolName.Length + 1);

            try
            {
                string[] e = inp.Split(Variables.separator);
                pluginName = e[0];
                List<string> args = new List<string>();
                for (int i = 1; i <= e.Length; i++)
                {
                    args.Add(e[i]);
                    arguments = args.ToArray();
                }
            }
            catch { }
        }
    }
}
