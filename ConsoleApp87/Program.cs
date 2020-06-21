using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp87
{
    class Program
    {
        static void Main(string[] args)
        {


            InterpreterLiczbArabskich liczba = new InterpreterLiczbArabskich();
            while (true)
            {
                
                string intLa = Console.ReadLine();
                int intL = int.Parse(intLa);
                string rezultat=  liczba.Interpretuj(intL);
                Console.WriteLine(rezultat);

            }

            Console.ReadKey();
        }
    }
}
