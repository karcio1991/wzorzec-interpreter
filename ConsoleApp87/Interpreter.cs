using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp87
{



    class InterpreterLiczbArabskich
    {
        public void FunkcjaTestowa()
        {
            InterpreterSetek iSetek = new InterpreterSetek();


            char[] x = iSetek.ZwrocReszte(8).ToArray();

            foreach (var item in x)
            {
                Console.WriteLine(x);
            }


        }
      
        public virtual void interpretuj(ref int liczbaArabska, ref string wartosc)
        {
            int index = 0; int zczytanaWartosc = 0;
            if (liczbaArabska == 0) return;
            char[] ciagZnakow = Convert.ToString(liczbaArabska).ToCharArray();

            if (this is InterpreterTysiecy && index == 0)
            {
                zczytanaWartosc = int.Parse(ciagZnakow[index].ToString());

                for (int i = 0; i < zczytanaWartosc; i++)
                {
                    wartosc += this.jeden().ToString();
                }  
                zczytanaWartosc = int.Parse(ciagZnakow[index].ToString());
                return;
            }

            if (this is InterpreterSetek) index = 1;
            else if (this is InterpreterDziesiatek) index = 2;
            else if (this is InterpreterJednosci) index = 3;

            zczytanaWartosc = int.Parse(ciagZnakow[index].ToString());


            if (zczytanaWartosc > 0 && zczytanaWartosc == 1 && index > 0)
            {
                wartosc += this.jeden().ToString();

            }
            else if (zczytanaWartosc > 0 && zczytanaWartosc == 4 && index > 0)
            {
                wartosc += this.cztery().ToString();

            }
            else if (zczytanaWartosc > 0 && zczytanaWartosc == 5 && index > 0)
            {
                wartosc += this.piec().ToString();

            }
            else if (zczytanaWartosc > 0 && zczytanaWartosc == 9 && index > 0)
            {
                wartosc += this.dziewiec().ToString() ;

            }
            else if (zczytanaWartosc != 0 && index > 0)
            {
               
                wartosc += this.ZwrocReszte(zczytanaWartosc);

            }
        }

        protected InterpreterLiczbArabskich(int wartość) { }

        public InterpreterLiczbArabskich interpreterTysiecy;
        public InterpreterLiczbArabskich interpreterSetek;
        public InterpreterLiczbArabskich interpreterDziesiatek;
        public InterpreterLiczbArabskich interpreterJednosci;

        public InterpreterLiczbArabskich()
        {

            interpreterDziesiatek = new InterpreterDziesiatek();
            interpreterJednosci = new InterpreterJednosci();
            interpreterSetek = new InterpreterSetek();
            interpreterTysiecy = new InterpreterTysiecy();

        }


    
        protected virtual string dziewiec() { return null; }
        protected virtual string cztery() { return null; }
        protected virtual char jeden() { return ' '; }
        protected virtual char piec() { return ' '; }

        //  public virtual string ZwrocReszte(int z) { return "ass"; }


        public string ZwrocReszte(int z)
        {
            string x = "";
            if (z == 2)
                x += jeden().ToString() + jeden().ToString();
            else if (z == 3)
                x += jeden().ToString() + jeden().ToString() + jeden().ToString();
            else if (z == 6)
                x += piec().ToString() + jeden().ToString();
            else if (z == 7)
                x += piec().ToString() + jeden().ToString() + jeden().ToString();
            else if (z == 8)
                x += piec() + jeden().ToString() + jeden().ToString() + jeden().ToString();


            return x;
        }

        public string Interpretuj(int liczbaArabaska)
        {
            string wartosc = "";

            interpreterTysiecy.interpretuj(ref liczbaArabaska, ref wartosc);
            interpreterSetek.interpretuj(ref liczbaArabaska, ref wartosc);
            interpreterDziesiatek.interpretuj(ref liczbaArabaska, ref wartosc);
            interpreterJednosci.interpretuj(ref liczbaArabaska, ref wartosc);


            return wartosc;
        }
    }



    class InterpreterTysiecy : InterpreterLiczbArabskich
    {
        public InterpreterTysiecy() : base(0)
        {

        }

        protected override char jeden()
        {
            return 'M';
        }

    }


    class InterpreterSetek : InterpreterLiczbArabskich
    {

        public InterpreterSetek() : base(0)
        {

        }
        protected override string dziewiec()
        {
            return "CM";
        }

        protected override string cztery()
        {
            return "CD";
        }

        protected override char piec()
        {
            return 'D';
        }

        protected override char jeden()
        {

            return 'C';

        }
    }

    class InterpreterDziesiatek : InterpreterLiczbArabskich
    {

        public InterpreterDziesiatek() : base(0)
        {

        }
        protected override string dziewiec()
        {
            return "XC";
        }

        protected override string cztery()
        {
            return "XL";
        }

        protected override char piec()
        {
            return 'L';
        }

        protected override char jeden()
        {
            return 'X';

        }
    }

    class InterpreterJednosci : InterpreterLiczbArabskich
    {
        public InterpreterJednosci() : base(0)
        {

        }
        protected override string dziewiec()
        {
            return "IX";
        }

        protected override string cztery()
        {
            return "IV";
        }

        protected override char piec()
        {
            return 'V';
        }

        protected override char jeden()
        {
            return 'I';

        }
    }

}
