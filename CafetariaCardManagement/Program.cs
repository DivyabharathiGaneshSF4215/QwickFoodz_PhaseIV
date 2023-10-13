using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafetariaCardManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FileHandling.Create();
            Operations.AddDefaultData();
            FileHandling.ReadFromCSC();
            FileHandling.WriteToCsv();
        }
    }
}