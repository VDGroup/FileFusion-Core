using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AddressManager;

namespace TmpLibraryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Address a = new Address("Main");
            Console.WriteLine("instance created");
            a.NewAddress("http://192.168.2.106");
            Console.WriteLine("address created");
            Console.WriteLine(a.GetAddress());
            Console.WriteLine("1");
            a.MainAddressSetup();
            Console.WriteLine(a.GetAddress());
            Console.WriteLine("2");
            a.MapAddresses();
            Console.WriteLine("End");
            Console.ReadKey();

        }
    }
}
