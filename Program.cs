using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zerohnzero.solver
{
    class Program
    {
        static void Main(string[] args)
        {
            string boardFilePath = Path.Combine(Environment.CurrentDirectory, "boards.txt");

            var testManager = new TestManager(boardFilePath, Console.WriteLine);
            testManager.Initialize();

            testManager.Execute(new CurtisSolver());

            Console.ReadKey();
        }
    }
}
