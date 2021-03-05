using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace longBeep
{
    class Program
    {
        static void Main(string[] args)
        {
           //bool beepStop = false;
            for (int b = 0; b <= 10 ; b++)
            {
                Random myRandomFreq = new Random();                
                Console.Beep(myRandomFreq.Next(200,8000), 2000);

                /*if ( env Console.ReadKey())
                {
                    Environment.Exit(0);

                }*/
            }
             

        }
    }
}
