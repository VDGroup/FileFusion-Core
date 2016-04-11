using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

namespace PluginInstaller
{
    class CSVManager
    {
        //TODO: CSV read cell functionality is missing :(
        private readonly string FP;
        private readonly char Sep;
        public CSVManager(string FilePath,char Separator)
        {
            FP = FilePath;
            if (!File.Exists(FP))
            {
                File.Create(FP).Dispose();
            }
            Sep = Separator;
        }

        public CSVManager(string FilePath)
        {
            FP = FilePath;
            if (!File.Exists(FP))
            {
                File.Create(FP).Dispose();
                
            }
            Sep = ',';
        }

        public string[][] CSVToArray()
        {
            if (FP == null)
            {
                return null;
            }
            else
            {
                StreamReader sr = new StreamReader(FP);
                List<string[]> a = new List<string[]>();
                while (!sr.EndOfStream)
                {
                    a.Add(sr.ReadLine().Split(Sep));
                }
                sr.Close();
                return a.ToArray();
            }
        }
        public string[][] CSVToArrayInverted()
        {
            if (FP == null)
            {
                return null;
            }
            else
            {
                StreamReader sr = new StreamReader(FP);
                List<string[]> a = new List<string[]>();
                while (!sr.EndOfStream)
                {
                    a.Add(sr.ReadLine().Split(Sep));
                }
                sr.Close();
                return a.ToArray();
            }
        }
        public bool ArrayToCSV(string[][] a)
        {
            try
            {
                StreamWriter sw = new StreamWriter(FP);
                foreach (var z in a)
                {
                    sw.WriteLine(string.Join(Sep.ToString(), z));
                }
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public bool SortCSVLine(int Line)
        {
            var a = CSVToArray();
            try
            {
                Array.Sort(a[Line]);
                if (ArrayToCSV(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch
            {
                return false;

            }
        }

        public string[] GetLine(int Line)
        {
            var a = CSVToArray();
            return a[Line];
        }
        

        public bool ReplaceCell(int LineIndex, int CulumnIndex,string Value)
        {
            var a = CSVToArray();
            try
            {
                a[LineIndex][CulumnIndex] = Value;
                if (ArrayToCSV(a))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                try
                {
                    if (LineIndex +1 > a.Length)
                    {
                        int difference = LineIndex + 1 - a.Length;
                        List<string[]> TmpLst = a.OfType<string[]>().ToList();
                        string[] empty = {""};
                        for (int i = 0; i < difference; i++)
                        {
                            TmpLst.Add(empty);
                        }
                        
                        a = TmpLst.ToArray();
                    }
                    if (CulumnIndex + 1 > a[LineIndex].Length)
                    {
                        int difference = CulumnIndex + 1 - a[LineIndex].Length;
                        List<string> TmpLst = a[LineIndex].OfType<string>().ToList();
                        for (int i = 0; i < difference; i++)
                        {
                            TmpLst.Add("");
                        }
                        a[LineIndex] = TmpLst.ToArray();
                    }
                    a[LineIndex][CulumnIndex] = Value;
                    if (ArrayToCSV(a))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }

        }
        //TODO:Add new features! for csv like find, sort... - not important

    }
}
